using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AudioInfo;
using AudioInfo.ID3;

namespace AudioInfoProgram
{
    public partial class FormMain : Form
    {
        ID3 id3Original;

        List<Error> Errors;

        // Flags
        internal bool Unsynchronization;
        internal bool Experimental;
        internal bool AddFooter;
        internal bool AddPadding;
        internal AudioInfo.ID3.PaddingSize PaddingSizeType;
        internal int PaddingSizeValue;

        string FileName;

        /// <summary>
        /// The constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sent when the "Open" menu item is clicked.
        /// Shows an open file dialog and loads the chosen file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;

                LoadID3();
            }
        }

        /// <summary>
        /// Sent when the "Revert to Saved" menu item is clicked.
        /// Reloads the tags from the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void revertToSavedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadID3();
        }

        /// <summary>
        /// Sent when the "Clear All" menu item is clicked.
        /// Clears all the tags.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonClearV1_Click(null, null);
            buttonClearV2_Click(null, null);
        }

        /// <summary>
        /// Sent when the "Reset All" menu item is clicked.
        /// Resets all the tags to their original values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonResetV1_Click(null, null);
            buttonResetV2_Click(null, null);
        }

        /// <summary>
        /// Sent when the "Commit Changes" menu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commitChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonCommitChanges_Click(null, null);
        }

        /// <summary>
        /// Sent when the "Exit" menu item is clicked.
        /// Exits the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sent when the "Write version 1/1.1 tag" box is clicked.
        /// Enables/disables the tabPageV1 according to the state of the check box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxWriteV1_CheckedChanged(object sender, EventArgs e)
        {
            tabPageV1.Enabled = checkBoxWriteV1.Checked;
        }

        /// <summary>
        /// Sent when the "Write version 2 tag" box is clicked.
        /// Enables/disables the tabPageV2 according to the state of the check box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxWriteV2_CheckedChanged(object sender, EventArgs e)
        {
            tabPageV2.Enabled = checkBoxWriteV2.Checked;
        }

        /// <summary>
        /// Sent when the "Don't write version 1.1" check box is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxDontWriteV11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDontWriteV11.Checked)
            {
                textBoxComment1.MaxLength = 30;
                textBoxTrack1.Enabled = false;
                labelTrack1.Enabled = false;
            }
            else
            {
                textBoxComment1.MaxLength = 28;
                if (textBoxComment1.Text.Length > 28)
                    textBoxComment1.Text = textBoxComment1.Text.Substring(0, 28);
                textBoxTrack1.Enabled = true;
                labelTrack1.Enabled = true;
            }
        }

        /// <summary>
        /// Sent when the "Show in groups" check box is clicked.
        /// Enables or disables the ShowGroups property for the listViewV2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxShowInGroups_CheckedChanged(object sender, EventArgs e)
        {
            listViewV2.ShowGroups = checkBoxShowInGroups.Checked;
            if (!checkBoxShowInGroups.Checked)
                listViewV2.EnsureVisible(0);
        }

        /// <summary>
        /// Sent whent the "Tag Options" button is clicked.
        /// Opens the ID3v2 Tag Options dialog box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTagOptions_Click(object sender, EventArgs e)
        {
            Dialog_Boxes.ID3v2TagOptionsDialog dlg = new AudioInfoProgram.Dialog_Boxes.ID3v2TagOptionsDialog(this);
            dlg.ShowDialog();
        }

        /// <summary>
        /// Sent when the "Copy to v1" button is clicked.
        /// Copies the version 2 tags to the version 1 tags
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCopyToV1_Click(object sender, EventArgs e)
        {
            textBoxTitle1.Text = "";
            textBoxArtist1.Text = "";
            textBoxAlbum1.Text = "";
            textBoxYear1.Text = "0000";
            textBoxTrack1.Text = "000";
            textBoxGenre1.Text = "000";
            textBoxComment1.Text = "";

            // Copy the fields
            foreach (Id3v2FrameListViewItem item in listViewV2.Items)
            {
                // We'll check each item and if we find one we need we'll copy it
                if (item.Frame.ID.CompareID(FrameIDs.Title))
                    textBoxTitle1.Text = AudioInfoTools.ToString(item.Frame.Data);
                else if (item.Frame.ID.CompareID(FrameIDs.Artist))
                    textBoxArtist1.Text = AudioInfoTools.ToString(item.Frame.Data);
                else if (item.Frame.ID.CompareID(FrameIDs.Album))
                    textBoxAlbum1.Text = AudioInfoTools.ToString(item.Frame.Data);
                else if (item.Frame.ID.CompareID(FrameIDs.Year))
                {
                    // "TYER" isn't standard, but it seems to be used by almost every
                    // encoder
                    textBoxYear1.Text = AudioInfoTools.ToString(item.Frame.Data);
                    textBoxYear1.Text = textBoxYear1.Text.PadLeft(4, '0');
                }
                else if (item.Frame.ID.CompareID(FrameIDs.Track))
                {
                    textBoxTrack1.Text = AudioInfoTools.ToString(item.Frame.Data);
                    textBoxTrack1.Text = textBoxTrack1.Text.PadLeft(3, '0');
                }
                else if (item.Frame.ID.CompareID(FrameIDs.Genre))
                {
                    textBoxGenre1.Text = AudioInfoTools.ToString(item.Frame.Data);
                    textBoxGenre1.Text = textBoxGenre1.Text.PadLeft(3, '0');
                }
                else if (item.Frame.ID.CompareID(FrameIDs.Comments))
                    textBoxComment1.Text = AudioInfoTools.ToString(item.Frame.Data);
            }

            // Select the id3v1 tab
            tabControlTags.SelectedIndex = 0;
        }

        /// <summary>
        /// Sent when the "Copy to v2" button is clicked.
        /// Copies the version 1 tags to the version 2 tags
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCopyToV2_Click(object sender, EventArgs e)
        {
            bool TitleDone = false, ArtistDone = false, AlbumDone = false, YearDone = false;
            bool TrackDone = false, GenreDone = false, CommentDone = false;

            // We'll loop through the frames to find the ones we're going to copy
            // If they don't exist we have to make them
            for (int x = 0; x < listViewV2.Items.Count; x++)
            {
                Id3v2FrameListViewItem item = (Id3v2FrameListViewItem)listViewV2.Items[x];

                if (item.Frame.ID.CompareID(FrameIDs.Title))
                {
                    TitleDone = true;
                    Frame f = item.Frame;
                    f.Data = AudioInfoTools.ToByteArray(textBoxTitle1.Text);
                    listViewV2.Items[x] = new Id3v2FrameListViewItem(listViewV2.Groups, f);
                }
                else if (item.Frame.ID.CompareID(FrameIDs.Artist))
                {
                    ArtistDone = true;
                    Frame f = item.Frame;
                    f.Data = AudioInfoTools.ToByteArray(textBoxArtist1.Text);
                    listViewV2.Items[x] = new Id3v2FrameListViewItem(listViewV2.Groups, f);
                }
                else if (item.Frame.ID.CompareID(FrameIDs.Album))
                {
                    AlbumDone = true;
                    Frame f = item.Frame;
                    f.Data = AudioInfoTools.ToByteArray(textBoxAlbum1.Text);
                    listViewV2.Items[x] = new Id3v2FrameListViewItem(listViewV2.Groups, f);
                }
                else if (item.Frame.ID.CompareID(FrameIDs.Year))
                {
                    YearDone = true;
                    Frame f = item.Frame;
                    f.Data = AudioInfoTools.ToByteArray(textBoxYear1.Text);
                    listViewV2.Items[x] = new Id3v2FrameListViewItem(listViewV2.Groups, f);
                }
                else if (item.Frame.ID.CompareID(FrameIDs.Track))
                {
                    TrackDone = true;
                    Frame f = item.Frame;
                    f.Data = AudioInfoTools.ToByteArray(textBoxTrack1.Text);
                    listViewV2.Items[x] = new Id3v2FrameListViewItem(listViewV2.Groups, f);
                }
                else if (item.Frame.ID.CompareID(FrameIDs.Genre))
                {
                    GenreDone = true;
                    Frame f = item.Frame;
                    f.Data = AudioInfoTools.ToByteArray(textBoxGenre1.Text);
                    listViewV2.Items[x] = new Id3v2FrameListViewItem(listViewV2.Groups, f);
                }
                else if (item.Frame.ID.CompareID(FrameIDs.Comments))
                {
                    CommentDone = true;
                    Frame f = item.Frame;
                    f.Data = AudioInfoTools.ToByteArray(textBoxComment1.Text);
                    listViewV2.Items[x] = new Id3v2FrameListViewItem(listViewV2.Groups, f);
                }
            }

            if (!TitleDone)
            {
                Frame frame = new Frame();
                frame.ID = FrameIDs.Title;
                frame.Data = AudioInfoTools.ToByteArray(textBoxTitle1.Text);
                listViewV2.Items.Add(new Id3v2FrameListViewItem(listViewV2.Groups, frame));
            }
            if (!ArtistDone)
            {
                Frame frame = new Frame();
                frame.ID = FrameIDs.Artist;
                frame.Data = AudioInfoTools.ToByteArray(textBoxArtist1.Text);
                listViewV2.Items.Add(new Id3v2FrameListViewItem(listViewV2.Groups, frame));
            }
            if (!AlbumDone)
            {
                Frame frame = new Frame();
                frame.ID = FrameIDs.Album;
                frame.Data = AudioInfoTools.ToByteArray(textBoxAlbum1.Text);
                listViewV2.Items.Add(new Id3v2FrameListViewItem(listViewV2.Groups, frame));
            }
            if (!YearDone)
            {
                Frame frame = new Frame();
                frame.ID = FrameIDs.Year;
                frame.Data = AudioInfoTools.ToByteArray(textBoxYear1.Text);
                listViewV2.Items.Add(new Id3v2FrameListViewItem(listViewV2.Groups, frame));
            }
            if (!TrackDone)
            {
                Frame frame = new Frame();
                frame.ID = FrameIDs.Track;
                frame.Data = AudioInfoTools.ToByteArray(textBoxTrack1.Text);
                listViewV2.Items.Add(new Id3v2FrameListViewItem(listViewV2.Groups, frame));
            }
            if (!GenreDone)
            {
                Frame frame = new Frame();
                frame.ID = FrameIDs.Genre;
                frame.Data = AudioInfoTools.ToByteArray(textBoxGenre1.Text);
                listViewV2.Items.Add(new Id3v2FrameListViewItem(listViewV2.Groups, frame));
            }
            if (!CommentDone)
            {
                Frame frame = new Frame();
                frame.ID = FrameIDs.Comments;
                frame.Data = AudioInfoTools.ToByteArray(textBoxComment1.Text);
                listViewV2.Items.Add(new Id3v2FrameListViewItem(listViewV2.Groups, frame));
            }

            // Select the id3v2 tab
            tabControlTags.SelectedIndex = 1;

            listViewV2.Refresh();
        }

        /// <summary>
        /// Sent when the "Reset v1" button is clicked.
        /// Resets the version 1 fields to their original values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResetV1_Click(object sender, EventArgs e)
        {
            textBoxTitle1.Text = id3Original.V1Tag.Title;
            textBoxArtist1.Text = id3Original.V1Tag.Artist;
            textBoxAlbum1.Text = id3Original.V1Tag.Album;
            textBoxYear1.Text = id3Original.V1Tag.Year.ToString().PadLeft(4, '0');
            textBoxTrack1.Text = id3Original.V1Tag.Track.ToString().PadLeft(3, '0');
            textBoxGenre1.Text = id3Original.V1Tag.Genre.ToString().PadLeft(3, '0');
            textBoxComment1.Text = id3Original.V1Tag.Comment;
        }

        /// <summary>
        /// Sent when the "Reset v2" button is clicked.
        /// Resets the version 2 fields to their original values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResetV2_Click(object sender, EventArgs e)
        {
            listViewV2.Items.Clear();

            foreach (Frame f in id3Original.V2Tag.Frames)
            {
                Id3v2FrameListViewItem item = new Id3v2FrameListViewItem(listViewV2.Groups, f);

                if (f.Data != null)
                    listViewV2.Items.Add(item);
            }
        }

        /// <summary>
        /// Sent when the "Clear v1" button is clicked.
        /// Clears all the version 1 fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearV1_Click(object sender, EventArgs e)
        {
            textBoxTitle1.Text = "";
            textBoxArtist1.Text = "";
            textBoxAlbum1.Text = "";
            textBoxYear1.Text = "";
            textBoxTrack1.Text = "";
            textBoxGenre1.Text = "";
            textBoxComment1.Text = "";
        }

        /// <summary>
        /// Sent when the "Clear v2" button is clicked.
        /// Clears all the version 2 fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearV2_Click(object sender, EventArgs e)
        {
            listViewV2.Items.Clear();
        }

        /// <summary>
        /// Sent when the "Invalid Tags!" link label is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelInvalidTag_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AudioInfoTools.ShowAllErrors(Errors);
        }

        /// <summary>
        /// Sent when the v1 comment field text is changed.
        /// Check to see if the comment is a valid url and shows the Go! link label
        /// if it is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxComment1_TextChanged(object sender, EventArgs e)
        {
            linkLabelComment.Visible = AudioInfoTools.IsUrl(textBoxComment1.Text);
        }

        /// <summary>
        /// Sent when the track v1 text box loses focus.
        /// Checks to make sure its value is less than 256.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTrack1_Leave(object sender, EventArgs e)
        {
            if (int.Parse(textBoxTrack1.Text) > 255)
            {
                MessageBox.Show("Track must be 255 or under", "AudioInfo Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTrack1.Focus();
            }
        }

        /// <summary>
        /// Sent when the genre v1 text box loses focus.
        /// Checks to make sure its value is less than 256.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxGenre1_Leave(object sender, EventArgs e)
        {
            if (int.Parse(textBoxGenre1.Text) > 255)
            {
                MessageBox.Show("Genre must be 255 or under", "AudioInfo Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxGenre1.Focus();
            }
        }

        /// <summary>
        /// Sent when the comment "Go!" link label is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelComment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "\"" + textBoxComment1.Text + "\"");
        }

        /// <summary>
        /// Loads the ID3 tags from the file FileName.
        /// </summary>
        private void LoadID3()
        {
            if (FileName == "") return;

            ID3 id3 = new ID3(FileName);

            textBoxFileName.Text = "";
            Text = "AudioInfo";

            // Clear the errors
            if (Errors != null)
                Errors.Clear();

            // Try to read version 1 tags
            Id3Result result = id3.ReadV1Tag();

            linkLabelInvalidTag.Visible = false;

            #region Checking result of read ID3v1

            if ((result == Id3Result.Success) || (result == Id3Result.InvalidTag))
            {
                if (result == Id3Result.InvalidTag)
                    linkLabelInvalidTag.Visible = true;

                tabControlTags.Enabled = true;
                tabPageV1.Enabled = true;
                checkBoxWriteV1.Checked = true;

                // Update all the fields
                textBoxTitle1.Text = id3.V1Tag.Title;
                textBoxArtist1.Text = id3.V1Tag.Artist;
                textBoxAlbum1.Text = id3.V1Tag.Album;
                textBoxYear1.Text = id3.V1Tag.Year.ToString().PadLeft(4, '0');

                textBoxTrack1.Text = id3.V1Tag.Track.ToString().PadLeft(3, '0');
                if (id3.V1Tag.Track == 0)
                    checkBoxDontWriteV11.Checked = true;
                else
                    checkBoxDontWriteV11.Checked = false;

                textBoxGenre1.Text = id3.V1Tag.Genre.ToString().PadLeft(3, '0');
                textBoxComment1.Text = id3.V1Tag.Comment;
            }
            else if (result == Id3Result.CannotOpenFile)
            {
                AudioInfoTools.ShowLastError(id3.Errors);

                tabControlTags.Enabled = false;
                checkBoxWriteV1.Checked = false;
                checkBoxWriteV2.Checked = false;

                checkBoxWriteV1.Checked = false;
                checkBoxWriteV2.Checked = false;
                checkBoxWriteV1.Enabled = false;
                checkBoxWriteV2.Enabled = false;
                tabPageV1.Enabled = false;
                tabPageV2.Enabled = false;
                buttonCommitChanges.Enabled = false;

                return;
            }
            else
            {
                // No tag
                tabControlTags.Enabled = true;
                tabPageV1.Enabled = false;
                checkBoxWriteV1.Checked = false;

                textBoxTitle1.Text = "";
                textBoxArtist1.Text = "";
                textBoxAlbum1.Text = "";
                textBoxYear1.Text = "";
                textBoxTrack1.Text = "";
                textBoxGenre1.Text = "";
                textBoxComment1.Text = "";
            }

            #endregion

            // Try to read version 2 tags
            result = id3.ReadV2Tag();

            listViewV2.Items.Clear();

            #region Checking result of read ID3v2

            if ((result == Id3Result.Success) || (result == Id3Result.InvalidTag))
            {
                if (result == Id3Result.InvalidTag)
                    linkLabelInvalidTag.Visible = true;

                tabControlTags.Enabled = true;
                tabPageV2.Enabled = true;
                checkBoxWriteV2.Checked = true;

                listViewV2.ShowGroups = true;

                foreach (Frame f in id3.V2Tag.Frames)
                {
                    Id3v2FrameListViewItem item = new Id3v2FrameListViewItem(listViewV2.Groups, f);

                    if (f.Data != null)
                        listViewV2.Items.Add(item);
                }
            }
            else if (result == Id3Result.CannotOpenFile)
            {
                MessageBox.Show("Failed to open file.", "AudioInfo Error #472", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tabControlTags.Enabled = false;
                checkBoxWriteV1.Checked = false;
                checkBoxWriteV2.Checked = false;

                checkBoxWriteV1.Checked = false;
                checkBoxWriteV2.Checked = false;
                checkBoxWriteV1.Enabled = false;
                checkBoxWriteV2.Enabled = false;
                tabPageV1.Enabled = false;
                tabPageV2.Enabled = false;
                buttonCommitChanges.Enabled = false;

                return;
            }
            else
            {
                // No tag
                tabControlTags.Enabled = true;
                tabPageV2.Enabled = false;
                checkBoxWriteV2.Checked = false;
            }

            listViewV2.ShowGroups = checkBoxShowInGroups.Checked;

            #endregion

            // Both tags were read, now enable buttons and menu items
            buttonCommitChanges.Enabled = true;
            commitChangesToolStripMenuItem.Enabled = true;
            revertToSavedToolStripMenuItem.Enabled = true;
            resetAllToolStripMenuItem.Enabled = true;
            clearAllToolStripMenuItem.Enabled = true;
            checkBoxWriteV1.Enabled = true;
            checkBoxWriteV2.Enabled = true;

            // Set control text
            textBoxFileName.Text = FileName;
            Text = "AudioInfo - " + System.IO.Path.GetFileName(FileName);

            Errors = id3.Errors;
            id3Original = id3;
        }

        /// <summary>
        /// Sent when the "Commit Changes" button is clicked.
        /// Saves the changes to the open file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCommitChanges_Click(object sender, EventArgs e)
        {
            if (FileName == "") return;

            ID3 id3 = new ID3(FileName);

            // Copy the fields to id3

            // First the version 1 tag
            id3.V1Tag.Title = textBoxTitle1.Text;
            id3.V1Tag.Artist = textBoxArtist1.Text;
            id3.V1Tag.Album = textBoxAlbum1.Text;
            id3.V1Tag.Year = int.Parse(textBoxYear1.Text);
            id3.V1Tag.Track = int.Parse(textBoxTrack1.Text);
            id3.V1Tag.Genre = int.Parse(textBoxGenre1.Text);
            id3.V1Tag.Comment = textBoxComment1.Text;

            // Then the version 2 tag
            id3.V2Tag.Unsynchronization = Unsynchronization;
            id3.V2Tag.Experimental = Experimental;
            id3.V2Tag.AddFooter = AddFooter;
            id3.V2Tag.AddPadding = AddPadding;
            id3.V2Tag.PaddingSizeType = PaddingSizeType;
            id3.V2Tag.PaddingSizeValue = PaddingSizeValue;

            foreach (Id3v2FrameListViewItem item in listViewV2.Items)
            {
                if (item.Checked)
                    id3.V2Tag.Frames.Add(item.Frame);
            }

            id3.WriteTags(checkBoxWriteV1.Checked, checkBoxWriteV2.Checked);

            LoadID3();
        }

        /// <summary>
        /// Sent when the selected index of the list view changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewV2.SelectedIndices.Count == 0)
            {
                // No selection
                buttonRemove.Enabled = false;
                buttonEditFrame.Enabled = false;
                buttonTextEditor.Enabled = false;
                buttonBinaryEditor.Enabled = false;
            }
            else
            {
                // There is a selected item
                buttonRemove.Enabled = true;
                buttonEditFrame.Enabled = true;
                buttonTextEditor.Enabled = true;
                buttonBinaryEditor.Enabled = true;
            }
        }

        private void buttonAddFrame_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditFrame_Click(object sender, EventArgs e)
        {

        }

        private void buttonTextEditor_Click(object sender, EventArgs e)
        {

        }

        private void buttonBinaryEditor_Click(object sender, EventArgs e)
        {

        }
    }
}