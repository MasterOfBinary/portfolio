namespace AudioInfoProgram
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
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("Text Information Frames", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("URL Link Frames", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Private Frames", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup19 = new System.Windows.Forms.ListViewGroup("Experimental Frames", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup20 = new System.Windows.Forms.ListViewGroup("Other Frames", System.Windows.Forms.HorizontalAlignment.Left);
            this.tabControlTags = new System.Windows.Forms.TabControl();
            this.tabPageV1 = new System.Windows.Forms.TabPage();
            this.linkLabelComment = new System.Windows.Forms.LinkLabel();
            this.buttonClearV1 = new System.Windows.Forms.Button();
            this.checkBoxDontWriteV11 = new System.Windows.Forms.CheckBox();
            this.buttonResetV1 = new System.Windows.Forms.Button();
            this.buttonCopyToV2 = new System.Windows.Forms.Button();
            this.textBoxGenre1 = new System.Windows.Forms.MaskedTextBox();
            this.labelGenre1 = new System.Windows.Forms.Label();
            this.textBoxComment1 = new System.Windows.Forms.TextBox();
            this.labelComment1 = new System.Windows.Forms.Label();
            this.textBoxTrack1 = new System.Windows.Forms.MaskedTextBox();
            this.labelTrack1 = new System.Windows.Forms.Label();
            this.labelYear1 = new System.Windows.Forms.Label();
            this.textBoxYear1 = new System.Windows.Forms.MaskedTextBox();
            this.textBoxAlbum1 = new System.Windows.Forms.TextBox();
            this.textBoxArtist1 = new System.Windows.Forms.TextBox();
            this.textBoxTitle1 = new System.Windows.Forms.TextBox();
            this.labelAlbum1 = new System.Windows.Forms.Label();
            this.labelArtist1 = new System.Windows.Forms.Label();
            this.labelTitle1 = new System.Windows.Forms.Label();
            this.tabPageV2 = new System.Windows.Forms.TabPage();
            this.buttonTagOptions = new System.Windows.Forms.Button();
            this.buttonTextEditor = new System.Windows.Forms.Button();
            this.buttonBinaryEditor = new System.Windows.Forms.Button();
            this.buttonEditFrame = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClearV2 = new System.Windows.Forms.Button();
            this.buttonResetV2 = new System.Windows.Forms.Button();
            this.buttonCopyToV1 = new System.Windows.Forms.Button();
            this.labelUncheckedItems = new System.Windows.Forms.Label();
            this.checkBoxShowInGroups = new System.Windows.Forms.CheckBox();
            this.listViewV2 = new System.Windows.Forms.ListView();
            this.columnHeaderID = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderData = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderOfficialDescription = new System.Windows.Forms.ColumnHeader();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertToSavedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commitChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxWriteV1 = new System.Windows.Forms.CheckBox();
            this.checkBoxWriteV2 = new System.Windows.Forms.CheckBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonCommitChanges = new System.Windows.Forms.Button();
            this.linkLabelInvalidTag = new System.Windows.Forms.LinkLabel();
            this.tabControlTags.SuspendLayout();
            this.tabPageV1.SuspendLayout();
            this.tabPageV2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTags
            // 
            this.tabControlTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTags.Controls.Add(this.tabPageV1);
            this.tabControlTags.Controls.Add(this.tabPageV2);
            this.tabControlTags.Enabled = false;
            this.tabControlTags.Location = new System.Drawing.Point(12, 100);
            this.tabControlTags.Name = "tabControlTags";
            this.tabControlTags.SelectedIndex = 0;
            this.tabControlTags.Size = new System.Drawing.Size(374, 373);
            this.tabControlTags.TabIndex = 0;
            // 
            // tabPageV1
            // 
            this.tabPageV1.Controls.Add(this.linkLabelComment);
            this.tabPageV1.Controls.Add(this.buttonClearV1);
            this.tabPageV1.Controls.Add(this.checkBoxDontWriteV11);
            this.tabPageV1.Controls.Add(this.buttonResetV1);
            this.tabPageV1.Controls.Add(this.buttonCopyToV2);
            this.tabPageV1.Controls.Add(this.textBoxGenre1);
            this.tabPageV1.Controls.Add(this.labelGenre1);
            this.tabPageV1.Controls.Add(this.textBoxComment1);
            this.tabPageV1.Controls.Add(this.labelComment1);
            this.tabPageV1.Controls.Add(this.textBoxTrack1);
            this.tabPageV1.Controls.Add(this.labelTrack1);
            this.tabPageV1.Controls.Add(this.labelYear1);
            this.tabPageV1.Controls.Add(this.textBoxYear1);
            this.tabPageV1.Controls.Add(this.textBoxAlbum1);
            this.tabPageV1.Controls.Add(this.textBoxArtist1);
            this.tabPageV1.Controls.Add(this.textBoxTitle1);
            this.tabPageV1.Controls.Add(this.labelAlbum1);
            this.tabPageV1.Controls.Add(this.labelArtist1);
            this.tabPageV1.Controls.Add(this.labelTitle1);
            this.tabPageV1.Location = new System.Drawing.Point(4, 22);
            this.tabPageV1.Name = "tabPageV1";
            this.tabPageV1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageV1.Size = new System.Drawing.Size(366, 347);
            this.tabPageV1.TabIndex = 0;
            this.tabPageV1.Text = "ID3v1/1.1 Tags";
            this.tabPageV1.UseVisualStyleBackColor = true;
            // 
            // linkLabelComment
            // 
            this.linkLabelComment.AutoSize = true;
            this.linkLabelComment.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelComment.Location = new System.Drawing.Point(267, 140);
            this.linkLabelComment.Name = "linkLabelComment";
            this.linkLabelComment.Size = new System.Drawing.Size(24, 13);
            this.linkLabelComment.TabIndex = 32;
            this.linkLabelComment.TabStop = true;
            this.linkLabelComment.Text = "Go!";
            this.linkLabelComment.Visible = false;
            this.linkLabelComment.VisitedLinkColor = System.Drawing.Color.Navy;
            this.linkLabelComment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelComment_LinkClicked);
            // 
            // buttonClearV1
            // 
            this.buttonClearV1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearV1.Location = new System.Drawing.Point(212, 318);
            this.buttonClearV1.Name = "buttonClearV1";
            this.buttonClearV1.Size = new System.Drawing.Size(97, 23);
            this.buttonClearV1.TabIndex = 30;
            this.buttonClearV1.Text = "Clear ID3v1";
            this.buttonClearV1.UseVisualStyleBackColor = true;
            this.buttonClearV1.Click += new System.EventHandler(this.buttonClearV1_Click);
            // 
            // checkBoxDontWriteV11
            // 
            this.checkBoxDontWriteV11.AutoSize = true;
            this.checkBoxDontWriteV11.Location = new System.Drawing.Point(6, 7);
            this.checkBoxDontWriteV11.Name = "checkBoxDontWriteV11";
            this.checkBoxDontWriteV11.Size = new System.Drawing.Size(217, 17);
            this.checkBoxDontWriteV11.TabIndex = 29;
            this.checkBoxDontWriteV11.Text = "Do not write version 1.1 tag (v1 tag only)";
            this.checkBoxDontWriteV11.UseVisualStyleBackColor = true;
            this.checkBoxDontWriteV11.CheckedChanged += new System.EventHandler(this.checkBoxDontWriteV11_CheckedChanged);
            // 
            // buttonResetV1
            // 
            this.buttonResetV1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonResetV1.Location = new System.Drawing.Point(109, 318);
            this.buttonResetV1.Name = "buttonResetV1";
            this.buttonResetV1.Size = new System.Drawing.Size(97, 23);
            this.buttonResetV1.TabIndex = 25;
            this.buttonResetV1.Text = "Reset ID3v1";
            this.buttonResetV1.UseVisualStyleBackColor = true;
            this.buttonResetV1.Click += new System.EventHandler(this.buttonResetV1_Click);
            // 
            // buttonCopyToV2
            // 
            this.buttonCopyToV2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopyToV2.Location = new System.Drawing.Point(6, 318);
            this.buttonCopyToV2.Name = "buttonCopyToV2";
            this.buttonCopyToV2.Size = new System.Drawing.Size(97, 23);
            this.buttonCopyToV2.TabIndex = 23;
            this.buttonCopyToV2.Text = "Copy to ID3v2";
            this.buttonCopyToV2.UseVisualStyleBackColor = true;
            this.buttonCopyToV2.Click += new System.EventHandler(this.buttonCopyToV2_Click);
            // 
            // textBoxGenre1
            // 
            this.textBoxGenre1.Location = new System.Drawing.Point(226, 111);
            this.textBoxGenre1.Mask = "000";
            this.textBoxGenre1.Name = "textBoxGenre1";
            this.textBoxGenre1.Size = new System.Drawing.Size(35, 20);
            this.textBoxGenre1.TabIndex = 21;
            this.textBoxGenre1.Leave += new System.EventHandler(this.textBoxGenre1_Leave);
            // 
            // labelGenre1
            // 
            this.labelGenre1.AutoSize = true;
            this.labelGenre1.Location = new System.Drawing.Point(184, 114);
            this.labelGenre1.Name = "labelGenre1";
            this.labelGenre1.Size = new System.Drawing.Size(36, 13);
            this.labelGenre1.TabIndex = 28;
            this.labelGenre1.Text = "Genre";
            // 
            // textBoxComment1
            // 
            this.textBoxComment1.Location = new System.Drawing.Point(59, 137);
            this.textBoxComment1.MaxLength = 28;
            this.textBoxComment1.Name = "textBoxComment1";
            this.textBoxComment1.Size = new System.Drawing.Size(202, 20);
            this.textBoxComment1.TabIndex = 22;
            this.textBoxComment1.TextChanged += new System.EventHandler(this.textBoxComment1_TextChanged);
            // 
            // labelComment1
            // 
            this.labelComment1.AutoSize = true;
            this.labelComment1.Location = new System.Drawing.Point(2, 140);
            this.labelComment1.Name = "labelComment1";
            this.labelComment1.Size = new System.Drawing.Size(51, 13);
            this.labelComment1.TabIndex = 27;
            this.labelComment1.Text = "Comment";
            // 
            // textBoxTrack1
            // 
            this.textBoxTrack1.Location = new System.Drawing.Point(143, 111);
            this.textBoxTrack1.Mask = "000";
            this.textBoxTrack1.Name = "textBoxTrack1";
            this.textBoxTrack1.Size = new System.Drawing.Size(35, 20);
            this.textBoxTrack1.TabIndex = 20;
            this.textBoxTrack1.Leave += new System.EventHandler(this.textBoxTrack1_Leave);
            // 
            // labelTrack1
            // 
            this.labelTrack1.AutoSize = true;
            this.labelTrack1.Location = new System.Drawing.Point(102, 113);
            this.labelTrack1.Name = "labelTrack1";
            this.labelTrack1.Size = new System.Drawing.Size(35, 13);
            this.labelTrack1.TabIndex = 26;
            this.labelTrack1.Text = "Track";
            // 
            // labelYear1
            // 
            this.labelYear1.AutoSize = true;
            this.labelYear1.Location = new System.Drawing.Point(3, 113);
            this.labelYear1.Name = "labelYear1";
            this.labelYear1.Size = new System.Drawing.Size(29, 13);
            this.labelYear1.TabIndex = 24;
            this.labelYear1.Text = "Year";
            // 
            // textBoxYear1
            // 
            this.textBoxYear1.Location = new System.Drawing.Point(59, 110);
            this.textBoxYear1.Mask = "0000";
            this.textBoxYear1.Name = "textBoxYear1";
            this.textBoxYear1.Size = new System.Drawing.Size(37, 20);
            this.textBoxYear1.TabIndex = 19;
            // 
            // textBoxAlbum1
            // 
            this.textBoxAlbum1.Location = new System.Drawing.Point(59, 84);
            this.textBoxAlbum1.MaxLength = 30;
            this.textBoxAlbum1.Name = "textBoxAlbum1";
            this.textBoxAlbum1.Size = new System.Drawing.Size(202, 20);
            this.textBoxAlbum1.TabIndex = 17;
            // 
            // textBoxArtist1
            // 
            this.textBoxArtist1.Location = new System.Drawing.Point(59, 57);
            this.textBoxArtist1.MaxLength = 30;
            this.textBoxArtist1.Name = "textBoxArtist1";
            this.textBoxArtist1.Size = new System.Drawing.Size(202, 20);
            this.textBoxArtist1.TabIndex = 15;
            // 
            // textBoxTitle1
            // 
            this.textBoxTitle1.Location = new System.Drawing.Point(59, 30);
            this.textBoxTitle1.MaxLength = 30;
            this.textBoxTitle1.Name = "textBoxTitle1";
            this.textBoxTitle1.Size = new System.Drawing.Size(202, 20);
            this.textBoxTitle1.TabIndex = 13;
            // 
            // labelAlbum1
            // 
            this.labelAlbum1.AutoSize = true;
            this.labelAlbum1.Location = new System.Drawing.Point(3, 87);
            this.labelAlbum1.Name = "labelAlbum1";
            this.labelAlbum1.Size = new System.Drawing.Size(36, 13);
            this.labelAlbum1.TabIndex = 18;
            this.labelAlbum1.Text = "Album";
            // 
            // labelArtist1
            // 
            this.labelArtist1.AutoSize = true;
            this.labelArtist1.Location = new System.Drawing.Point(3, 60);
            this.labelArtist1.Name = "labelArtist1";
            this.labelArtist1.Size = new System.Drawing.Size(30, 13);
            this.labelArtist1.TabIndex = 16;
            this.labelArtist1.Text = "Artist";
            // 
            // labelTitle1
            // 
            this.labelTitle1.AutoSize = true;
            this.labelTitle1.Location = new System.Drawing.Point(3, 33);
            this.labelTitle1.Name = "labelTitle1";
            this.labelTitle1.Size = new System.Drawing.Size(27, 13);
            this.labelTitle1.TabIndex = 14;
            this.labelTitle1.Text = "Title";
            // 
            // tabPageV2
            // 
            this.tabPageV2.Controls.Add(this.buttonTagOptions);
            this.tabPageV2.Controls.Add(this.buttonTextEditor);
            this.tabPageV2.Controls.Add(this.buttonBinaryEditor);
            this.tabPageV2.Controls.Add(this.buttonEditFrame);
            this.tabPageV2.Controls.Add(this.buttonRemove);
            this.tabPageV2.Controls.Add(this.buttonAdd);
            this.tabPageV2.Controls.Add(this.buttonClearV2);
            this.tabPageV2.Controls.Add(this.buttonResetV2);
            this.tabPageV2.Controls.Add(this.buttonCopyToV1);
            this.tabPageV2.Controls.Add(this.labelUncheckedItems);
            this.tabPageV2.Controls.Add(this.checkBoxShowInGroups);
            this.tabPageV2.Controls.Add(this.listViewV2);
            this.tabPageV2.Location = new System.Drawing.Point(4, 22);
            this.tabPageV2.Name = "tabPageV2";
            this.tabPageV2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageV2.Size = new System.Drawing.Size(366, 347);
            this.tabPageV2.TabIndex = 1;
            this.tabPageV2.Text = "ID3v2 Tags";
            this.tabPageV2.UseVisualStyleBackColor = true;
            // 
            // buttonTagOptions
            // 
            this.buttonTagOptions.Location = new System.Drawing.Point(269, 7);
            this.buttonTagOptions.Name = "buttonTagOptions";
            this.buttonTagOptions.Size = new System.Drawing.Size(90, 23);
            this.buttonTagOptions.TabIndex = 39;
            this.buttonTagOptions.Text = "Tag Options...";
            this.buttonTagOptions.UseVisualStyleBackColor = true;
            this.buttonTagOptions.Click += new System.EventHandler(this.buttonTagOptions_Click);
            // 
            // buttonTextEditor
            // 
            this.buttonTextEditor.Enabled = false;
            this.buttonTextEditor.Location = new System.Drawing.Point(204, 40);
            this.buttonTextEditor.Name = "buttonTextEditor";
            this.buttonTextEditor.Size = new System.Drawing.Size(75, 23);
            this.buttonTextEditor.TabIndex = 38;
            this.buttonTextEditor.Text = "Text Editor";
            this.buttonTextEditor.UseVisualStyleBackColor = true;
            this.buttonTextEditor.Click += new System.EventHandler(this.buttonTextEditor_Click);
            // 
            // buttonBinaryEditor
            // 
            this.buttonBinaryEditor.Enabled = false;
            this.buttonBinaryEditor.Location = new System.Drawing.Point(285, 40);
            this.buttonBinaryEditor.Name = "buttonBinaryEditor";
            this.buttonBinaryEditor.Size = new System.Drawing.Size(75, 23);
            this.buttonBinaryEditor.TabIndex = 37;
            this.buttonBinaryEditor.Text = "Binary Editor";
            this.buttonBinaryEditor.UseVisualStyleBackColor = true;
            this.buttonBinaryEditor.Click += new System.EventHandler(this.buttonBinaryEditor_Click);
            // 
            // buttonEditFrame
            // 
            this.buttonEditFrame.Enabled = false;
            this.buttonEditFrame.Location = new System.Drawing.Point(123, 40);
            this.buttonEditFrame.Name = "buttonEditFrame";
            this.buttonEditFrame.Size = new System.Drawing.Size(75, 23);
            this.buttonEditFrame.TabIndex = 36;
            this.buttonEditFrame.Text = "Edit Frame";
            this.buttonEditFrame.UseVisualStyleBackColor = true;
            this.buttonEditFrame.Click += new System.EventHandler(this.buttonEditFrame_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(54, 40);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(62, 23);
            this.buttonRemove.TabIndex = 35;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(7, 40);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(43, 23);
            this.buttonAdd.TabIndex = 34;
            this.buttonAdd.Text = "Add...";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddFrame_Click);
            // 
            // buttonClearV2
            // 
            this.buttonClearV2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearV2.Location = new System.Drawing.Point(213, 318);
            this.buttonClearV2.Name = "buttonClearV2";
            this.buttonClearV2.Size = new System.Drawing.Size(97, 23);
            this.buttonClearV2.TabIndex = 33;
            this.buttonClearV2.Text = "Clear ID3v2";
            this.buttonClearV2.UseVisualStyleBackColor = true;
            this.buttonClearV2.Click += new System.EventHandler(this.buttonClearV2_Click);
            // 
            // buttonResetV2
            // 
            this.buttonResetV2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonResetV2.Location = new System.Drawing.Point(110, 318);
            this.buttonResetV2.Name = "buttonResetV2";
            this.buttonResetV2.Size = new System.Drawing.Size(97, 23);
            this.buttonResetV2.TabIndex = 32;
            this.buttonResetV2.Text = "Reset ID3v2";
            this.buttonResetV2.UseVisualStyleBackColor = true;
            this.buttonResetV2.Click += new System.EventHandler(this.buttonResetV2_Click);
            // 
            // buttonCopyToV1
            // 
            this.buttonCopyToV1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopyToV1.Location = new System.Drawing.Point(7, 318);
            this.buttonCopyToV1.Name = "buttonCopyToV1";
            this.buttonCopyToV1.Size = new System.Drawing.Size(97, 23);
            this.buttonCopyToV1.TabIndex = 31;
            this.buttonCopyToV1.Text = "Copy to ID3v1";
            this.buttonCopyToV1.UseVisualStyleBackColor = true;
            this.buttonCopyToV1.Click += new System.EventHandler(this.buttonCopyToV1_Click);
            // 
            // labelUncheckedItems
            // 
            this.labelUncheckedItems.AutoSize = true;
            this.labelUncheckedItems.Location = new System.Drawing.Point(4, 24);
            this.labelUncheckedItems.Name = "labelUncheckedItems";
            this.labelUncheckedItems.Size = new System.Drawing.Size(177, 13);
            this.labelUncheckedItems.TabIndex = 2;
            this.labelUncheckedItems.Text = "Unchecked items will not be written.";
            // 
            // checkBoxShowInGroups
            // 
            this.checkBoxShowInGroups.AutoSize = true;
            this.checkBoxShowInGroups.Checked = true;
            this.checkBoxShowInGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowInGroups.Location = new System.Drawing.Point(7, 4);
            this.checkBoxShowInGroups.Name = "checkBoxShowInGroups";
            this.checkBoxShowInGroups.Size = new System.Drawing.Size(99, 17);
            this.checkBoxShowInGroups.TabIndex = 1;
            this.checkBoxShowInGroups.Text = "Show in groups";
            this.checkBoxShowInGroups.UseVisualStyleBackColor = true;
            this.checkBoxShowInGroups.CheckedChanged += new System.EventHandler(this.checkBoxShowInGroups_CheckedChanged);
            // 
            // listViewV2
            // 
            this.listViewV2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewV2.CheckBoxes = true;
            this.listViewV2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderName,
            this.columnHeaderData,
            this.columnHeaderOfficialDescription});
            listViewGroup16.Header = "Text Information Frames";
            listViewGroup16.Name = "listViewGroupTextInformationFrames";
            listViewGroup17.Header = "URL Link Frames";
            listViewGroup17.Name = "listViewGroupUrlLinkFrames";
            listViewGroup18.Header = "Private Frames";
            listViewGroup18.Name = "listViewGroupPrivateFrames";
            listViewGroup19.Header = "Experimental Frames";
            listViewGroup19.Name = "listViewGroupExperimentalFrames";
            listViewGroup20.Header = "Other Frames";
            listViewGroup20.Name = "listViewGroupOther";
            this.listViewV2.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup16,
            listViewGroup17,
            listViewGroup18,
            listViewGroup19,
            listViewGroup20});
            this.listViewV2.Location = new System.Drawing.Point(7, 69);
            this.listViewV2.MultiSelect = false;
            this.listViewV2.Name = "listViewV2";
            this.listViewV2.Size = new System.Drawing.Size(353, 243);
            this.listViewV2.TabIndex = 0;
            this.listViewV2.UseCompatibleStateImageBehavior = false;
            this.listViewV2.View = System.Windows.Forms.View.Details;
            this.listViewV2.SelectedIndexChanged += new System.EventHandler(this.listViewV2_SelectedIndexChanged);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 61;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 183;
            // 
            // columnHeaderData
            // 
            this.columnHeaderData.Text = "Data";
            this.columnHeaderData.Width = 244;
            // 
            // columnHeaderOfficialDescription
            // 
            this.columnHeaderOfficialDescription.Text = "Official Description";
            this.columnHeaderOfficialDescription.Width = 244;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(399, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.revertToSavedToolStripMenuItem,
            this.clearAllToolStripMenuItem,
            this.resetAllToolStripMenuItem,
            this.commitChangesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // revertToSavedToolStripMenuItem
            // 
            this.revertToSavedToolStripMenuItem.Enabled = false;
            this.revertToSavedToolStripMenuItem.Name = "revertToSavedToolStripMenuItem";
            this.revertToSavedToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.revertToSavedToolStripMenuItem.Text = "&Revert to Saved";
            this.revertToSavedToolStripMenuItem.Click += new System.EventHandler(this.revertToSavedToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Enabled = false;
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.clearAllToolStripMenuItem.Text = "Clear &All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // resetAllToolStripMenuItem
            // 
            this.resetAllToolStripMenuItem.Enabled = false;
            this.resetAllToolStripMenuItem.Name = "resetAllToolStripMenuItem";
            this.resetAllToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.resetAllToolStripMenuItem.Text = "Re&set All";
            this.resetAllToolStripMenuItem.Click += new System.EventHandler(this.resetAllToolStripMenuItem_Click);
            // 
            // commitChangesToolStripMenuItem
            // 
            this.commitChangesToolStripMenuItem.Enabled = false;
            this.commitChangesToolStripMenuItem.Name = "commitChangesToolStripMenuItem";
            this.commitChangesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.commitChangesToolStripMenuItem.Text = "&Commit Changes";
            this.commitChangesToolStripMenuItem.Click += new System.EventHandler(this.commitChangesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // checkBoxWriteV1
            // 
            this.checkBoxWriteV1.AutoSize = true;
            this.checkBoxWriteV1.Enabled = false;
            this.checkBoxWriteV1.Location = new System.Drawing.Point(12, 53);
            this.checkBoxWriteV1.Name = "checkBoxWriteV1";
            this.checkBoxWriteV1.Size = new System.Drawing.Size(155, 17);
            this.checkBoxWriteV1.TabIndex = 2;
            this.checkBoxWriteV1.Text = "Write ID3 version 1/1.1 tag";
            this.checkBoxWriteV1.UseVisualStyleBackColor = true;
            this.checkBoxWriteV1.CheckedChanged += new System.EventHandler(this.checkBoxWriteV1_CheckedChanged);
            // 
            // checkBoxWriteV2
            // 
            this.checkBoxWriteV2.AutoSize = true;
            this.checkBoxWriteV2.Enabled = false;
            this.checkBoxWriteV2.Location = new System.Drawing.Point(12, 77);
            this.checkBoxWriteV2.Name = "checkBoxWriteV2";
            this.checkBoxWriteV2.Size = new System.Drawing.Size(135, 17);
            this.checkBoxWriteV2.TabIndex = 3;
            this.checkBoxWriteV2.Text = "Write ID3 version 2 tag";
            this.checkBoxWriteV2.UseVisualStyleBackColor = true;
            this.checkBoxWriteV2.CheckedChanged += new System.EventHandler(this.checkBoxWriteV2_CheckedChanged);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(12, 30);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(54, 13);
            this.labelFileName.TabIndex = 8;
            this.labelFileName.Text = "File Name";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.Location = new System.Drawing.Point(72, 27);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(314, 20);
            this.textBoxFileName.TabIndex = 7;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "mp3";
            this.openFileDialog.Filter = "MP3 Files|*.mp3|All Files|*.*";
            // 
            // buttonCommitChanges
            // 
            this.buttonCommitChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCommitChanges.Enabled = false;
            this.buttonCommitChanges.Location = new System.Drawing.Point(285, 54);
            this.buttonCommitChanges.Name = "buttonCommitChanges";
            this.buttonCommitChanges.Size = new System.Drawing.Size(101, 23);
            this.buttonCommitChanges.TabIndex = 9;
            this.buttonCommitChanges.Text = "Commit Changes";
            this.buttonCommitChanges.UseVisualStyleBackColor = true;
            this.buttonCommitChanges.Click += new System.EventHandler(this.buttonCommitChanges_Click);
            // 
            // linkLabelInvalidTag
            // 
            this.linkLabelInvalidTag.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabelInvalidTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelInvalidTag.AutoSize = true;
            this.linkLabelInvalidTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelInvalidTag.LinkColor = System.Drawing.Color.Red;
            this.linkLabelInvalidTag.Location = new System.Drawing.Point(305, 100);
            this.linkLabelInvalidTag.Name = "linkLabelInvalidTag";
            this.linkLabelInvalidTag.Size = new System.Drawing.Size(81, 13);
            this.linkLabelInvalidTag.TabIndex = 33;
            this.linkLabelInvalidTag.TabStop = true;
            this.linkLabelInvalidTag.Text = "Invalid Tags!";
            this.linkLabelInvalidTag.Visible = false;
            this.linkLabelInvalidTag.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabelInvalidTag.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInvalidTag_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 485);
            this.Controls.Add(this.linkLabelInvalidTag);
            this.Controls.Add(this.buttonCommitChanges);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.checkBoxWriteV2);
            this.Controls.Add(this.checkBoxWriteV1);
            this.Controls.Add(this.tabControlTags);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "AudioInfo";
            this.tabControlTags.ResumeLayout(false);
            this.tabPageV1.ResumeLayout(false);
            this.tabPageV1.PerformLayout();
            this.tabPageV2.ResumeLayout(false);
            this.tabPageV2.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTags;
        private System.Windows.Forms.TabPage tabPageV1;
        private System.Windows.Forms.TabPage tabPageV2;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertToSavedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxDontWriteV11;
        private System.Windows.Forms.Button buttonResetV1;
        private System.Windows.Forms.Button buttonCopyToV2;
        private System.Windows.Forms.MaskedTextBox textBoxGenre1;
        private System.Windows.Forms.Label labelGenre1;
        private System.Windows.Forms.TextBox textBoxComment1;
        private System.Windows.Forms.Label labelComment1;
        private System.Windows.Forms.MaskedTextBox textBoxTrack1;
        private System.Windows.Forms.Label labelTrack1;
        private System.Windows.Forms.Label labelYear1;
        private System.Windows.Forms.MaskedTextBox textBoxYear1;
        private System.Windows.Forms.TextBox textBoxAlbum1;
        private System.Windows.Forms.TextBox textBoxArtist1;
        private System.Windows.Forms.TextBox textBoxTitle1;
        private System.Windows.Forms.Label labelAlbum1;
        private System.Windows.Forms.Label labelArtist1;
        private System.Windows.Forms.Label labelTitle1;
        private System.Windows.Forms.CheckBox checkBoxWriteV1;
        private System.Windows.Forms.CheckBox checkBoxWriteV2;
        private System.Windows.Forms.Button buttonClearV1;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonCommitChanges;
        private System.Windows.Forms.ToolStripMenuItem commitChangesToolStripMenuItem;
        private System.Windows.Forms.ListView listViewV2;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderData;
        private System.Windows.Forms.CheckBox checkBoxShowInGroups;
        private System.Windows.Forms.Label labelUncheckedItems;
        private System.Windows.Forms.LinkLabel linkLabelComment;
        private System.Windows.Forms.LinkLabel linkLabelInvalidTag;
        private System.Windows.Forms.ColumnHeader columnHeaderOfficialDescription;
        private System.Windows.Forms.Button buttonClearV2;
        private System.Windows.Forms.Button buttonResetV2;
        private System.Windows.Forms.Button buttonCopyToV1;
        private System.Windows.Forms.Button buttonEditFrame;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonBinaryEditor;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAllToolStripMenuItem;
        private System.Windows.Forms.Button buttonTextEditor;
        private System.Windows.Forms.Button buttonTagOptions;
    }
}

