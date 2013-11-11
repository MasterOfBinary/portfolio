namespace DotNET_Tests
{
    partial class ImageForm
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
            this.buttonFromFile = new System.Windows.Forms.Button();
            this.buttonFromResource = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nETTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myCoolPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxThumb = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFromFile
            // 
            this.buttonFromFile.Location = new System.Drawing.Point(13, 44);
            this.buttonFromFile.Name = "buttonFromFile";
            this.buttonFromFile.Size = new System.Drawing.Size(142, 23);
            this.buttonFromFile.TabIndex = 1;
            this.buttonFromFile.Text = "Load Image from File...";
            this.buttonFromFile.UseVisualStyleBackColor = true;
            this.buttonFromFile.Click += new System.EventHandler(this.buttonFromFile_Click);
            // 
            // buttonFromResource
            // 
            this.buttonFromResource.Location = new System.Drawing.Point(13, 12);
            this.buttonFromResource.Name = "buttonFromResource";
            this.buttonFromResource.Size = new System.Drawing.Size(142, 23);
            this.buttonFromResource.TabIndex = 0;
            this.buttonFromResource.Text = "Load Image from Resouce";
            this.buttonFromResource.UseVisualStyleBackColor = true;
            this.buttonFromResource.Click += new System.EventHandler(this.buttonFromResource_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nETTestsToolStripMenuItem,
            this.nETToolStripMenuItem,
            this.myCoolPictureToolStripMenuItem,
            this.transparencyToolStripMenuItem,
            this.squaresToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(160, 114);
            // 
            // nETTestsToolStripMenuItem
            // 
            this.nETTestsToolStripMenuItem.Name = "nETTestsToolStripMenuItem";
            this.nETTestsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nETTestsToolStripMenuItem.Text = ".NET Tests";
            this.nETTestsToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // nETToolStripMenuItem
            // 
            this.nETToolStripMenuItem.Name = "nETToolStripMenuItem";
            this.nETToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nETToolStripMenuItem.Text = ".NET";
            this.nETToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // myCoolPictureToolStripMenuItem
            // 
            this.myCoolPictureToolStripMenuItem.Name = "myCoolPictureToolStripMenuItem";
            this.myCoolPictureToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.myCoolPictureToolStripMenuItem.Text = "My Cool Picture";
            this.myCoolPictureToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // transparencyToolStripMenuItem
            // 
            this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
            this.transparencyToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.transparencyToolStripMenuItem.Text = "Transparency";
            this.transparencyToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // squaresToolStripMenuItem
            // 
            this.squaresToolStripMenuItem.Name = "squaresToolStripMenuItem";
            this.squaresToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.squaresToolStripMenuItem.Text = "Squares";
            this.squaresToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxThumb);
            this.groupBox1.Location = new System.Drawing.Point(13, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(77, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thumbnail";
            // 
            // pictureBoxThumb
            // 
            this.pictureBoxThumb.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxThumb.Name = "pictureBoxThumb";
            this.pictureBoxThumb.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxThumb.TabIndex = 3;
            this.pictureBoxThumb.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Known Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 169);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(116, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Show Edit Window";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 192);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonFromFile);
            this.Controls.Add(this.buttonFromResource);
            this.Name = "ImageForm";
            this.Text = "ImageForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageForm_FormClosing);
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFromFile;
        private System.Windows.Forms.Button buttonFromResource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem nETTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myCoolPictureToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxThumb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem transparencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squaresToolStripMenuItem;
    }
}