namespace VideoCodec.Models;

public sealed class VideoProcessRequest
{
    public string InputVideoPath { get; init; } = string.Empty;
    public string OutputPath { get; init; } = string.Empty;
    public string? ExtraAudioInputPath { get; init; }
    public string SelectedVideoCodec { get; init; } = "H.264";
    public string SelectedAudioCodec { get; init; } = "AAC";
    public string AudioOutputFormat { get; init; } = "mp3";
    public int VideoBitrateKbps { get; init; } = 2500;
    public string AudioBitrate { get; init; } = "128k";
    public string SelectedResolution { get; init; } = "Kaynak ile Aynı";
    public string SelectedFrameRate { get; init; } = "Kaynak ile Aynı";
}
