using System.Diagnostics;
using System.IO.Compression;
using System.Net.Http;
using System.Text.RegularExpressions;
using VideoCodec.Models;

namespace VideoCodec.Services;

public sealed class FfmpegService
{
    private static readonly HttpClient Http = new();

    // Bu metot, arka planda görünmez bir komut satırı açarak FFmpeg video motorunun sistemde yüklü ve çalışmaya hazır olup olmadığını test eder.
    public bool IsFfmpegAvailable()
    {
        try
        {
            var ffmpeg = ResolveFfmpegPath();
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ffmpeg,
                    Arguments = "-version",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit(2000);
            return process.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }

    public async Task<MediaInfoResult> ProbeMediaAsync(string inputFile, CancellationToken cancellationToken)
    {
        var ffmpegExe = ResolveFfmpegPath();
        var psi = new ProcessStartInfo
        {
            FileName = ffmpegExe,
            Arguments = $"-i \"{inputFile}\"",
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = psi };
        process.Start();
        using var reg = cancellationToken.Register(() =>
        {
            try
            {
                if (!process.HasExited)
                {
                    process.Kill(true);
                }
            }
            catch
            {
                // Ignore cancellation kill race.
            }
        });

        var stderr = await process.StandardError.ReadToEndAsync(cancellationToken);
        await process.WaitForExitAsync(cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();
        return MediaInfoParser.Parse(stderr);
    }

    public async Task RunAsync(
        string args,
        TimeSpan totalDuration,
        Action<int> onProgress,
        CancellationToken cancellationToken)
    {
        var ffmpegExe = ResolveFfmpegPath();
        var psi = new ProcessStartInfo
        {
            FileName = ffmpegExe,
            Arguments = args,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = psi, EnableRaisingEvents = true };
        process.Start();

        using var reg = cancellationToken.Register(() =>
        {
            try
            {
                if (!process.HasExited)
                {
                    process.Kill(true);
                }
            }
            catch
            {
                // Ignore force-kill errors during cancellation.
            }
        });

        while (!process.StandardError.EndOfStream)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var line = await process.StandardError.ReadLineAsync(cancellationToken);
            if (line is null)
            {
                continue;
            }

            UpdateProgress(totalDuration, line, onProgress);
        }

        await process.WaitForExitAsync(cancellationToken);
        if (process.ExitCode != 0)
        {
            throw new InvalidOperationException("FFmpeg işlemi başarısız oldu. FFmpeg kurulumu ve codec desteklerini kontrol edin.");
        }
    }

    public async Task DownloadAndInstallFfmpegAsync(
        CancellationToken cancellationToken,
        Action<string> setStatus,
        Action<int> setProgress)
    {
        const string ffmpegZipUrl = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip";
        var baseDir = AppContext.BaseDirectory;
        var toolsDir = Path.Combine(baseDir, "ffmpeg");
        Directory.CreateDirectory(toolsDir);

        var zipPath = Path.Combine(toolsDir, "ffmpeg.zip");
        var extractDir = Path.Combine(toolsDir, "extract");

        if (Directory.Exists(extractDir))
        {
            Directory.Delete(extractDir, true);
        }

        try
        {
            setProgress(0);
            await DownloadFileWithProgressAsync(ffmpegZipUrl, zipPath, setStatus, setProgress, cancellationToken);

            setStatus("FFmpeg arşivi çıkarılıyor...");
            setProgress(100);

            ZipFile.ExtractToDirectory(zipPath, extractDir, true);

            var ffmpegExe = Directory
                .EnumerateFiles(extractDir, "ffmpeg.exe", SearchOption.AllDirectories)
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(ffmpegExe))
            {
                throw new InvalidOperationException("İndirilen arşivde ffmpeg.exe bulunamadı.");
            }

            setStatus("FFmpeg kopyalanıyor...");
            var finalExe = Path.Combine(toolsDir, "ffmpeg.exe");
            File.Copy(ffmpegExe, finalExe, true);
        }
        catch (OperationCanceledException)
        {
            setStatus("FFmpeg indirme iptal edildi.");
            throw;
        }
        finally
        {
            TryDeleteFile(zipPath);
            if (Directory.Exists(extractDir))
            {
                try
                {
                    Directory.Delete(extractDir, true);
                }
                catch
                {
                    // Best effort cleanup.
                }
            }
        }
    }

    private static void UpdateProgress(TimeSpan totalDuration, string ffmpegLogLine, Action<int> onProgress)
    {
        if (totalDuration <= TimeSpan.Zero)
        {
            return;
        }

        var match = Regex.Match(ffmpegLogLine, @"time=(?<time>\d{2}:\d{2}:\d{2}\.\d{2})");
        if (!match.Success)
        {
            return;
        }

        if (!TimeSpan.TryParseExact(match.Groups["time"].Value, @"hh\:mm\:ss\.ff", null, out var processedDuration))
        {
            return;
        }

        var percent = (int)Math.Clamp(processedDuration.TotalSeconds / totalDuration.TotalSeconds * 100, 0, 100);
        onProgress(percent);
    }

    private static async Task DownloadFileWithProgressAsync(
        string url,
        string targetPath,
        Action<string> setStatus,
        Action<int> setProgress,
        CancellationToken cancellationToken)
    {
        using var response = await Http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();

        var totalBytes = response.Content.Headers.ContentLength;
        await using var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        await using var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write, FileShare.None);

        var buffer = new byte[81920];
        long downloadedBytes = 0;
        int read;

        while ((read = await contentStream.ReadAsync(buffer.AsMemory(0, buffer.Length), cancellationToken)) > 0)
        {
            await fileStream.WriteAsync(buffer.AsMemory(0, read), cancellationToken);
            downloadedBytes += read;

            if (totalBytes.HasValue && totalBytes.Value > 0)
            {
                var percent = (int)Math.Clamp(downloadedBytes * 100d / totalBytes.Value, 0, 100);
                setProgress(percent);
                setStatus($"FFmpeg indiriliyor... %{percent}");
            }
            else
            {
                setStatus($"FFmpeg indiriliyor... {downloadedBytes / (1024 * 1024)} MB");
            }
        }
    }

    private static string ResolveFfmpegPath()
    {
        var local = Path.Combine(AppContext.BaseDirectory, "ffmpeg.exe");
        if (File.Exists(local))
        {
            return local;
        }

        var rootLocal = Path.Combine(AppContext.BaseDirectory, "ffmpeg", "ffmpeg.exe");
        if (File.Exists(rootLocal))
        {
            return rootLocal;
        }

        return "ffmpeg";
    }

    private static void TryDeleteFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        catch
        {
            // Cleanup best effort.
        }
    }
}
