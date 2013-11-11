namespace DotNET_Tests
{
    partial class AudioTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioTest));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.checkBoxLoopAsync = new System.Windows.Forms.CheckBox();
            this.groupBoxSoundPlayer = new System.Windows.Forms.GroupBox();
            this.buttonSoundPlayerPlayResource = new System.Windows.Forms.Button();
            this.buttonSoundPlayerStopAsync = new System.Windows.Forms.Button();
            this.buttonSoundPlayerAsync = new System.Windows.Forms.Button();
            this.buttonSoundPlayerSync = new System.Windows.Forms.Button();
            this.groupBoxPlaySound = new System.Windows.Forms.GroupBox();
            this.buttonStopAsync = new System.Windows.Forms.Button();
            this.buttonPlaySoundAsync = new System.Windows.Forms.Button();
            this.buttonPlaySoundSync = new System.Windows.Forms.Button();
            this.labelBasicFileName = new System.Windows.Forms.Label();
            this.textBoxBasicFileName = new System.Windows.Forms.TextBox();
            this.buttonBasicBrowse = new System.Windows.Forms.Button();
            this.tabPageWMP = new System.Windows.Forms.TabPage();
            this.labelWMPStatus = new System.Windows.Forms.Label();
            this.buttonPlaylist = new System.Windows.Forms.Button();
            this.labelWMPVersion = new System.Windows.Forms.Label();
            this.labelWMPFileName = new System.Windows.Forms.Label();
            this.textBoxWMPFileName = new System.Windows.Forms.TextBox();
            this.buttonWMPBrowse = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.tabPageDX = new System.Windows.Forms.TabPage();
            this.labelDXDevice = new System.Windows.Forms.Label();
            this.comboBoxDXDevice = new System.Windows.Forms.ComboBox();
            this.buttonDXPlay = new System.Windows.Forms.Button();
            this.labelDXFileName = new System.Windows.Forms.Label();
            this.textBoxDXFileName = new System.Windows.Forms.TextBox();
            this.buttonDXBrowse = new System.Windows.Forms.Button();
            this.openFileDialogWave = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStripPlaylist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.groupBoxSoundPlayer.SuspendLayout();
            this.groupBoxPlaySound.SuspendLayout();
            this.tabPageWMP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.tabPageDX.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageBasic);
            this.tabControl1.Controls.Add(this.tabPageWMP);
            this.tabControl1.Controls.Add(this.tabPageDX);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(361, 351);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.checkBoxLoopAsync);
            this.tabPageBasic.Controls.Add(this.groupBoxSoundPlayer);
            this.tabPageBasic.Controls.Add(this.groupBoxPlaySound);
            this.tabPageBasic.Controls.Add(this.labelBasicFileName);
            this.tabPageBasic.Controls.Add(this.textBoxBasicFileName);
            this.tabPageBasic.Controls.Add(this.buttonBasicBrowse);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 22);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(353, 325);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "Basic";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // checkBoxLoopAsync
            // 
            this.checkBoxLoopAsync.AutoSize = true;
            this.checkBoxLoopAsync.Location = new System.Drawing.Point(9, 35);
            this.checkBoxLoopAsync.Name = "checkBoxLoopAsync";
            this.checkBoxLoopAsync.Size = new System.Drawing.Size(82, 17);
            this.checkBoxLoopAsync.TabIndex = 1;
            this.checkBoxLoopAsync.Text = "Loop Async";
            this.checkBoxLoopAsync.UseVisualStyleBackColor = true;
            // 
            // groupBoxSoundPlayer
            // 
            this.groupBoxSoundPlayer.Controls.Add(this.buttonSoundPlayerPlayResource);
            this.groupBoxSoundPlayer.Controls.Add(this.buttonSoundPlayerStopAsync);
            this.groupBoxSoundPlayer.Controls.Add(this.buttonSoundPlayerAsync);
            this.groupBoxSoundPlayer.Controls.Add(this.buttonSoundPlayerSync);
            this.groupBoxSoundPlayer.Location = new System.Drawing.Point(9, 58);
            this.groupBoxSoundPlayer.Name = "groupBoxSoundPlayer";
            this.groupBoxSoundPlayer.Size = new System.Drawing.Size(338, 140);
            this.groupBoxSoundPlayer.TabIndex = 2;
            this.groupBoxSoundPlayer.TabStop = false;
            this.groupBoxSoundPlayer.Text = "System.Media.SoundPlayer";
            // 
            // buttonSoundPlayerPlayResource
            // 
            this.buttonSoundPlayerPlayResource.Location = new System.Drawing.Point(7, 80);
            this.buttonSoundPlayerPlayResource.Name = "buttonSoundPlayerPlayResource";
            this.buttonSoundPlayerPlayResource.Size = new System.Drawing.Size(323, 23);
            this.buttonSoundPlayerPlayResource.TabIndex = 2;
            this.buttonSoundPlayerPlayResource.Text = "Play Resource Async";
            this.buttonSoundPlayerPlayResource.UseVisualStyleBackColor = true;
            this.buttonSoundPlayerPlayResource.Click += new System.EventHandler(this.buttonSoundPlayerPlayResource_Click);
            // 
            // buttonSoundPlayerStopAsync
            // 
            this.buttonSoundPlayerStopAsync.Location = new System.Drawing.Point(6, 109);
            this.buttonSoundPlayerStopAsync.Name = "buttonSoundPlayerStopAsync";
            this.buttonSoundPlayerStopAsync.Size = new System.Drawing.Size(324, 23);
            this.buttonSoundPlayerStopAsync.TabIndex = 3;
            this.buttonSoundPlayerStopAsync.Text = "Stop Async";
            this.buttonSoundPlayerStopAsync.UseVisualStyleBackColor = true;
            this.buttonSoundPlayerStopAsync.Click += new System.EventHandler(this.buttonSoundPlayerStopAsync_Click);
            // 
            // buttonSoundPlayerAsync
            // 
            this.buttonSoundPlayerAsync.Location = new System.Drawing.Point(7, 50);
            this.buttonSoundPlayerAsync.Name = "buttonSoundPlayerAsync";
            this.buttonSoundPlayerAsync.Size = new System.Drawing.Size(324, 23);
            this.buttonSoundPlayerAsync.TabIndex = 1;
            this.buttonSoundPlayerAsync.Text = "Play Asynchronously";
            this.buttonSoundPlayerAsync.UseVisualStyleBackColor = true;
            this.buttonSoundPlayerAsync.Click += new System.EventHandler(this.buttonSoundPlayerAsync_Click);
            // 
            // buttonSoundPlayerSync
            // 
            this.buttonSoundPlayerSync.Location = new System.Drawing.Point(7, 20);
            this.buttonSoundPlayerSync.Name = "buttonSoundPlayerSync";
            this.buttonSoundPlayerSync.Size = new System.Drawing.Size(325, 23);
            this.buttonSoundPlayerSync.TabIndex = 0;
            this.buttonSoundPlayerSync.Text = "Play Synchronously";
            this.buttonSoundPlayerSync.UseVisualStyleBackColor = true;
            this.buttonSoundPlayerSync.Click += new System.EventHandler(this.buttonSoundPlayerSync_Click);
            // 
            // groupBoxPlaySound
            // 
            this.groupBoxPlaySound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPlaySound.Controls.Add(this.buttonStopAsync);
            this.groupBoxPlaySound.Controls.Add(this.buttonPlaySoundAsync);
            this.groupBoxPlaySound.Controls.Add(this.buttonPlaySoundSync);
            this.groupBoxPlaySound.Location = new System.Drawing.Point(9, 204);
            this.groupBoxPlaySound.Name = "groupBoxPlaySound";
            this.groupBoxPlaySound.Size = new System.Drawing.Size(338, 109);
            this.groupBoxPlaySound.TabIndex = 3;
            this.groupBoxPlaySound.TabStop = false;
            this.groupBoxPlaySound.Text = "PlaySound (Platform Invoke - winmm.dll)";
            // 
            // buttonStopAsync
            // 
            this.buttonStopAsync.Location = new System.Drawing.Point(6, 78);
            this.buttonStopAsync.Name = "buttonStopAsync";
            this.buttonStopAsync.Size = new System.Drawing.Size(325, 23);
            this.buttonStopAsync.TabIndex = 2;
            this.buttonStopAsync.Text = "Stop Async";
            this.buttonStopAsync.UseVisualStyleBackColor = true;
            this.buttonStopAsync.Click += new System.EventHandler(this.buttonStopAsync_Click);
            // 
            // buttonPlaySoundAsync
            // 
            this.buttonPlaySoundAsync.Location = new System.Drawing.Point(7, 49);
            this.buttonPlaySoundAsync.Name = "buttonPlaySoundAsync";
            this.buttonPlaySoundAsync.Size = new System.Drawing.Size(325, 23);
            this.buttonPlaySoundAsync.TabIndex = 1;
            this.buttonPlaySoundAsync.Text = "Play Asynchronously";
            this.buttonPlaySoundAsync.UseVisualStyleBackColor = true;
            this.buttonPlaySoundAsync.Click += new System.EventHandler(this.buttonPlaySoundAsync_Click);
            // 
            // buttonPlaySoundSync
            // 
            this.buttonPlaySoundSync.Location = new System.Drawing.Point(6, 19);
            this.buttonPlaySoundSync.Name = "buttonPlaySoundSync";
            this.buttonPlaySoundSync.Size = new System.Drawing.Size(326, 23);
            this.buttonPlaySoundSync.TabIndex = 0;
            this.buttonPlaySoundSync.Text = "Play Synchronously";
            this.buttonPlaySoundSync.UseVisualStyleBackColor = true;
            this.buttonPlaySoundSync.Click += new System.EventHandler(this.buttonPlaySoundSync_Click);
            // 
            // labelBasicFileName
            // 
            this.labelBasicFileName.AutoSize = true;
            this.labelBasicFileName.Location = new System.Drawing.Point(5, 9);
            this.labelBasicFileName.Name = "labelBasicFileName";
            this.labelBasicFileName.Size = new System.Drawing.Size(54, 13);
            this.labelBasicFileName.TabIndex = 5;
            this.labelBasicFileName.Text = "File Name";
            // 
            // textBoxBasicFileName
            // 
            this.textBoxBasicFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBasicFileName.Location = new System.Drawing.Point(65, 6);
            this.textBoxBasicFileName.Name = "textBoxBasicFileName";
            this.textBoxBasicFileName.ReadOnly = true;
            this.textBoxBasicFileName.Size = new System.Drawing.Size(246, 20);
            this.textBoxBasicFileName.TabIndex = 4;
            // 
            // buttonBasicBrowse
            // 
            this.buttonBasicBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBasicBrowse.Location = new System.Drawing.Point(317, 6);
            this.buttonBasicBrowse.Name = "buttonBasicBrowse";
            this.buttonBasicBrowse.Size = new System.Drawing.Size(30, 23);
            this.buttonBasicBrowse.TabIndex = 0;
            this.buttonBasicBrowse.Text = "...";
            this.buttonBasicBrowse.UseVisualStyleBackColor = true;
            this.buttonBasicBrowse.Click += new System.EventHandler(this.buttonBasicBrowse_Click);
            // 
            // tabPageWMP
            // 
            this.tabPageWMP.Controls.Add(this.labelWMPStatus);
            this.tabPageWMP.Controls.Add(this.buttonPlaylist);
            this.tabPageWMP.Controls.Add(this.labelWMPVersion);
            this.tabPageWMP.Controls.Add(this.labelWMPFileName);
            this.tabPageWMP.Controls.Add(this.textBoxWMPFileName);
            this.tabPageWMP.Controls.Add(this.buttonWMPBrowse);
            this.tabPageWMP.Controls.Add(this.axWindowsMediaPlayer);
            this.tabPageWMP.Location = new System.Drawing.Point(4, 22);
            this.tabPageWMP.Name = "tabPageWMP";
            this.tabPageWMP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWMP.Size = new System.Drawing.Size(353, 325);
            this.tabPageWMP.TabIndex = 1;
            this.tabPageWMP.Text = "Windows Media Player (ActiveX)";
            this.tabPageWMP.UseVisualStyleBackColor = true;
            // 
            // labelWMPStatus
            // 
            this.labelWMPStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelWMPStatus.AutoSize = true;
            this.labelWMPStatus.Location = new System.Drawing.Point(6, 309);
            this.labelWMPStatus.Name = "labelWMPStatus";
            this.labelWMPStatus.Size = new System.Drawing.Size(37, 13);
            this.labelWMPStatus.TabIndex = 11;
            this.labelWMPStatus.Text = "Status";
            this.labelWMPStatus.Click += new System.EventHandler(this.labelWMPStatus_Click);
            // 
            // buttonPlaylist
            // 
            this.buttonPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlaylist.Location = new System.Drawing.Point(272, 32);
            this.buttonPlaylist.Name = "buttonPlaylist";
            this.buttonPlaylist.Size = new System.Drawing.Size(75, 23);
            this.buttonPlaylist.TabIndex = 10;
            this.buttonPlaylist.Text = "Playlist";
            this.buttonPlaylist.UseVisualStyleBackColor = true;
            this.buttonPlaylist.Click += new System.EventHandler(this.buttonPlaylist_Click);
            // 
            // labelWMPVersion
            // 
            this.labelWMPVersion.AutoSize = true;
            this.labelWMPVersion.Location = new System.Drawing.Point(6, 29);
            this.labelWMPVersion.Name = "labelWMPVersion";
            this.labelWMPVersion.Size = new System.Drawing.Size(153, 13);
            this.labelWMPVersion.TabIndex = 9;
            this.labelWMPVersion.Text = "Windows Media Player Version";
            // 
            // labelWMPFileName
            // 
            this.labelWMPFileName.AutoSize = true;
            this.labelWMPFileName.Location = new System.Drawing.Point(5, 9);
            this.labelWMPFileName.Name = "labelWMPFileName";
            this.labelWMPFileName.Size = new System.Drawing.Size(54, 13);
            this.labelWMPFileName.TabIndex = 8;
            this.labelWMPFileName.Text = "File Name";
            // 
            // textBoxWMPFileName
            // 
            this.textBoxWMPFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWMPFileName.Location = new System.Drawing.Point(65, 6);
            this.textBoxWMPFileName.Name = "textBoxWMPFileName";
            this.textBoxWMPFileName.ReadOnly = true;
            this.textBoxWMPFileName.Size = new System.Drawing.Size(245, 20);
            this.textBoxWMPFileName.TabIndex = 7;
            // 
            // buttonWMPBrowse
            // 
            this.buttonWMPBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWMPBrowse.Location = new System.Drawing.Point(317, 6);
            this.buttonWMPBrowse.Name = "buttonWMPBrowse";
            this.buttonWMPBrowse.Size = new System.Drawing.Size(30, 23);
            this.buttonWMPBrowse.TabIndex = 6;
            this.buttonWMPBrowse.Text = "...";
            this.buttonWMPBrowse.UseVisualStyleBackColor = true;
            this.buttonWMPBrowse.Click += new System.EventHandler(this.buttonWMPBrowse_Click);
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(9, 61);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(338, 245);
            this.axWindowsMediaPlayer.TabIndex = 0;
            this.axWindowsMediaPlayer.StatusChange += new System.EventHandler(this.axWindowsMediaPlayer_StatusChange);
            // 
            // tabPageDX
            // 
            this.tabPageDX.Controls.Add(this.labelDXDevice);
            this.tabPageDX.Controls.Add(this.comboBoxDXDevice);
            this.tabPageDX.Controls.Add(this.buttonDXPlay);
            this.tabPageDX.Controls.Add(this.labelDXFileName);
            this.tabPageDX.Controls.Add(this.textBoxDXFileName);
            this.tabPageDX.Controls.Add(this.buttonDXBrowse);
            this.tabPageDX.Location = new System.Drawing.Point(4, 22);
            this.tabPageDX.Name = "tabPageDX";
            this.tabPageDX.Size = new System.Drawing.Size(353, 325);
            this.tabPageDX.TabIndex = 2;
            this.tabPageDX.Text = "DirectX Audio";
            this.tabPageDX.UseVisualStyleBackColor = true;
            // 
            // labelDXDevice
            // 
            this.labelDXDevice.AutoSize = true;
            this.labelDXDevice.Location = new System.Drawing.Point(5, 35);
            this.labelDXDevice.Name = "labelDXDevice";
            this.labelDXDevice.Size = new System.Drawing.Size(75, 13);
            this.labelDXDevice.TabIndex = 14;
            this.labelDXDevice.Text = "Sound Device";
            // 
            // comboBoxDXDevice
            // 
            this.comboBoxDXDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDXDevice.FormattingEnabled = true;
            this.comboBoxDXDevice.Location = new System.Drawing.Point(86, 32);
            this.comboBoxDXDevice.Name = "comboBoxDXDevice";
            this.comboBoxDXDevice.Size = new System.Drawing.Size(261, 21);
            this.comboBoxDXDevice.TabIndex = 13;
            // 
            // buttonDXPlay
            // 
            this.buttonDXPlay.Location = new System.Drawing.Point(86, 59);
            this.buttonDXPlay.Name = "buttonDXPlay";
            this.buttonDXPlay.Size = new System.Drawing.Size(52, 23);
            this.buttonDXPlay.TabIndex = 12;
            this.buttonDXPlay.Text = "Play";
            this.buttonDXPlay.UseVisualStyleBackColor = true;
            this.buttonDXPlay.Click += new System.EventHandler(this.buttonDXPlay_Click);
            // 
            // labelDXFileName
            // 
            this.labelDXFileName.AutoSize = true;
            this.labelDXFileName.Location = new System.Drawing.Point(5, 9);
            this.labelDXFileName.Name = "labelDXFileName";
            this.labelDXFileName.Size = new System.Drawing.Size(54, 13);
            this.labelDXFileName.TabIndex = 11;
            this.labelDXFileName.Text = "File Name";
            // 
            // textBoxDXFileName
            // 
            this.textBoxDXFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDXFileName.Location = new System.Drawing.Point(65, 6);
            this.textBoxDXFileName.Name = "textBoxDXFileName";
            this.textBoxDXFileName.ReadOnly = true;
            this.textBoxDXFileName.Size = new System.Drawing.Size(245, 20);
            this.textBoxDXFileName.TabIndex = 10;
            // 
            // buttonDXBrowse
            // 
            this.buttonDXBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDXBrowse.Location = new System.Drawing.Point(317, 6);
            this.buttonDXBrowse.Name = "buttonDXBrowse";
            this.buttonDXBrowse.Size = new System.Drawing.Size(30, 23);
            this.buttonDXBrowse.TabIndex = 9;
            this.buttonDXBrowse.Text = "...";
            this.buttonDXBrowse.UseVisualStyleBackColor = true;
            this.buttonDXBrowse.Click += new System.EventHandler(this.buttonDXBrowse_Click);
            // 
            // openFileDialogWave
            // 
            this.openFileDialogWave.DefaultExt = "wav";
            this.openFileDialogWave.Filter = "Known Files|*.wav|All Files|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Known Files|*.wav;*.mp3;*.wma;*.ogg;*.aif;*.aiff;*.au|All Files|*.*";
            // 
            // contextMenuStripPlaylist
            // 
            this.contextMenuStripPlaylist.Name = "contextMenuStripPlaylist";
            this.contextMenuStripPlaylist.Size = new System.Drawing.Size(61, 4);
            // 
            // AudioTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 372);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "AudioTest";
            this.Text = "Audio Test";
            this.Deactivate += new System.EventHandler(this.AudioTest_Deactivate);
            this.Load += new System.EventHandler(this.AudioTest_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.tabPageBasic.PerformLayout();
            this.groupBoxSoundPlayer.ResumeLayout(false);
            this.groupBoxPlaySound.ResumeLayout(false);
            this.tabPageWMP.ResumeLayout(false);
            this.tabPageWMP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.tabPageDX.ResumeLayout(false);
            this.tabPageDX.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.TabPage tabPageWMP;
        private System.Windows.Forms.TextBox textBoxBasicFileName;
        private System.Windows.Forms.Button buttonBasicBrowse;
        private System.Windows.Forms.TabPage tabPageDX;
        private System.Windows.Forms.GroupBox groupBoxPlaySound;
        private System.Windows.Forms.Button buttonPlaySoundSync;
        private System.Windows.Forms.Label labelBasicFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialogWave;
        private System.Windows.Forms.Button buttonPlaySoundAsync;
        private System.Windows.Forms.Button buttonStopAsync;
        private System.Windows.Forms.GroupBox groupBoxSoundPlayer;
        private System.Windows.Forms.Button buttonSoundPlayerSync;
        private System.Windows.Forms.Button buttonSoundPlayerAsync;
        private System.Windows.Forms.CheckBox checkBoxLoopAsync;
        private System.Windows.Forms.Button buttonSoundPlayerStopAsync;
        private System.Windows.Forms.Button buttonSoundPlayerPlayResource;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.Label labelWMPFileName;
        private System.Windows.Forms.TextBox textBoxWMPFileName;
        private System.Windows.Forms.Button buttonWMPBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelWMPVersion;
        private System.Windows.Forms.Label labelDXFileName;
        private System.Windows.Forms.TextBox textBoxDXFileName;
        private System.Windows.Forms.Button buttonDXBrowse;
        private System.Windows.Forms.Button buttonPlaylist;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPlaylist;
        private System.Windows.Forms.Label labelWMPStatus;
        private System.Windows.Forms.Button buttonDXPlay;
        private System.Windows.Forms.Label labelDXDevice;
        private System.Windows.Forms.ComboBox comboBoxDXDevice;
    }
}