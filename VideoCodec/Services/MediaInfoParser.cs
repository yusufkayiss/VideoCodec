using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using VideoCodec.Models;

namespace VideoCodec.Services;


public static class MediaInfoParser
{
    // Bu metot, FFmpeg konsol çıktısındaki ham metin verisini Regex kullanarak analiz eder ve video/ses metadata bilgilerini ayrıştırır.
    public static MediaInfoResult Parse(string ffmpegOutput)
    {
        var durationText = "N/A";
        var videoCodec = "N/A";
        var audioCodec = "N/A";
        var resolution = "N/A";
        var frameRate = "N/A";
        var duration = TimeSpan.Zero;

        var durationMatch = Regex.Match(ffmpegOutput, @"Duration:\s(?<dur>\d{2}:\d{2}:\d{2}\.\d{2})");
        if (durationMatch.Success)
        {
            durationText = durationMatch.Groups["dur"].Value;
            _ = TimeSpan.TryParseExact(durationText, @"hh\:mm\:ss\.ff", CultureInfo.InvariantCulture, out duration);
        }

        var videoMatch = Regex.Match(ffmpegOutput, @"Video:\s(?<video>[^,]+)");
        if (videoMatch.Success)
        {
            videoCodec = videoMatch.Groups["video"].Value.Trim();
        }

        var audioMatch = Regex.Match(ffmpegOutput, @"Audio:\s(?<audio>[^,]+)");
        if (audioMatch.Success)
        {
            audioCodec = audioMatch.Groups["audio"].Value.Trim();
        }

        var resolutionMatch = Regex.Match(ffmpegOutput, @"(?<res>\d{2,5}x\d{2,5})");
        if (resolutionMatch.Success)
        {
            resolution = resolutionMatch.Groups["res"].Value;
        }

        var fpsMatch = Regex.Match(ffmpegOutput, @"(?<fps>\d+(\.\d+)?)\sfps");
        if (fpsMatch.Success)
        {
            frameRate = fpsMatch.Groups["fps"].Value;
        }

        return new MediaInfoResult
        {
            DurationText = durationText,
            VideoCodec = videoCodec,
            AudioCodec = audioCodec,
            Resolution = resolution,
            FrameRate = frameRate,
            Duration = duration
        };
    }

    // Bu metot, ayrıştırılan medya bilgilerini ve dosya boyutunu kullanıcı arayüzünde gösterilmek üzere okunabilir bir metin formatına dönüştürür.
    public static string BuildDisplayText(string inputPath, MediaInfoResult result)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Video: {Path.GetFileName(inputPath)}");
        sb.AppendLine($"Süre: {result.DurationText}");
        sb.AppendLine($"Codec: {result.VideoCodec}");
        sb.AppendLine($"Ses: {result.AudioCodec}");
        sb.AppendLine($"Çözünürlük: {result.Resolution}");
        sb.AppendLine($"Kare Hızı: {result.FrameRate} fps");
        sb.AppendLine($"Boyut: {new FileInfo(inputPath).Length / (1024 * 1024)} MB");
        return sb.ToString();
    }
}
