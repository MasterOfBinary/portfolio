namespace AudioInfoProgram.Dialog_Boxes
{
    partial class ID3v2TagOptionsDialog
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
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.groupBoxFlags = new System.Windows.Forms.GroupBox();
            this.checkBoxUnsynchronization = new System.Windows.Forms.CheckBox();
            this.checkBoxExperimental = new System.Windows.Forms.CheckBox();
            this.groupBoxFooterAndPadding = new System.Windows.Forms.GroupBox();
            this.checkBoxAddPadding = new System.Windows.Forms.CheckBox();
            this.groupBoxPaddingLength = new System.Windows.Forms.GroupBox();
            this.labelPercent = new System.Windows.Forms.Label();
            this.comboBoxPercent = new System.Windows.Forms.ComboBox();
            this.radioButtonPercentOfTag = new System.Windows.Forms.RadioButton();
            this.labelBytes2 = new System.Windows.Forms.Label();
            this.comboBoxRoundTo = new System.Windows.Forms.ComboBox();
            this.radioButtonRoundFileSize = new System.Windows.Forms.RadioButton();
            this.radioButtonFixed = new System.Windows.Forms.RadioButton();
            this.labelBytes1 = new System.Windows.Forms.Label();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.checkBoxAddFooter = new System.Windows.Forms.CheckBox();
            this.labelTagVersion = new System.Windows.Forms.Label();
            this.tabPageExtended = new System.Windows.Forms.TabPage();
            this.groupBoxExtendedHeader = new System.Windows.Forms.GroupBox();
            this.checkBoxAddExtendedHeader = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlOptions.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.groupBoxFlags.SuspendLayout();
            this.groupBoxFooterAndPadding.SuspendLayout();
            this.groupBoxPaddingLength.SuspendLayout();
            this.tabPageExtended.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlOptions.Controls.Add(this.tabPageBasic);
            this.tabControlOptions.Controls.Add(this.tabPageExtended);
            this.tabControlOptions.Location = new System.Drawing.Point(13, 13);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(284, 306);
            this.tabControlOptions.TabIndex = 0;
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.groupBoxFlags);
            this.tabPageBasic.Controls.Add(this.groupBoxFooterAndPadding);
            this.tabPageBasic.Controls.Add(this.labelTagVersion);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 22);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(276, 280);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "Basic";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // groupBoxFlags
            // 
            this.groupBoxFlags.Controls.Add(this.checkBoxUnsynchronization);
            this.groupBoxFlags.Controls.Add(this.checkBoxExperimental);
            this.groupBoxFlags.Location = new System.Drawing.Point(6, 24);
            this.groupBoxFlags.Name = "groupBoxFlags";
            this.groupBoxFlags.Size = new System.Drawing.Size(264, 65);
            this.groupBoxFlags.TabIndex = 10;
            this.groupBoxFlags.TabStop = false;
            this.groupBoxFlags.Text = "Flags";
            // 
            // checkBoxUnsynchronization
            // 
            this.checkBoxUnsynchronization.AutoSize = true;
            this.checkBoxUnsynchronization.Location = new System.Drawing.Point(6, 19);
            this.checkBoxUnsynchronization.Name = "checkBoxUnsynchronization";
            this.checkBoxUnsynchronization.Size = new System.Drawing.Size(199, 17);
            this.checkBoxUnsynchronization.TabIndex = 7;
            this.checkBoxUnsynchronization.Text = "Apply unsynchronization to all frames";
            this.checkBoxUnsynchronization.UseVisualStyleBackColor = true;
            // 
            // checkBoxExperimental
            // 
            this.checkBoxExperimental.AutoSize = true;
            this.checkBoxExperimental.Location = new System.Drawing.Point(6, 42);
            this.checkBoxExperimental.Name = "checkBoxExperimental";
            this.checkBoxExperimental.Size = new System.Drawing.Size(157, 17);
            this.checkBoxExperimental.TabIndex = 8;
            this.checkBoxExperimental.Text = "Tag is in experimental stage";
            this.checkBoxExperimental.UseVisualStyleBackColor = true;
            // 
            // groupBoxFooterAndPadding
            // 
            this.groupBoxFooterAndPadding.Controls.Add(this.checkBoxAddPadding);
            this.groupBoxFooterAndPadding.Controls.Add(this.groupBoxPaddingLength);
            this.groupBoxFooterAndPadding.Controls.Add(this.checkBoxAddFooter);
            this.groupBoxFooterAndPadding.Location = new System.Drawing.Point(6, 95);
            this.groupBoxFooterAndPadding.Name = "groupBoxFooterAndPadding";
            this.groupBoxFooterAndPadding.Size = new System.Drawing.Size(264, 172);
            this.groupBoxFooterAndPadding.TabIndex = 9;
            this.groupBoxFooterAndPadding.TabStop = false;
            this.groupBoxFooterAndPadding.Text = "Footer and Padding";
            // 
            // checkBoxAddPadding
            // 
            this.checkBoxAddPadding.AutoSize = true;
            this.checkBoxAddPadding.Location = new System.Drawing.Point(6, 42);
            this.checkBoxAddPadding.Name = "checkBoxAddPadding";
            this.checkBoxAddPadding.Size = new System.Drawing.Size(87, 17);
            this.checkBoxAddPadding.TabIndex = 3;
            this.checkBoxAddPadding.Text = "Add Padding";
            this.checkBoxAddPadding.UseVisualStyleBackColor = true;
            this.checkBoxAddPadding.CheckedChanged += new System.EventHandler(this.checkBoxAddPadding_CheckedChanged);
            // 
            // groupBoxPaddingLength
            // 
            this.groupBoxPaddingLength.Controls.Add(this.labelPercent);
            this.groupBoxPaddingLength.Controls.Add(this.comboBoxPercent);
            this.groupBoxPaddingLength.Controls.Add(this.radioButtonPercentOfTag);
            this.groupBoxPaddingLength.Controls.Add(this.labelBytes2);
            this.groupBoxPaddingLength.Controls.Add(this.comboBoxRoundTo);
            this.groupBoxPaddingLength.Controls.Add(this.radioButtonRoundFileSize);
            this.groupBoxPaddingLength.Controls.Add(this.radioButtonFixed);
            this.groupBoxPaddingLength.Controls.Add(this.labelBytes1);
            this.groupBoxPaddingLength.Controls.Add(this.comboBoxSize);
            this.groupBoxPaddingLength.Enabled = false;
            this.groupBoxPaddingLength.Location = new System.Drawing.Point(6, 65);
            this.groupBoxPaddingLength.Name = "groupBoxPaddingLength";
            this.groupBoxPaddingLength.Size = new System.Drawing.Size(252, 100);
            this.groupBoxPaddingLength.TabIndex = 4;
            this.groupBoxPaddingLength.TabStop = false;
            this.groupBoxPaddingLength.Text = "Padding Length";
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Enabled = false;
            this.labelPercent.Location = new System.Drawing.Point(215, 70);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(15, 13);
            this.labelPercent.TabIndex = 9;
            this.labelPercent.Text = "%";
            this.labelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxPercent
            // 
            this.comboBoxPercent.Enabled = false;
            this.comboBoxPercent.FormattingEnabled = true;
            this.comboBoxPercent.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "10"});
            this.comboBoxPercent.Location = new System.Drawing.Point(106, 67);
            this.comboBoxPercent.Name = "comboBoxPercent";
            this.comboBoxPercent.Size = new System.Drawing.Size(103, 21);
            this.comboBoxPercent.TabIndex = 8;
            this.comboBoxPercent.Leave += new System.EventHandler(this.comboBoxPercent_Leave);
            // 
            // radioButtonPercentOfTag
            // 
            this.radioButtonPercentOfTag.AutoSize = true;
            this.radioButtonPercentOfTag.Location = new System.Drawing.Point(7, 67);
            this.radioButtonPercentOfTag.Name = "radioButtonPercentOfTag";
            this.radioButtonPercentOfTag.Size = new System.Drawing.Size(92, 17);
            this.radioButtonPercentOfTag.TabIndex = 7;
            this.radioButtonPercentOfTag.TabStop = true;
            this.radioButtonPercentOfTag.Text = "Percent of tag";
            this.radioButtonPercentOfTag.UseVisualStyleBackColor = true;
            this.radioButtonPercentOfTag.CheckedChanged += new System.EventHandler(this.radioButtonPercentOfTag_CheckedChanged);
            // 
            // labelBytes2
            // 
            this.labelBytes2.AutoSize = true;
            this.labelBytes2.Enabled = false;
            this.labelBytes2.Location = new System.Drawing.Point(213, 46);
            this.labelBytes2.Name = "labelBytes2";
            this.labelBytes2.Size = new System.Drawing.Size(33, 13);
            this.labelBytes2.TabIndex = 6;
            this.labelBytes2.Text = "Bytes";
            // 
            // comboBoxRoundTo
            // 
            this.comboBoxRoundTo.Enabled = false;
            this.comboBoxRoundTo.FormattingEnabled = true;
            this.comboBoxRoundTo.Items.AddRange(new object[] {
            "512",
            "1024",
            "2048",
            "4096",
            "8192"});
            this.comboBoxRoundTo.Location = new System.Drawing.Point(106, 43);
            this.comboBoxRoundTo.Name = "comboBoxRoundTo";
            this.comboBoxRoundTo.Size = new System.Drawing.Size(103, 21);
            this.comboBoxRoundTo.TabIndex = 5;
            this.comboBoxRoundTo.Leave += new System.EventHandler(this.comboBoxRoundTo_Leave);
            // 
            // radioButtonRoundFileSize
            // 
            this.radioButtonRoundFileSize.AutoSize = true;
            this.radioButtonRoundFileSize.Location = new System.Drawing.Point(6, 43);
            this.radioButtonRoundFileSize.Name = "radioButtonRoundFileSize";
            this.radioButtonRoundFileSize.Size = new System.Drawing.Size(94, 17);
            this.radioButtonRoundFileSize.TabIndex = 4;
            this.radioButtonRoundFileSize.Text = "Round file size";
            this.radioButtonRoundFileSize.UseVisualStyleBackColor = true;
            this.radioButtonRoundFileSize.CheckedChanged += new System.EventHandler(this.radioButtonRoundFileSize_CheckedChanged);
            // 
            // radioButtonFixed
            // 
            this.radioButtonFixed.AutoSize = true;
            this.radioButtonFixed.Checked = true;
            this.radioButtonFixed.Location = new System.Drawing.Point(6, 19);
            this.radioButtonFixed.Name = "radioButtonFixed";
            this.radioButtonFixed.Size = new System.Drawing.Size(50, 17);
            this.radioButtonFixed.TabIndex = 3;
            this.radioButtonFixed.TabStop = true;
            this.radioButtonFixed.Text = "Fixed";
            this.radioButtonFixed.UseVisualStyleBackColor = true;
            this.radioButtonFixed.CheckedChanged += new System.EventHandler(this.radioButtonFixed_CheckedChanged);
            // 
            // labelBytes1
            // 
            this.labelBytes1.AutoSize = true;
            this.labelBytes1.Location = new System.Drawing.Point(213, 21);
            this.labelBytes1.Name = "labelBytes1";
            this.labelBytes1.Size = new System.Drawing.Size(33, 13);
            this.labelBytes1.TabIndex = 2;
            this.labelBytes1.Text = "Bytes";
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Items.AddRange(new object[] {
            "128",
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192"});
            this.comboBoxSize.Location = new System.Drawing.Point(106, 18);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(103, 21);
            this.comboBoxSize.TabIndex = 1;
            this.comboBoxSize.Leave += new System.EventHandler(this.comboBoxSize_Leave);
            // 
            // checkBoxAddFooter
            // 
            this.checkBoxAddFooter.AutoSize = true;
            this.checkBoxAddFooter.Location = new System.Drawing.Point(6, 19);
            this.checkBoxAddFooter.Name = "checkBoxAddFooter";
            this.checkBoxAddFooter.Size = new System.Drawing.Size(78, 17);
            this.checkBoxAddFooter.TabIndex = 5;
            this.checkBoxAddFooter.Text = "Add Footer";
            this.checkBoxAddFooter.UseVisualStyleBackColor = true;
            this.checkBoxAddFooter.CheckedChanged += new System.EventHandler(this.checkBoxAddFooter_CheckedChanged);
            // 
            // labelTagVersion
            // 
            this.labelTagVersion.AutoSize = true;
            this.labelTagVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTagVersion.Location = new System.Drawing.Point(3, 8);
            this.labelTagVersion.Name = "labelTagVersion";
            this.labelTagVersion.Size = new System.Drawing.Size(101, 13);
            this.labelTagVersion.TabIndex = 6;
            this.labelTagVersion.Text = "Tag Version: 2.4";
            // 
            // tabPageExtended
            // 
            this.tabPageExtended.Controls.Add(this.groupBoxExtendedHeader);
            this.tabPageExtended.Controls.Add(this.checkBoxAddExtendedHeader);
            this.tabPageExtended.Location = new System.Drawing.Point(4, 22);
            this.tabPageExtended.Name = "tabPageExtended";
            this.tabPageExtended.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExtended.Size = new System.Drawing.Size(276, 280);
            this.tabPageExtended.TabIndex = 1;
            this.tabPageExtended.Text = "Extended";
            this.tabPageExtended.UseVisualStyleBackColor = true;
            // 
            // groupBoxExtendedHeader
            // 
            this.groupBoxExtendedHeader.Enabled = false;
            this.groupBoxExtendedHeader.Location = new System.Drawing.Point(7, 31);
            this.groupBoxExtendedHeader.Name = "groupBoxExtendedHeader";
            this.groupBoxExtendedHeader.Size = new System.Drawing.Size(263, 243);
            this.groupBoxExtendedHeader.TabIndex = 1;
            this.groupBoxExtendedHeader.TabStop = false;
            this.groupBoxExtendedHeader.Text = "Extended Header";
            // 
            // checkBoxAddExtendedHeader
            // 
            this.checkBoxAddExtendedHeader.AutoSize = true;
            this.checkBoxAddExtendedHeader.Enabled = false;
            this.checkBoxAddExtendedHeader.Location = new System.Drawing.Point(7, 7);
            this.checkBoxAddExtendedHeader.Name = "checkBoxAddExtendedHeader";
            this.checkBoxAddExtendedHeader.Size = new System.Drawing.Size(128, 17);
            this.checkBoxAddExtendedHeader.TabIndex = 0;
            this.checkBoxAddExtendedHeader.Text = "Add extended header";
            this.checkBoxAddExtendedHeader.UseVisualStyleBackColor = true;
            this.checkBoxAddExtendedHeader.CheckedChanged += new System.EventHandler(this.checkBoxAddExtendedHeader_CheckedChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(141, 325);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(222, 325);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ID3v2TagOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 360);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControlOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ID3v2TagOptionsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ID3v2 Tag Options";
            this.tabControlOptions.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.tabPageBasic.PerformLayout();
            this.groupBoxFlags.ResumeLayout(false);
            this.groupBoxFlags.PerformLayout();
            this.groupBoxFooterAndPadding.ResumeLayout(false);
            this.groupBoxFooterAndPadding.PerformLayout();
            this.groupBoxPaddingLength.ResumeLayout(false);
            this.groupBoxPaddingLength.PerformLayout();
            this.tabPageExtended.ResumeLayout(false);
            this.tabPageExtended.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.TabPage tabPageExtended;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxAddFooter;
        private System.Windows.Forms.GroupBox groupBoxPaddingLength;
        private System.Windows.Forms.Label labelBytes2;
        private System.Windows.Forms.ComboBox comboBoxRoundTo;
        private System.Windows.Forms.RadioButton radioButtonRoundFileSize;
        private System.Windows.Forms.RadioButton radioButtonFixed;
        private System.Windows.Forms.Label labelBytes1;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.CheckBox checkBoxAddPadding;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.ComboBox comboBoxPercent;
        private System.Windows.Forms.RadioButton radioButtonPercentOfTag;
        private System.Windows.Forms.Label labelTagVersion;
        private System.Windows.Forms.CheckBox checkBoxUnsynchronization;
        private System.Windows.Forms.CheckBox checkBoxExperimental;
        private System.Windows.Forms.GroupBox groupBoxFooterAndPadding;
        private System.Windows.Forms.GroupBox groupBoxFlags;
        private System.Windows.Forms.GroupBox groupBoxExtendedHeader;
        private System.Windows.Forms.CheckBox checkBoxAddExtendedHeader;
    }
}