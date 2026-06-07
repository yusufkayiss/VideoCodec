using System.Drawing.Drawing2D;

namespace VideoCodec
{
    public partial class Form1
    {
        private void InitializeDragDrop()
        {
            AllowDrop = true;
            panelSource.AllowDrop = true;
            txtInputPath.AllowDrop = true;

            DragEnter += Form_DragEnter;
            DragDrop += Form_DragDrop;
            panelSource.DragEnter += Form_DragEnter;
            panelSource.DragDrop += Form_DragDrop;
            txtInputPath.DragEnter += Form_DragEnter;
            txtInputPath.DragDrop += Form_DragDrop;
        }

        private void Form_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0 && IsSupportedVideoFile(files[0]))
            {
                e.Effect = DragDropEffects.Copy;
                lblStatus.Text = "Videoyu bırakabilirsiniz...";
                return;
            }

            e.Effect = DragDropEffects.None;
        }

        private async void Form_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is not string[] files || files.Length == 0)
            {
                return;
            }

            var firstVideo = files.FirstOrDefault(IsSupportedVideoFile);
            if (firstVideo is null)
            {
                MessageBox.Show(this, "Desteklenen bir video dosyası bırakın (mp4, avi, mkv, mov, webm, flv).", "Geçersiz Dosya", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await LoadInputVideoAsync(firstVideo);
        }

        private static bool IsSupportedVideoFile(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext is ".mp4" or ".avi" or ".mkv" or ".mov" or ".webm" or ".flv";
        }

        private void ApplyModernStyling()
        {
            StyleCard(panelSource);
            StyleCard(panelSettings);
            StyleCard(panelOutput);
            StyleCard(panelActions);

            StyleButton(btnChooseInput, Color.FromArgb(58, 123, 255));
            StyleButton(btnExtractAudio, Color.FromArgb(38, 190, 138));
            StyleButton(btnAddOrReplaceAudio, Color.FromArgb(103, 92, 228));
            StyleButton(btnConvert, Color.FromArgb(32, 199, 151));
            StyleButton(btnCancel, Color.FromArgb(210, 70, 94));
            StyleButton(btnBrowseOutput, Color.FromArgb(68, 82, 112));

            foreach (var cmb in new[] { cmbFormat, cmbVideoCodec, cmbResolution, cmbFrameRate, cmbAudioCodec, cmbAudioBitrate, cmbAudioOutput })
            {
                cmb.FlatStyle = FlatStyle.Flat;
                cmb.BackColor = Color.FromArgb(18, 29, 44);
                cmb.ForeColor = Color.WhiteSmoke;
            }
        }

        private static void StyleCard(Control control)
        {
            control.Padding = new Padding(10);
        }

        private static void StyleButton(Button button, Color baseColor)
        {
            button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(baseColor, 0.12f);
            button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(baseColor, 0.14f);
            button.BackColor = baseColor;
            button.Cursor = Cursors.Hand;
            button.Region = new Region(CreateRoundedPath(button.ClientRectangle, 10));
            button.SizeChanged += (_, _) => button.Region = new Region(CreateRoundedPath(button.ClientRectangle, 10));
        }

        private static GraphicsPath CreateRoundedPath(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                return path;
            }

            var diameter = radius * 2;
            var arc = new Rectangle(bounds.Location, new Size(diameter, diameter));
            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
