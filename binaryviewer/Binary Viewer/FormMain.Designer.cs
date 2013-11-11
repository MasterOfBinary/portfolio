namespace Binary_Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxText = new System.Windows.Forms.GroupBox();
            this.richTextBoxText = new System.Windows.Forms.RichTextBox();
            this.groupBoxHex = new System.Windows.Forms.GroupBox();
            this.richTextBoxHex = new System.Windows.Forms.RichTextBox();
            this.groupBoxBinary = new System.Windows.Forms.GroupBox();
            this.richTextBoxBinary = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarLoading = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelLoading = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.restoreAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexadecimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxDecimal = new System.Windows.Forms.GroupBox();
            this.richTextBoxDecimal = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            this.groupBoxText.SuspendLayout();
            this.groupBoxHex.SuspendLayout();
            this.groupBoxBinary.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxDecimal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(745, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBoxText
            // 
            this.groupBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxText.Controls.Add(this.richTextBoxText);
            this.groupBoxText.Location = new System.Drawing.Point(13, 28);
            this.groupBoxText.Name = "groupBoxText";
            this.groupBoxText.Size = new System.Drawing.Size(179, 407);
            this.groupBoxText.TabIndex = 1;
            this.groupBoxText.TabStop = false;
            this.groupBoxText.Text = "Text";
            // 
            // richTextBoxText
            // 
            this.richTextBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxText.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxText.Name = "richTextBoxText";
            this.richTextBoxText.ReadOnly = true;
            this.richTextBoxText.Size = new System.Drawing.Size(166, 381);
            this.richTextBoxText.TabIndex = 0;
            this.richTextBoxText.Text = "";
            this.richTextBoxText.WordWrap = false;
            // 
            // groupBoxHex
            // 
            this.groupBoxHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxHex.Controls.Add(this.richTextBoxHex);
            this.groupBoxHex.Location = new System.Drawing.Point(358, 28);
            this.groupBoxHex.Name = "groupBoxHex";
            this.groupBoxHex.Size = new System.Drawing.Size(148, 407);
            this.groupBoxHex.TabIndex = 2;
            this.groupBoxHex.TabStop = false;
            this.groupBoxHex.Text = "Hexadecimal";
            // 
            // richTextBoxHex
            // 
            this.richTextBoxHex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxHex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxHex.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxHex.Name = "richTextBoxHex";
            this.richTextBoxHex.ReadOnly = true;
            this.richTextBoxHex.Size = new System.Drawing.Size(136, 381);
            this.richTextBoxHex.TabIndex = 1;
            this.richTextBoxHex.Text = "";
            this.richTextBoxHex.WordWrap = false;
            // 
            // groupBoxBinary
            // 
            this.groupBoxBinary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBinary.Controls.Add(this.richTextBoxBinary);
            this.groupBoxBinary.Location = new System.Drawing.Point(512, 28);
            this.groupBoxBinary.Name = "groupBoxBinary";
            this.groupBoxBinary.Size = new System.Drawing.Size(221, 407);
            this.groupBoxBinary.TabIndex = 3;
            this.groupBoxBinary.TabStop = false;
            this.groupBoxBinary.Text = "Binary";
            // 
            // richTextBoxBinary
            // 
            this.richTextBoxBinary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxBinary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxBinary.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxBinary.Name = "richTextBoxBinary";
            this.richTextBoxBinary.ReadOnly = true;
            this.richTextBoxBinary.Size = new System.Drawing.Size(209, 382);
            this.richTextBoxBinary.TabIndex = 1;
            this.richTextBoxBinary.Text = "";
            this.richTextBoxBinary.WordWrap = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.Filter = "All Files|*.*";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarLoading,
            this.toolStripStatusLabelLoading,
            this.toolStripDropDownButton1});
            this.statusStrip.Location = new System.Drawing.Point(0, 438);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(745, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripProgressBarLoading
            // 
            this.toolStripProgressBarLoading.Name = "toolStripProgressBarLoading";
            this.toolStripProgressBarLoading.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBarLoading.Visible = false;
            // 
            // toolStripStatusLabelLoading
            // 
            this.toolStripStatusLabelLoading.Name = "toolStripStatusLabelLoading";
            this.toolStripStatusLabelLoading.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabelLoading.Text = "Loading...";
            this.toolStripStatusLabelLoading.Visible = false;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.textToolStripMenuItem,
            this.decimalToolStripMenuItem,
            this.hexadecimalToolStripMenuItem,
            this.binaryToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(98, 20);
            this.toolStripDropDownButton1.Text = "Maximize View";
            // 
            // restoreAllToolStripMenuItem
            // 
            this.restoreAllToolStripMenuItem.Name = "restoreAllToolStripMenuItem";
            this.restoreAllToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.restoreAllToolStripMenuItem.Text = "&Restore All";
            this.restoreAllToolStripMenuItem.Click += new System.EventHandler(this.restoreAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.textToolStripMenuItem.Text = "&Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // decimalToolStripMenuItem
            // 
            this.decimalToolStripMenuItem.Name = "decimalToolStripMenuItem";
            this.decimalToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.decimalToolStripMenuItem.Text = "&Decimal";
            this.decimalToolStripMenuItem.Click += new System.EventHandler(this.decimalToolStripMenuItem_Click);
            // 
            // hexadecimalToolStripMenuItem
            // 
            this.hexadecimalToolStripMenuItem.Name = "hexadecimalToolStripMenuItem";
            this.hexadecimalToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.hexadecimalToolStripMenuItem.Text = "&Hexadecimal";
            this.hexadecimalToolStripMenuItem.Click += new System.EventHandler(this.hexadecimalToolStripMenuItem_Click);
            // 
            // binaryToolStripMenuItem
            // 
            this.binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
            this.binaryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.binaryToolStripMenuItem.Text = "&Binary";
            this.binaryToolStripMenuItem.Click += new System.EventHandler(this.binaryToolStripMenuItem_Click);
            // 
            // groupBoxDecimal
            // 
            this.groupBoxDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxDecimal.Controls.Add(this.richTextBoxDecimal);
            this.groupBoxDecimal.Location = new System.Drawing.Point(198, 28);
            this.groupBoxDecimal.Name = "groupBoxDecimal";
            this.groupBoxDecimal.Size = new System.Drawing.Size(154, 407);
            this.groupBoxDecimal.TabIndex = 6;
            this.groupBoxDecimal.TabStop = false;
            this.groupBoxDecimal.Text = "Decimal";
            // 
            // richTextBoxDecimal
            // 
            this.richTextBoxDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDecimal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxDecimal.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxDecimal.Name = "richTextBoxDecimal";
            this.richTextBoxDecimal.ReadOnly = true;
            this.richTextBoxDecimal.Size = new System.Drawing.Size(142, 382);
            this.richTextBoxDecimal.TabIndex = 1;
            this.richTextBoxDecimal.Text = "";
            this.richTextBoxDecimal.WordWrap = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 460);
            this.Controls.Add(this.groupBoxDecimal);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxBinary);
            this.Controls.Add(this.groupBoxHex);
            this.Controls.Add(this.groupBoxText);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Binary Viewer";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxText.ResumeLayout(false);
            this.groupBoxHex.ResumeLayout(false);
            this.groupBoxBinary.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxDecimal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxText;
        private System.Windows.Forms.GroupBox groupBoxHex;
        private System.Windows.Forms.GroupBox groupBoxBinary;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarLoading;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLoading;
        private System.Windows.Forms.RichTextBox richTextBoxText;
        private System.Windows.Forms.RichTextBox richTextBoxHex;
        private System.Windows.Forms.RichTextBox richTextBoxBinary;
        private System.Windows.Forms.GroupBox groupBoxDecimal;
        private System.Windows.Forms.RichTextBox richTextBoxDecimal;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexadecimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

