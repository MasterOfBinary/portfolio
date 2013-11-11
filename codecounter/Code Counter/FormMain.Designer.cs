namespace Code_Counter
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
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelFolder = new System.Windows.Forms.Label();
            this.textBoxExtension = new System.Windows.Forms.TextBox();
            this.labelExtensions = new System.Windows.Forms.Label();
            this.checkBoxSubfolders = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelResults = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            this.textBoxSkip = new System.Windows.Forms.TextBox();
            this.checkBoxSkip = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.Location = new System.Drawing.Point(79, 12);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(246, 20);
            this.textBoxFolder.TabIndex = 0;
            this.textBoxFolder.TextChanged += new System.EventHandler(this.textBoxFolder_TextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(331, 10);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(35, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(12, 15);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(39, 13);
            this.labelFolder.TabIndex = 2;
            this.labelFolder.Text = "Folder:";
            // 
            // textBoxExtension
            // 
            this.textBoxExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExtension.Location = new System.Drawing.Point(79, 38);
            this.textBoxExtension.Name = "textBoxExtension";
            this.textBoxExtension.Size = new System.Drawing.Size(205, 20);
            this.textBoxExtension.TabIndex = 3;
            this.textBoxExtension.Text = "*.cs";
            // 
            // labelExtensions
            // 
            this.labelExtensions.AutoSize = true;
            this.labelExtensions.Location = new System.Drawing.Point(12, 41);
            this.labelExtensions.Name = "labelExtensions";
            this.labelExtensions.Size = new System.Drawing.Size(56, 13);
            this.labelExtensions.TabIndex = 4;
            this.labelExtensions.Text = "Extension:";
            // 
            // checkBoxSubfolders
            // 
            this.checkBoxSubfolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSubfolders.AutoSize = true;
            this.checkBoxSubfolders.Checked = true;
            this.checkBoxSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSubfolders.Location = new System.Drawing.Point(290, 40);
            this.checkBoxSubfolders.Name = "checkBoxSubfolders";
            this.checkBoxSubfolders.Size = new System.Drawing.Size(76, 17);
            this.checkBoxSubfolders.TabIndex = 5;
            this.checkBoxSubfolders.Text = "Subfolders";
            this.checkBoxSubfolders.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(317, 117);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(49, 23);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.Location = new System.Drawing.Point(12, 96);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(42, 13);
            this.labelResults.TabIndex = 7;
            this.labelResults.Text = "Results";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(262, 117);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(49, 23);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 2000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // checkBoxAutoUpdate
            // 
            this.checkBoxAutoUpdate.AutoSize = true;
            this.checkBoxAutoUpdate.Checked = true;
            this.checkBoxAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoUpdate.Location = new System.Drawing.Point(15, 121);
            this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            this.checkBoxAutoUpdate.Size = new System.Drawing.Size(117, 17);
            this.checkBoxAutoUpdate.TabIndex = 9;
            this.checkBoxAutoUpdate.Text = "Auto update results";
            this.checkBoxAutoUpdate.UseVisualStyleBackColor = true;
            this.checkBoxAutoUpdate.CheckedChanged += new System.EventHandler(this.checkBoxAutoUpdate_CheckedChanged);
            // 
            // textBoxSkip
            // 
            this.textBoxSkip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSkip.Location = new System.Drawing.Point(79, 65);
            this.textBoxSkip.Name = "textBoxSkip";
            this.textBoxSkip.Size = new System.Drawing.Size(287, 20);
            this.textBoxSkip.TabIndex = 11;
            this.textBoxSkip.Text = "*.Designer.cs";
            // 
            // checkBoxSkip
            // 
            this.checkBoxSkip.AutoSize = true;
            this.checkBoxSkip.Checked = true;
            this.checkBoxSkip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSkip.Location = new System.Drawing.Point(15, 67);
            this.checkBoxSkip.Name = "checkBoxSkip";
            this.checkBoxSkip.Size = new System.Drawing.Size(50, 17);
            this.checkBoxSkip.TabIndex = 12;
            this.checkBoxSkip.Text = "Skip:";
            this.checkBoxSkip.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(378, 150);
            this.Controls.Add(this.checkBoxSkip);
            this.Controls.Add(this.textBoxSkip);
            this.Controls.Add(this.checkBoxAutoUpdate);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelResults);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.checkBoxSubfolders);
            this.Controls.Add(this.labelExtensions);
            this.Controls.Add(this.textBoxExtension);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxFolder);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.TextBox textBoxExtension;
        private System.Windows.Forms.Label labelExtensions;
        private System.Windows.Forms.CheckBox checkBoxSubfolders;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox checkBoxAutoUpdate;
        private System.Windows.Forms.TextBox textBoxSkip;
        private System.Windows.Forms.CheckBox checkBoxSkip;
    }
}

