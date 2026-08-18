using System.Diagnostics;
using VideoCodec.Models;
using VideoCodec.Services;
using VideoCodec.Strategies;

namespace VideoCodec
{
    public partial class Form1 : Form
    {
        private readonly FfmpegService _ffmpegService = new();
        private readonly OpenFileDialog _videoPicker = new()
        {
            Filter = "Video Files|*.mp4;*.avi;*.mkv;*.mov;*.webm;*.flv|All files|*.*"
        };

        private readonly OpenFileDialog _audioPicker = new()
        {
            Filter = "Audio Files|*.mp3;*.aac;*.wav;*.m4a;*.flac|All files|*.*"
        };

        private CancellationTokenSource? _cts;
        private string _inputVideoPath = string.Empty;
        private TimeSpan _inputDuration = TimeSpan.Zero;
        private bool _ffmpegDownloadInProgress;

        public Form1()
        {
            InitializeComponent();
            InitializeDefaults();
            InitializeDragDrop();
            ApplyModernStyling();
        }

        // Arayüzdeki varsayılan seçenekleri (codec, çözünürlük, FPS vb.) ve varsayılan çıktı klasörünü hazırlar.
        private void InitializeDefaults()
        {
            cmbFormat.Items.AddRange(["mp4", "avi", "mkv", "mov", "webm", "flv"]);
            cmbFormat.SelectedItem = "mp4";

            cmbVideoCodec.Items.AddRange(VideoCodecStrategyFactory.GetStrategyNames().ToArray());
            cmbVideoCodec.SelectedItem = "H.264";

            cmbResolution.Items.AddRange(["Kaynak ile Aynı", "720p", "1080p", "4K"]);
            cmbResolution.SelectedItem = "1080p";

            cmbFrameRate.Items.AddRange(["Kaynak ile Aynı", "24", "30", "60"]);
            cmbFrameRate.SelectedItem = "30";

            cmbAudioCodec.Items.AddRange(AudioCodecStrategyFactory.GetStrategyNames().ToArray());
            cmbAudioCodec.SelectedItem = "AAC";

            cmbAudioBitrate.Items.AddRange(["96k", "128k", "192k", "256k", "320k"]);
            cmbAudioBitrate.SelectedItem = "128k";

            cmbAudioOutput.Items.AddRange(["mp3", "aac", "wav"]);
            cmbAudioOutput.SelectedItem = "mp3";

            var defaultOut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "Dönüştürülen Videolar");
            Directory.CreateDirectory(defaultOut);
            txtOutputFolder.Text = defaultOut;
            txtOutputName.Text = "dönüştürülen_video";
        }

        private async void btnChooseInput_Click(object sender, EventArgs e)
        {
            if (_videoPicker.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            await LoadInputVideoAsync(_videoPicker.FileName);
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using var folderPicker = new FolderBrowserDialog
            {
                Description = "Çıkış klasörünü seçin."
            };

            if (folderPicker.ShowDialog(this) == DialogResult.OK)
            {
                txtOutputFolder.Text = folderPicker.SelectedPath;
            }
        }

        private void cmbFormat_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOutputName.Text) || string.IsNullOrWhiteSpace(_inputVideoPath))
            {
                return;
            }

            txtOutputName.Text = Path.GetFileNameWithoutExtension(_inputVideoPath) + "_dönüştürülen";
        }

        // Video dönüştürme sürecini tetikler; seçilen ayarlara göre FFmpeg komutunu oluşturup işlemi çalıştırır.
        private async void btnConvert_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            await ExecuteOperationAsync(
                "Dönüştürme başlatıldı...",
                "İşlem kullanıcı tarafından iptal edildi.",
                "Dönüştürme Hatası",
                async token =>
                {
                    await EnsureFfmpegInstalledAsync(token);
                    var outputFile = GetOutputPath();
                    Directory.CreateDirectory(txtOutputFolder.Text.Trim());
                    var request = BuildProcessRequest(outputFile);
                    var args = VideoProcessStrategyFactory.Resolve("VideoDönüştür").BuildArguments(request);
                    await RunFfmpegAsync(args, token);
                    SetProgressSafe(100);
                    SetStatusSafe($"Tamamlandı: {outputFile}");

                    if (!chkOpenFolder.Checked)
                    {
                        return;
                    }

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "explorer.exe",
                        Arguments = $"\"{txtOutputFolder.Text.Trim()}\"",
                        UseShellExecute = true
                    });
                });
        }

        private async void btnExtractAudio_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            using var saver = new SaveFileDialog
            {
                Title = "Sesi Kaydet",
                InitialDirectory = txtOutputFolder.Text.Trim(),
                FileName = $"{Path.GetFileNameWithoutExtension(_inputVideoPath)}_ses.{cmbAudioOutput.SelectedItem}",
                Filter = "Audio files|*.mp3;*.aac;*.wav|All files|*.*"
            };

            if (saver.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            await ExecuteOperationAsync(
                "Ses ayrıştırılıyor...",
                "Ses ayırma iptal edildi.",
                "Ses Ayırma Hatası",
                async token =>
                {
                    await EnsureFfmpegInstalledAsync(token);
                    var request = BuildProcessRequest(saver.FileName, audioOutputFormat: cmbAudioOutput.SelectedItem?.ToString() ?? "mp3");
                    var args = VideoProcessStrategyFactory.Resolve("SesAyır").BuildArguments(request);
                    await RunFfmpegAsync(args, token);
                    SetProgressSafe(100);
                    SetStatusSafe($"Ses kaydedildi: {saver.FileName}");
                });
        }

        private async void btnAddOrReplaceAudio_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            if (_audioPicker.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var outputFile = Path.Combine(txtOutputFolder.Text.Trim(), $"{txtOutputName.Text.Trim()}_ses_değiştirildi.{cmbFormat.SelectedItem}");
            await ExecuteOperationAsync(
                "Video sesi değiştiriliyor...",
                "Ses ekleme/değiştirme iptal edildi.",
                "Ses Ekleme Hatası",
                async token =>
                {
                    await EnsureFfmpegInstalledAsync(token);
                    var request = BuildProcessRequest(outputFile, extraAudioInputPath: _audioPicker.FileName);
                    var args = VideoProcessStrategyFactory.Resolve("SesDeğiştir").BuildArguments(request);
                    await RunFfmpegAsync(args, token);
                    SetProgressSafe(100);
                    SetStatusSafe($"Yeni sesli video oluşturuldu: {outputFile}");
                });
        }

        // İşlem başlatılmadan önce kaynak video, çıktı klasörü ve dosya adı bilgilerinin eksiksiz olduğunu doğrular.
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_inputVideoPath) || !File.Exists(_inputVideoPath))
            {
                MessageBox.Show(this, "Lütfen önce bir video seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtOutputFolder.Text))
            {
                MessageBox.Show(this, "Lütfen çıkış klasörü seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtOutputName.Text))
            {
                MessageBox.Show(this, "Lütfen çıkış dosya adını girin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string GetOutputPath()
        {
            var format = cmbFormat.SelectedItem?.ToString() ?? "mp4";
            return Path.Combine(txtOutputFolder.Text.Trim(), $"{txtOutputName.Text.Trim()}.{format}");
        }

        private VideoProcessRequest BuildProcessRequest(
            string outputPath,
            string? audioOutputFormat = null,
            string? extraAudioInputPath = null)
        {
            return new VideoProcessRequest
            {
                InputVideoPath = _inputVideoPath,
                OutputPath = outputPath,
                ExtraAudioInputPath = extraAudioInputPath,
                SelectedVideoCodec = cmbVideoCodec.SelectedItem?.ToString() ?? "H.264",
                SelectedAudioCodec = cmbAudioCodec.SelectedItem?.ToString() ?? "AAC",
                AudioOutputFormat = audioOutputFormat ?? (cmbAudioOutput.SelectedItem?.ToString() ?? "mp3"),
                VideoBitrateKbps = (int)numVideoBitrate.Value,
                AudioBitrate = cmbAudioBitrate.SelectedItem?.ToString() ?? "128k",
                SelectedResolution = cmbResolution.SelectedItem?.ToString() ?? "Kaynak ile Aynı",
                SelectedFrameRate = cmbFrameRate.SelectedItem?.ToString() ?? "Kaynak ile Aynı"
            };
        }

        private void ToggleBusyUi(bool isBusy)
        {
            btnConvert.Enabled = !isBusy;
            btnChooseInput.Enabled = !isBusy;
            btnExtractAudio.Enabled = !isBusy;
            btnAddOrReplaceAudio.Enabled = !isBusy;
            btnBrowseOutput.Enabled = !isBusy;
            btnCancel.Enabled = isBusy;
        }

        private async Task<string> GetMediaDetailsAsync(string inputFile, CancellationToken cancellationToken)
        {
            await EnsureFfmpegInstalledAsync(cancellationToken);
            var result = await _ffmpegService.ProbeMediaAsync(inputFile, cancellationToken);
            _inputDuration = result.Duration;
            return MediaInfoParser.BuildDisplayText(inputFile, result);
        }

        private async Task RunFfmpegAsync(string args, CancellationToken cancellationToken)
        {
            await _ffmpegService.RunAsync(
                args,
                _inputDuration,
                progress => SetProgressWithStatus($"Dönüştürülüyor... %{progress}", progress),
                cancellationToken);
        }

        // Seçilen videonun yolunu alır, medya bilgilerini asenkron olarak ayrıştırır ve arayüzü işleme hazırlar.
        private async Task LoadInputVideoAsync(string path)
        {
            ToggleBusyUi(true);
            progressConversion.Value = 0;
            _cts = new CancellationTokenSource();

            try
            {
                _inputVideoPath = path;
                txtInputPath.Text = _inputVideoPath;
                txtOutputName.Text = Path.GetFileNameWithoutExtension(_inputVideoPath) + "_dönüştürülen";
                lblStatus.Text = "Video bilgileri okunuyor...";
                txtInputDetails.Text = await GetMediaDetailsAsync(_inputVideoPath, _cts.Token);
                lblStatus.Text = "Hazır.";
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Video yükleme / FFmpeg kurulum işlemi iptal edildi.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Hata: {ex.Message}";
                MessageBox.Show(this, ex.Message, "Video Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusyUi(false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        // Sistemde FFmpeg yoksa kullanıcıdan onay alarak otomatik indirme ve kurulum sürecini başlatır.
        private async Task EnsureFfmpegInstalledAsync(CancellationToken cancellationToken)
        {
            if (_ffmpegService.IsFfmpegAvailable())
            {
                return;
            }

            var answer = MessageBox.Show(
                this,
                "FFmpeg bulunamadı. Şimdi otomatik indirip kuralım mı?",
                "FFmpeg Gerekli",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                throw new InvalidOperationException("FFmpeg gerekli olduğu için işlem başlatılamadı.");
            }

            lblStatus.Text = "FFmpeg indiriliyor...";
            _ffmpegDownloadInProgress = true;
            try
            {
                await _ffmpegService.DownloadAndInstallFfmpegAsync(cancellationToken, SetStatusSafe, SetProgressSafe);
                lblStatus.Text = "FFmpeg kurulumu tamamlandı.";
            }
            finally
            {
                _ffmpegDownloadInProgress = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            if (_ffmpegDownloadInProgress)
            {
                lblStatus.Text = "FFmpeg indirme iptal ediliyor...";
            }
        }

        // Asenkron işlemleri güvenli şekilde çalıştırır; UI kilitleme, iptal (cancellation) ve hata yönetimini ele alır.
        private async Task ExecuteOperationAsync(
            string startStatus,
            string cancelledStatus,
            string errorTitle,
            Func<CancellationToken, Task> operation)
        {
            ToggleBusyUi(true);
            _cts = new CancellationTokenSource();
            SetProgressSafe(0);
            SetStatusSafe(startStatus);

            try
            {
                await operation(_cts.Token);
            }
            catch (OperationCanceledException)
            {
                SetStatusSafe(cancelledStatus);
            }
            catch (Exception ex)
            {
                SetStatusSafe($"Hata: {ex.Message}");
                MessageBox.Show(this, ex.Message, errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusyUi(false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        private void SetProgressWithStatus(string status, int progress)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    progressConversion.Value = progress;
                    lblStatus.Text = status;
                }));
                return;
            }

            progressConversion.Value = progress;
            lblStatus.Text = status;
        }

        // Arka plan iş parçacıklarından gelen ilerleme bilgisini arayüze thread-safe (güvenli) şekilde aktarır.
        private void SetProgressSafe(int value)
        {
            value = Math.Clamp(value, 0, 100);
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => progressConversion.Value = value));
            }
            else
            {
                progressConversion.Value = value;
            }
        }

        private void SetStatusSafe(string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => lblStatus.Text = text));
            }
            else
            {
                lblStatus.Text = text;
            }
        }

    }
}
