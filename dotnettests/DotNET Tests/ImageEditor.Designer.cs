namespace DotNET_Tests
{
    partial class ImageEditor
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strechImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Location = new System.Drawing.Point(13, 196);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(75, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Windowshade";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolsToolStripMenuItem,
            this.strechImageToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // imageToolsToolStripMenuItem
            // 
            this.imageToolsToolStripMenuItem.Enabled = false;
            this.imageToolsToolStripMenuItem.Name = "imageToolsToolStripMenuItem";
            this.imageToolsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.imageToolsToolStripMenuItem.Text = "Image Tools";
            // 
            // strechImageToolStripMenuItem
            // 
            this.strechImageToolStripMenuItem.Name = "strechImageToolStripMenuItem";
            this.strechImageToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.strechImageToolStripMenuItem.Text = "&Strech Image";
            this.strechImageToolStripMenuItem.Click += new System.EventHandler(this.strechImageToolStripMenuItem_Click);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 221);
            this.Controls.Add(this.linkLabel1);
            this.DoubleBuffered = true;
            this.Name = "ImageEditor";
            this.ShowInTaskbar = false;
            this.Text = "Image";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageEditor_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageEditor_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageEditor_MouseClick);
            this.Load += new System.EventHandler(this.ImageEditor_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strechImageToolStripMenuItem;

    }
}