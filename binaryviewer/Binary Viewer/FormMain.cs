//
// Copyright (c) Vaughn Friesen
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Binary_Viewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            // Update tool strip
            toolStripProgressBarLoading.Visible = true;
            toolStripStatusLabelLoading.Visible = true;
            SetProgress(0);

            // Clear text boxes
            richTextBoxDecimal.Text = "";
            richTextBoxHex.Text = "";
            richTextBoxBinary.Text = "";

            // Init some variables
            byte[] bytes;
            bool Finished = false;
            string s = "";
            int BytesRead = 0;

            // First read into textBoxText
            richTextBoxText.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);

            // 25% done (approx.)
            SetProgress(25);

            // Open the file for reading
            System.IO.BinaryReader reader = new System.IO.BinaryReader(System.IO.File.Open(openFileDialog.FileName, System.IO.FileMode.Open));
            long FileLength = reader.BaseStream.Length;
            reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

            // Next read into richTextBoxDecimal
            while (!Finished)
            {
                bytes = reader.ReadBytes(1024);
                if (bytes.Length < 1024)
                    Finished = true;

                BytesRead += bytes.Length;

                s += ByteArrayToDecimalString(bytes);

                SetProgress((int)(25 + 25 * ((float)BytesRead / (float)FileLength)));
            }

            richTextBoxDecimal.Text = s;

            // 50% done
            SetProgress(50);

            // Get ready for the next read
            s = "";
            reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            BytesRead = 0;
            Finished = false;

            // Next read into richTextBoxHex
            while (!Finished)
            {
                bytes = reader.ReadBytes(1024);
                if (bytes.Length < 1024)
                    Finished = true;

                BytesRead += bytes.Length;

                s += ByteArrayToHexString(bytes);

                SetProgress((int)(50 + 25 * ((float)BytesRead / (float)FileLength)));
            }

            richTextBoxHex.Text = s;

            // 75% done
            SetProgress(75);

            // Get ready for the next read
            s = "";
            reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            BytesRead = 0;
            Finished = false;

            // Next read into richTextBoxHex
            while (!Finished)
            {
                bytes = reader.ReadBytes(1024);
                if (bytes.Length < 1024)
                    Finished = true;

                BytesRead += bytes.Length;

                s += ByteArrayToBinaryString(bytes);

                SetProgress((int)(75 + 25 * ((float)BytesRead / (float)FileLength)));
            }

            richTextBoxBinary.Text = s;

            // All done
            SetProgress(100);

            // Finished, hide progress messages
            toolStripProgressBarLoading.Visible = false;
            toolStripStatusLabelLoading.Visible = false;
        }

        private void SetProgress(int Value)
        {
            toolStripProgressBarLoading.Value = Value;
            toolStripStatusLabelLoading.Text = "Loading... " + Value + "%";

            statusStrip.Refresh();
        }

        private string ByteArrayToDecimalString(byte[] bytes)
        {
            string s = "";

            for (int x = 0; x < bytes.Length; x++)
                s += Convert.ToDecimal(bytes[x]) + " ";

            return s;
        }

        private string ByteArrayToHexString(byte[] bytes)
        {
            string s = "";

            for (int x = 0; x < bytes.Length; x++)
                s += bytes[x].ToString("X") + " ";

            return s.Trim();
        }

        private string ByteArrayToBinaryString(byte[] bytes)
        {
            string s = "";

            for (int x = 0; x < bytes.Length; x++)
            {
                byte b = bytes[x];
                byte num = 128;

                while (true)
                {
                    if (b - num > 0)
                    {
                        b -= num;
                        s += "1";
                    }
                    else
                        s += "0";

                    if (num > 1)
                        num /= 2;
                    else
                        break;
                }

                s += " ";
            }

            return s.Trim();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBoxText.Left = 13;
            groupBoxText.Width = this.Width - 33;
            groupBoxText.Visible = true;
            groupBoxDecimal.Visible = false;
            groupBoxHex.Visible = false;
            groupBoxBinary.Visible = false;
        }

        private void restoreAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBoxText.Left = 13;
            groupBoxText.Width = 179;

            groupBoxDecimal.Left = 198;
            groupBoxDecimal.Width = 154;

            groupBoxHex.Left = 358;
            groupBoxHex.Width = 148;

            groupBoxBinary.Left = 512;
            groupBoxBinary.Width = this.Width - 532;

            groupBoxText.Visible = true;
            groupBoxDecimal.Visible = true;
            groupBoxHex.Visible = true;
            groupBoxBinary.Visible = true;
        }

        private void decimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBoxDecimal.Left = 13;
            groupBoxDecimal.Width = this.Width - 33;
            groupBoxDecimal.Visible = true;
            groupBoxText.Visible = false;
            groupBoxHex.Visible = false;
            groupBoxBinary.Visible = false;
        }

        private void hexadecimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBoxHex.Left = 13;
            groupBoxHex.Width = this.Width - 33;
            groupBoxHex.Visible = true;
            groupBoxText.Visible = false;
            groupBoxDecimal.Visible = false;
            groupBoxBinary.Visible = false;
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBoxBinary.Left = 13;
            groupBoxBinary.Width = this.Width - 33;
            groupBoxBinary.Visible = true;
            groupBoxText.Visible = false;
            groupBoxDecimal.Visible = false;
            groupBoxHex.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}