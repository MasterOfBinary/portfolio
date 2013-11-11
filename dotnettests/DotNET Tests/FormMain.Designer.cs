namespace DotNET_Tests
{
    partial class FormMain
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonGraphicsAndTransparency = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonImaging = new System.Windows.Forms.Button();
            this.buttonAssembly = new System.Windows.Forms.Button();
            this.buttonAudio = new System.Windows.Forms.Button();
            this.linkLabelGoToMicrosoftCom = new System.Windows.Forms.LinkLabel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonGraphicsAndTransparency
            // 
            this.buttonGraphicsAndTransparency.Location = new System.Drawing.Point(12, 33);
            this.buttonGraphicsAndTransparency.Name = "buttonGraphicsAndTransparency";
            this.buttonGraphicsAndTransparency.Size = new System.Drawing.Size(179, 23);
            this.buttonGraphicsAndTransparency.TabIndex = 0;
            this.buttonGraphicsAndTransparency.Text = "Graphics and Transparency Test";
            this.buttonGraphicsAndTransparency.UseVisualStyleBackColor = true;
            this.buttonGraphicsAndTransparency.Visible = false;
            this.buttonGraphicsAndTransparency.Click += new System.EventHandler(this.buttonGraphicsAndTransparency_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(394, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.Visible = false;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonImaging
            // 
            this.buttonImaging.Location = new System.Drawing.Point(13, 62);
            this.buttonImaging.Name = "buttonImaging";
            this.buttonImaging.Size = new System.Drawing.Size(178, 23);
            this.buttonImaging.TabIndex = 1;
            this.buttonImaging.Text = "Imaging Test";
            this.buttonImaging.UseVisualStyleBackColor = true;
            this.buttonImaging.Visible = false;
            this.buttonImaging.Click += new System.EventHandler(this.buttonImaging_Click);
            // 
            // buttonAssembly
            // 
            this.buttonAssembly.Location = new System.Drawing.Point(13, 92);
            this.buttonAssembly.Name = "buttonAssembly";
            this.buttonAssembly.Size = new System.Drawing.Size(178, 23);
            this.buttonAssembly.TabIndex = 2;
            this.buttonAssembly.Text = "Assembly Test";
            this.buttonAssembly.UseVisualStyleBackColor = true;
            this.buttonAssembly.Visible = false;
            this.buttonAssembly.Click += new System.EventHandler(this.buttonAssembly_Click);
            // 
            // buttonAudio
            // 
            this.buttonAudio.Location = new System.Drawing.Point(13, 122);
            this.buttonAudio.Name = "buttonAudio";
            this.buttonAudio.Size = new System.Drawing.Size(178, 23);
            this.buttonAudio.TabIndex = 3;
            this.buttonAudio.Text = "Audio Test";
            this.buttonAudio.UseVisualStyleBackColor = true;
            this.buttonAudio.Visible = false;
            this.buttonAudio.Click += new System.EventHandler(this.buttonAudio_Click);
            // 
            // linkLabelGoToMicrosoftCom
            // 
            this.linkLabelGoToMicrosoftCom.AutoSize = true;
            this.linkLabelGoToMicrosoftCom.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelGoToMicrosoftCom.LinkColor = System.Drawing.Color.White;
            this.linkLabelGoToMicrosoftCom.Location = new System.Drawing.Point(13, 152);
            this.linkLabelGoToMicrosoftCom.Name = "linkLabelGoToMicrosoftCom";
            this.linkLabelGoToMicrosoftCom.Size = new System.Drawing.Size(102, 13);
            this.linkLabelGoToMicrosoftCom.TabIndex = 4;
            this.linkLabelGoToMicrosoftCom.TabStop = true;
            this.linkLabelGoToMicrosoftCom.Text = "Go to Microsoft.com";
            this.linkLabelGoToMicrosoftCom.Visible = false;
            this.linkLabelGoToMicrosoftCom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoToMicrosoftCom_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 276);
            this.Controls.Add(this.linkLabelGoToMicrosoftCom);
            this.Controls.Add(this.buttonAudio);
            this.Controls.Add(this.buttonAssembly);
            this.Controls.Add(this.buttonImaging);
            this.Controls.Add(this.buttonGraphicsAndTransparency);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = ".NET Tests";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonGraphicsAndTransparency;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonImaging;
        private System.Windows.Forms.Button buttonAssembly;
        private System.Windows.Forms.Button buttonAudio;
        private System.Windows.Forms.LinkLabel linkLabelGoToMicrosoftCom;

    }
}

