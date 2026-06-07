namespace VideoCodec
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelSource = new Panel();
            lblInputDetails = new Label();
            txtInputDetails = new TextBox();
            btnChooseInput = new Button();
            txtInputPath = new TextBox();
            lblSourceTitle = new Label();
            panelSettings = new Panel();
            btnAddOrReplaceAudio = new Button();
            btnExtractAudio = new Button();
            cmbAudioOutput = new ComboBox();
            lblAudioOutput = new Label();
            cmbAudioBitrate = new ComboBox();
            lblAudioBitrate = new Label();
            cmbAudioCodec = new ComboBox();
            lblAudioCodec = new Label();
            cmbResolution = new ComboBox();
            lblResolution = new Label();
            cmbFrameRate = new ComboBox();
            lblFrameRate = new Label();
            numVideoBitrate = new NumericUpDown();
            lblVideoBitrate = new Label();
            cmbVideoCodec = new ComboBox();
            lblVideoCodec = new Label();
            cmbFormat = new ComboBox();
            lblFormat = new Label();
            lblSettingsTitle = new Label();
            panelOutput = new Panel();
            chkOpenFolder = new CheckBox();
            btnBrowseOutput = new Button();
            txtOutputName = new TextBox();
            lblOutputName = new Label();
            txtOutputFolder = new TextBox();
            lblOutputFolder = new Label();
            lblOutputTitle = new Label();
            panelActions = new Panel();
            lblStatus = new Label();
            progressConversion = new ProgressBar();
            btnCancel = new Button();
            btnConvert = new Button();
            ((System.ComponentModel.ISupportInitialize)numVideoBitrate).BeginInit();
            SuspendLayout();
            // 
            // panelSource
            // 
            panelSource.BackColor = Color.FromArgb(24, 36, 55);
            panelSource.BorderStyle = BorderStyle.FixedSingle;
            panelSource.Controls.Add(lblInputDetails);
            panelSource.Controls.Add(txtInputDetails);
            panelSource.Controls.Add(btnChooseInput);
            panelSource.Controls.Add(txtInputPath);
            panelSource.Controls.Add(lblSourceTitle);
            panelSource.Location = new Point(18, 18);
            panelSource.Name = "panelSource";
            panelSource.Size = new Size(350, 320);
            panelSource.TabIndex = 0;
            // 
            // lblInputDetails
            // 
            lblInputDetails.AutoSize = true;
            lblInputDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInputDetails.ForeColor = Color.WhiteSmoke;
            lblInputDetails.Location = new Point(17, 92);
            lblInputDetails.Name = "lblInputDetails";
            lblInputDetails.Size = new Size(96, 23);
            lblInputDetails.TabIndex = 4;
            lblInputDetails.Text = "Girdi Bilgisi";
            // 
            // txtInputDetails
            // 
            txtInputDetails.BackColor = Color.FromArgb(14, 24, 38);
            txtInputDetails.BorderStyle = BorderStyle.FixedSingle;
            txtInputDetails.ForeColor = Color.Gainsboro;
            txtInputDetails.Location = new Point(17, 120);
            txtInputDetails.Multiline = true;
            txtInputDetails.Name = "txtInputDetails";
            txtInputDetails.ReadOnly = true;
            txtInputDetails.ScrollBars = ScrollBars.Vertical;
            txtInputDetails.Size = new Size(315, 180);
            txtInputDetails.TabIndex = 3;
            // 
            // btnChooseInput
            // 
            btnChooseInput.BackColor = Color.FromArgb(50, 115, 220);
            btnChooseInput.FlatAppearance.BorderSize = 0;
            btnChooseInput.FlatStyle = FlatStyle.Flat;
            btnChooseInput.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChooseInput.ForeColor = Color.White;
            btnChooseInput.Location = new Point(17, 45);
            btnChooseInput.Name = "btnChooseInput";
            btnChooseInput.Size = new Size(130, 36);
            btnChooseInput.TabIndex = 2;
            btnChooseInput.Text = "Video Seç";
            btnChooseInput.UseVisualStyleBackColor = false;
            btnChooseInput.Click += btnChooseInput_Click;
            // 
            // txtInputPath
            // 
            txtInputPath.BackColor = Color.FromArgb(14, 24, 38);
            txtInputPath.BorderStyle = BorderStyle.FixedSingle;
            txtInputPath.ForeColor = Color.Gainsboro;
            txtInputPath.Location = new Point(153, 51);
            txtInputPath.Name = "txtInputPath";
            txtInputPath.ReadOnly = true;
            txtInputPath.Size = new Size(179, 27);
            txtInputPath.TabIndex = 1;
            // 
            // lblSourceTitle
            // 
            lblSourceTitle.AutoSize = true;
            lblSourceTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSourceTitle.ForeColor = Color.White;
            lblSourceTitle.Location = new Point(14, 12);
            lblSourceTitle.Name = "lblSourceTitle";
            lblSourceTitle.Size = new Size(131, 25);
            lblSourceTitle.TabIndex = 0;
            lblSourceTitle.Text = "1. VİDEO SEÇ";
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.FromArgb(24, 36, 55);
            panelSettings.BorderStyle = BorderStyle.FixedSingle;
            panelSettings.Controls.Add(btnAddOrReplaceAudio);
            panelSettings.Controls.Add(btnExtractAudio);
            panelSettings.Controls.Add(cmbAudioOutput);
            panelSettings.Controls.Add(lblAudioOutput);
            panelSettings.Controls.Add(cmbAudioBitrate);
            panelSettings.Controls.Add(lblAudioBitrate);
            panelSettings.Controls.Add(cmbAudioCodec);
            panelSettings.Controls.Add(lblAudioCodec);
            panelSettings.Controls.Add(cmbResolution);
            panelSettings.Controls.Add(lblResolution);
            panelSettings.Controls.Add(cmbFrameRate);
            panelSettings.Controls.Add(lblFrameRate);
            panelSettings.Controls.Add(numVideoBitrate);
            panelSettings.Controls.Add(lblVideoBitrate);
            panelSettings.Controls.Add(cmbVideoCodec);
            panelSettings.Controls.Add(lblVideoCodec);
            panelSettings.Controls.Add(cmbFormat);
            panelSettings.Controls.Add(lblFormat);
            panelSettings.Controls.Add(lblSettingsTitle);
            panelSettings.Location = new Point(379, 18);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(420, 430);
            panelSettings.TabIndex = 1;
            // 
            // btnAddOrReplaceAudio
            // 
            btnAddOrReplaceAudio.BackColor = Color.FromArgb(89, 82, 216);
            btnAddOrReplaceAudio.FlatAppearance.BorderSize = 0;
            btnAddOrReplaceAudio.FlatStyle = FlatStyle.Flat;
            btnAddOrReplaceAudio.ForeColor = Color.White;
            btnAddOrReplaceAudio.Location = new Point(215, 381);
            btnAddOrReplaceAudio.Name = "btnAddOrReplaceAudio";
            btnAddOrReplaceAudio.Size = new Size(186, 33);
            btnAddOrReplaceAudio.TabIndex = 18;
            btnAddOrReplaceAudio.Text = "Sesi Ekle / Değiştir";
            btnAddOrReplaceAudio.UseVisualStyleBackColor = false;
            btnAddOrReplaceAudio.Click += btnAddOrReplaceAudio_Click;
            // 
            // btnExtractAudio
            // 
            btnExtractAudio.BackColor = Color.FromArgb(34, 182, 132);
            btnExtractAudio.FlatAppearance.BorderSize = 0;
            btnExtractAudio.FlatStyle = FlatStyle.Flat;
            btnExtractAudio.ForeColor = Color.White;
            btnExtractAudio.Location = new Point(23, 381);
            btnExtractAudio.Name = "btnExtractAudio";
            btnExtractAudio.Size = new Size(184, 33);
            btnExtractAudio.TabIndex = 17;
            btnExtractAudio.Text = "Sesi Ayrıştır";
            btnExtractAudio.UseVisualStyleBackColor = false;
            btnExtractAudio.Click += btnExtractAudio_Click;
            // 
            // cmbAudioOutput
            // 
            cmbAudioOutput.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAudioOutput.FormattingEnabled = true;
            cmbAudioOutput.Location = new Point(215, 338);
            cmbAudioOutput.Name = "cmbAudioOutput";
            cmbAudioOutput.Size = new Size(186, 28);
            cmbAudioOutput.TabIndex = 16;
            // 
            // lblAudioOutput
            // 
            lblAudioOutput.AutoSize = true;
            lblAudioOutput.ForeColor = Color.WhiteSmoke;
            lblAudioOutput.Location = new Point(215, 315);
            lblAudioOutput.Name = "lblAudioOutput";
            lblAudioOutput.Size = new Size(86, 20);
            lblAudioOutput.TabIndex = 15;
            lblAudioOutput.Text = "Ses Formatı";
            // 
            // cmbAudioBitrate
            // 
            cmbAudioBitrate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAudioBitrate.FormattingEnabled = true;
            cmbAudioBitrate.Location = new Point(23, 338);
            cmbAudioBitrate.Name = "cmbAudioBitrate";
            cmbAudioBitrate.Size = new Size(184, 28);
            cmbAudioBitrate.TabIndex = 14;
            // 
            // lblAudioBitrate
            // 
            lblAudioBitrate.AutoSize = true;
            lblAudioBitrate.ForeColor = Color.WhiteSmoke;
            lblAudioBitrate.Location = new Point(23, 315);
            lblAudioBitrate.Name = "lblAudioBitrate";
            lblAudioBitrate.Size = new Size(77, 20);
            lblAudioBitrate.TabIndex = 13;
            lblAudioBitrate.Text = "Ses Bit Hızı";
            // 
            // cmbAudioCodec
            // 
            cmbAudioCodec.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAudioCodec.FormattingEnabled = true;
            cmbAudioCodec.Location = new Point(215, 276);
            cmbAudioCodec.Name = "cmbAudioCodec";
            cmbAudioCodec.Size = new Size(186, 28);
            cmbAudioCodec.TabIndex = 12;
            // 
            // lblAudioCodec
            // 
            lblAudioCodec.AutoSize = true;
            lblAudioCodec.ForeColor = Color.WhiteSmoke;
            lblAudioCodec.Location = new Point(215, 253);
            lblAudioCodec.Name = "lblAudioCodec";
            lblAudioCodec.Size = new Size(79, 20);
            lblAudioCodec.TabIndex = 11;
            lblAudioCodec.Text = "Ses Codec'i";
            // 
            // cmbResolution
            // 
            cmbResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResolution.FormattingEnabled = true;
            cmbResolution.Location = new Point(23, 214);
            cmbResolution.Name = "cmbResolution";
            cmbResolution.Size = new Size(184, 28);
            cmbResolution.TabIndex = 10;
            // 
            // lblResolution
            // 
            lblResolution.AutoSize = true;
            lblResolution.ForeColor = Color.WhiteSmoke;
            lblResolution.Location = new Point(23, 191);
            lblResolution.Name = "lblResolution";
            lblResolution.Size = new Size(83, 20);
            lblResolution.TabIndex = 9;
            lblResolution.Text = "Çözünürlük";
            // 
            // cmbFrameRate
            // 
            cmbFrameRate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFrameRate.FormattingEnabled = true;
            cmbFrameRate.Location = new Point(215, 214);
            cmbFrameRate.Name = "cmbFrameRate";
            cmbFrameRate.Size = new Size(186, 28);
            cmbFrameRate.TabIndex = 8;
            // 
            // lblFrameRate
            // 
            lblFrameRate.AutoSize = true;
            lblFrameRate.ForeColor = Color.WhiteSmoke;
            lblFrameRate.Location = new Point(215, 191);
            lblFrameRate.Name = "lblFrameRate";
            lblFrameRate.Size = new Size(79, 20);
            lblFrameRate.TabIndex = 7;
            lblFrameRate.Text = "Kare Hızı";
            // 
            // numVideoBitrate
            // 
            numVideoBitrate.Location = new Point(23, 152);
            numVideoBitrate.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numVideoBitrate.Minimum = new decimal(new int[] { 250, 0, 0, 0 });
            numVideoBitrate.Name = "numVideoBitrate";
            numVideoBitrate.Size = new Size(184, 27);
            numVideoBitrate.TabIndex = 6;
            numVideoBitrate.Value = new decimal(new int[] { 2500, 0, 0, 0 });
            // 
            // lblVideoBitrate
            // 
            lblVideoBitrate.AutoSize = true;
            lblVideoBitrate.ForeColor = Color.WhiteSmoke;
            lblVideoBitrate.Location = new Point(23, 129);
            lblVideoBitrate.Name = "lblVideoBitrate";
            lblVideoBitrate.Size = new Size(95, 20);
            lblVideoBitrate.TabIndex = 5;
            lblVideoBitrate.Text = "Video Bit Hızı";
            // 
            // cmbVideoCodec
            // 
            cmbVideoCodec.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVideoCodec.FormattingEnabled = true;
            cmbVideoCodec.Location = new Point(215, 90);
            cmbVideoCodec.Name = "cmbVideoCodec";
            cmbVideoCodec.Size = new Size(186, 28);
            cmbVideoCodec.TabIndex = 4;
            // 
            // lblVideoCodec
            // 
            lblVideoCodec.AutoSize = true;
            lblVideoCodec.ForeColor = Color.WhiteSmoke;
            lblVideoCodec.Location = new Point(215, 67);
            lblVideoCodec.Name = "lblVideoCodec";
            lblVideoCodec.Size = new Size(97, 20);
            lblVideoCodec.TabIndex = 3;
            lblVideoCodec.Text = "Video Codec'i";
            // 
            // cmbFormat
            // 
            cmbFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormat.FormattingEnabled = true;
            cmbFormat.Location = new Point(23, 90);
            cmbFormat.Name = "cmbFormat";
            cmbFormat.Size = new Size(184, 28);
            cmbFormat.TabIndex = 2;
            cmbFormat.SelectedIndexChanged += cmbFormat_SelectedIndexChanged;
            // 
            // lblFormat
            // 
            lblFormat.AutoSize = true;
            lblFormat.ForeColor = Color.WhiteSmoke;
            lblFormat.Location = new Point(23, 67);
            lblFormat.Name = "lblFormat";
            lblFormat.Size = new Size(53, 20);
            lblFormat.TabIndex = 1;
            lblFormat.Text = "Biçim";
            // 
            // lblSettingsTitle
            // 
            lblSettingsTitle.AutoSize = true;
            lblSettingsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSettingsTitle.ForeColor = Color.White;
            lblSettingsTitle.Location = new Point(19, 16);
            lblSettingsTitle.Name = "lblSettingsTitle";
            lblSettingsTitle.Size = new Size(210, 25);
            lblSettingsTitle.TabIndex = 0;
            lblSettingsTitle.Text = "2. DÖNÜŞÜM AYARLARI";
            // 
            // panelOutput
            // 
            panelOutput.BackColor = Color.FromArgb(24, 36, 55);
            panelOutput.BorderStyle = BorderStyle.FixedSingle;
            panelOutput.Controls.Add(chkOpenFolder);
            panelOutput.Controls.Add(btnBrowseOutput);
            panelOutput.Controls.Add(txtOutputName);
            panelOutput.Controls.Add(lblOutputName);
            panelOutput.Controls.Add(txtOutputFolder);
            panelOutput.Controls.Add(lblOutputFolder);
            panelOutput.Controls.Add(lblOutputTitle);
            panelOutput.Location = new Point(18, 349);
            panelOutput.Name = "panelOutput";
            panelOutput.Size = new Size(350, 199);
            panelOutput.TabIndex = 2;
            // 
            // chkOpenFolder
            // 
            chkOpenFolder.AutoSize = true;
            chkOpenFolder.Checked = true;
            chkOpenFolder.CheckState = CheckState.Checked;
            chkOpenFolder.ForeColor = Color.Gainsboro;
            chkOpenFolder.Location = new Point(17, 154);
            chkOpenFolder.Name = "chkOpenFolder";
            chkOpenFolder.Size = new Size(237, 24);
            chkOpenFolder.TabIndex = 6;
            chkOpenFolder.Text = "İşlem bitince klasörü otomatik aç";
            chkOpenFolder.UseVisualStyleBackColor = true;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.BackColor = Color.FromArgb(52, 63, 83);
            btnBrowseOutput.FlatAppearance.BorderSize = 0;
            btnBrowseOutput.FlatStyle = FlatStyle.Flat;
            btnBrowseOutput.ForeColor = Color.WhiteSmoke;
            btnBrowseOutput.Location = new Point(262, 68);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(70, 27);
            btnBrowseOutput.TabIndex = 5;
            btnBrowseOutput.Text = "Gözat";
            btnBrowseOutput.UseVisualStyleBackColor = false;
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // txtOutputName
            // 
            txtOutputName.BackColor = Color.FromArgb(14, 24, 38);
            txtOutputName.BorderStyle = BorderStyle.FixedSingle;
            txtOutputName.ForeColor = Color.Gainsboro;
            txtOutputName.Location = new Point(17, 126);
            txtOutputName.Name = "txtOutputName";
            txtOutputName.Size = new Size(315, 27);
            txtOutputName.TabIndex = 4;
            // 
            // lblOutputName
            // 
            lblOutputName.AutoSize = true;
            lblOutputName.ForeColor = Color.WhiteSmoke;
            lblOutputName.Location = new Point(17, 103);
            lblOutputName.Name = "lblOutputName";
            lblOutputName.Size = new Size(93, 20);
            lblOutputName.TabIndex = 3;
            lblOutputName.Text = "Dosya Adı";
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.BackColor = Color.FromArgb(14, 24, 38);
            txtOutputFolder.BorderStyle = BorderStyle.FixedSingle;
            txtOutputFolder.ForeColor = Color.Gainsboro;
            txtOutputFolder.Location = new Point(17, 68);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.Size = new Size(239, 27);
            txtOutputFolder.TabIndex = 2;
            // 
            // lblOutputFolder
            // 
            lblOutputFolder.AutoSize = true;
            lblOutputFolder.ForeColor = Color.WhiteSmoke;
            lblOutputFolder.Location = new Point(17, 45);
            lblOutputFolder.Name = "lblOutputFolder";
            lblOutputFolder.Size = new Size(95, 20);
            lblOutputFolder.TabIndex = 1;
            lblOutputFolder.Text = "Çıkış Klasörü";
            // 
            // lblOutputTitle
            // 
            lblOutputTitle.AutoSize = true;
            lblOutputTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOutputTitle.ForeColor = Color.White;
            lblOutputTitle.Location = new Point(14, 12);
            lblOutputTitle.Name = "lblOutputTitle";
            lblOutputTitle.Size = new Size(115, 25);
            lblOutputTitle.TabIndex = 0;
            lblOutputTitle.Text = "3. KAYDET";
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(24, 36, 55);
            panelActions.BorderStyle = BorderStyle.FixedSingle;
            panelActions.Controls.Add(lblStatus);
            panelActions.Controls.Add(progressConversion);
            panelActions.Controls.Add(btnCancel);
            panelActions.Controls.Add(btnConvert);
            panelActions.Location = new Point(810, 18);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(378, 530);
            panelActions.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.Gainsboro;
            lblStatus.Location = new Point(18, 244);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(342, 110);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Hazır.";
            // 
            // progressConversion
            // 
            progressConversion.Location = new Point(18, 207);
            progressConversion.Name = "progressConversion";
            progressConversion.Size = new Size(342, 25);
            progressConversion.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(170, 53, 80);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(18, 93);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(342, 46);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConvert
            // 
            btnConvert.BackColor = Color.FromArgb(34, 182, 132);
            btnConvert.FlatAppearance.BorderSize = 0;
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConvert.ForeColor = Color.White;
            btnConvert.Location = new Point(18, 35);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(342, 46);
            btnConvert.TabIndex = 0;
            btnConvert.Text = "Dönüştür";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(10, 18, 30);
            ClientSize = new Size(1206, 570);
            Controls.Add(panelActions);
            Controls.Add(panelOutput);
            Controls.Add(panelSettings);
            Controls.Add(panelSource);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Video Format ve Codec Dönüştürücü v2.1";
            ((System.ComponentModel.ISupportInitialize)numVideoBitrate).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSource;
        private Label lblInputDetails;
        private TextBox txtInputDetails;
        private Button btnChooseInput;
        private TextBox txtInputPath;
        private Label lblSourceTitle;
        private Panel panelSettings;
        private Button btnAddOrReplaceAudio;
        private Button btnExtractAudio;
        private ComboBox cmbAudioOutput;
        private Label lblAudioOutput;
        private ComboBox cmbAudioBitrate;
        private Label lblAudioBitrate;
        private ComboBox cmbAudioCodec;
        private Label lblAudioCodec;
        private ComboBox cmbResolution;
        private Label lblResolution;
        private ComboBox cmbFrameRate;
        private Label lblFrameRate;
        private NumericUpDown numVideoBitrate;
        private Label lblVideoBitrate;
        private ComboBox cmbVideoCodec;
        private Label lblVideoCodec;
        private ComboBox cmbFormat;
        private Label lblFormat;
        private Label lblSettingsTitle;
        private Panel panelOutput;
        private CheckBox chkOpenFolder;
        private Button btnBrowseOutput;
        private TextBox txtOutputName;
        private Label lblOutputName;
        private TextBox txtOutputFolder;
        private Label lblOutputFolder;
        private Label lblOutputTitle;
        private Panel panelActions;
        private Label lblStatus;
        private ProgressBar progressConversion;
        private Button btnCancel;
        private Button btnConvert;
    }
}
