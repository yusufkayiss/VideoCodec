namespace VideoCodec.Strategies;

public interface ICodecStrategy
{
    string Name { get; }
    string CodecArgument { get; }
    string ExtraArguments { get; }
}

public sealed class H264Strategy : ICodecStrategy
{
    public string Name => "H.264";
    public string CodecArgument => "libx264";
    public string ExtraArguments => string.Empty;
}

public sealed class H265Strategy : ICodecStrategy
{
    public string Name => "H.265 / HEVC";
    public string CodecArgument => "libx265";
    public string ExtraArguments => string.Empty;
}

public sealed class Vp9Strategy : ICodecStrategy
{
    public string Name => "VP9";
    public string CodecArgument => "libvpx-vp9";
    public string ExtraArguments => "-row-mt 1";
}

public sealed class Av1Strategy : ICodecStrategy
{
    public string Name => "AV1";
    public string CodecArgument => "libaom-av1";
    public string ExtraArguments => "-cpu-used 4";
}

public sealed class AacStrategy : ICodecStrategy
{
    public string Name => "AAC";
    public string CodecArgument => "aac";
    public string ExtraArguments => string.Empty;
}

public sealed class Mp3Strategy : ICodecStrategy
{
    public string Name => "MP3";
    public string CodecArgument => "libmp3lame";
    public string ExtraArguments => string.Empty;
}

public sealed class Ac3Strategy : ICodecStrategy
{
    public string Name => "AC3";
    public string CodecArgument => "ac3";
    public string ExtraArguments => string.Empty;
}

public sealed class WavStrategy : ICodecStrategy
{
    public string Name => "WAV";
    public string CodecArgument => "pcm_s16le";
    public string ExtraArguments => string.Empty;
}

public static class VideoCodecStrategyFactory
{
    private static readonly IReadOnlyDictionary<string, ICodecStrategy> Strategies = new Dictionary<string, ICodecStrategy>(StringComparer.OrdinalIgnoreCase)
    {
        ["H.264"] = new H264Strategy(),
        ["H.265 / HEVC"] = new H265Strategy(),
        ["VP9"] = new Vp9Strategy(),
        ["AV1"] = new Av1Strategy()
    };

    public static IEnumerable<string> GetStrategyNames() => Strategies.Keys;

    public static ICodecStrategy Resolve(string name)
    {
        if (Strategies.TryGetValue(name, out var strategy))
        {
            return strategy;
        }

        return Strategies["H.264"];
    }
}

public static class AudioCodecStrategyFactory
{
    private static readonly IReadOnlyDictionary<string, ICodecStrategy> Strategies = new Dictionary<string, ICodecStrategy>(StringComparer.OrdinalIgnoreCase)
    {
        ["AAC"] = new AacStrategy(),
        ["aac"] = new AacStrategy(),
        ["MP3"] = new Mp3Strategy(),
        ["mp3"] = new Mp3Strategy(),
        ["AC3"] = new Ac3Strategy(),
        ["WAV"] = new WavStrategy(),
        ["wav"] = new WavStrategy()
    };

    public static IEnumerable<string> GetStrategyNames() =>
        new[] { "AAC", "MP3", "AC3", "WAV" };

    public static ICodecStrategy Resolve(string name)
    {
        if (Strategies.TryGetValue(name, out var strategy))
        {
            return strategy;
        }

        return Strategies["AAC"];
    }
}
