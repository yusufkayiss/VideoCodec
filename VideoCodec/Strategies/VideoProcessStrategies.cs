using System.Text;
using VideoCodec.Models;

namespace VideoCodec.Strategies;

public interface IVideoProcessStrategy
{
    string Name { get; }
    string BuildArguments(VideoProcessRequest request);
}

public sealed class ConvertVideoStrategy : IVideoProcessStrategy
{
    public string Name => "VideoDönüştür";

    public string BuildArguments(VideoProcessRequest request)
    {
        var videoStrategy = VideoCodecStrategyFactory.Resolve(request.SelectedVideoCodec);
        var audioStrategy = AudioCodecStrategyFactory.Resolve(request.SelectedAudioCodec);
        var vBitrate = $"{request.VideoBitrateKbps}k";
        var aBitrate = request.AudioBitrate;
        var vf = GetResolutionFilter(request.SelectedResolution);
        var fps = GetFrameRateArg(request.SelectedFrameRate);

        var sb = new StringBuilder();
        sb.Append($"-y -i \"{request.InputVideoPath}\" -c:v {videoStrategy.CodecArgument} -b:v {vBitrate} -c:a {audioStrategy.CodecArgument} -b:a {aBitrate} ");
        if (!string.IsNullOrWhiteSpace(vf))
        {
            sb.Append($"-vf \"{vf}\" ");
        }

        if (!string.IsNullOrWhiteSpace(fps))
        {
            sb.Append($"{fps} ");
        }

        if (!string.IsNullOrWhiteSpace(videoStrategy.ExtraArguments))
        {
            sb.Append($"{videoStrategy.ExtraArguments} ");
        }

        sb.Append($"\"{request.OutputPath}\"");
        return sb.ToString();
    }

    private static string GetResolutionFilter(string selected) => selected switch
    {
        "720p" => "scale=1280:720",
        "1080p" => "scale=1920:1080",
        "4K" => "scale=3840:2160",
        _ => string.Empty
    };

    private static string GetFrameRateArg(string selected) => selected switch
    {
        "24" => "-r 24",
        "30" => "-r 30",
        "60" => "-r 60",
        _ => string.Empty
    };
}

public sealed class ExtractAudioStrategy : IVideoProcessStrategy
{
    public string Name => "SesAyır";

    public string BuildArguments(VideoProcessRequest request)
    {
        var codec = AudioCodecStrategyFactory.Resolve(request.AudioOutputFormat).CodecArgument;
        return $"-y -i \"{request.InputVideoPath}\" -vn -c:a {codec} -b:a {request.AudioBitrate} \"{request.OutputPath}\"";
    }
}

public sealed class ReplaceAudioStrategy : IVideoProcessStrategy
{
    public string Name => "SesDeğiştir";

    public string BuildArguments(VideoProcessRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.ExtraAudioInputPath))
        {
            throw new InvalidOperationException("Ses değişim işlemi için harici ses dosyası gereklidir.");
        }

        var audioCodec = AudioCodecStrategyFactory.Resolve(request.SelectedAudioCodec).CodecArgument;
        return $"-y -i \"{request.InputVideoPath}\" -i \"{request.ExtraAudioInputPath}\" -map 0:v:0 -map 1:a:0 -c:v copy -c:a {audioCodec} -shortest \"{request.OutputPath}\"";
    }
}

public static class VideoProcessStrategyFactory
{
    private static readonly IReadOnlyDictionary<string, IVideoProcessStrategy> Strategies = new Dictionary<string, IVideoProcessStrategy>(StringComparer.OrdinalIgnoreCase)
    {
        ["VideoDönüştür"] = new ConvertVideoStrategy(),
        ["SesAyır"] = new ExtractAudioStrategy(),
        ["SesDeğiştir"] = new ReplaceAudioStrategy()
    };

    public static IVideoProcessStrategy Resolve(string name)
    {
        if (Strategies.TryGetValue(name, out var strategy))
        {
            return strategy;
        }

        return Strategies["VideoDönüştür"];
    }
}
