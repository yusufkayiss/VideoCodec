namespace VideoCodec.Models;

// FFmpeg tarafından ayrıştırılan medya metadata bilgilerini (süre, codec, çözünürlük vb.) arayüze taşımak için kullanılan veri modeli.
public sealed class MediaInfoResult
{
    public string DurationText { get; init; } = "N/A";
    public string VideoCodec { get; init; } = "N/A";
    public string AudioCodec { get; init; } = "N/A";
    public string Resolution { get; init; } = "N/A";
    public string FrameRate { get; init; } = "N/A";
    public TimeSpan Duration { get; init; } = TimeSpan.Zero;
}
