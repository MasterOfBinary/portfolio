//
// Copyright (c) Vaughn Friesen
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Code_Counter
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void textBoxFolder_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxFolder.Text))
                buttonStart.Enabled = true;
            else
                buttonStart.Enabled = false;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textBoxFolder.Text = folderBrowserDialog.SelectedPath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBoxFolder.Text)) return;

            Refresh();

            int Count = 0;
            int NumberOfFiles = 0;

            foreach (string fileName in Directory.GetFiles(textBoxFolder.Text, textBoxExtension.Text, (checkBoxSubfolders.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)))
            {
                if ((textBoxSkip.Text != "") && (checkBoxSkip.Checked))
                {
                    // Make sure it isn't one of the skipped files
                    bool stop = false;
                    foreach (string file in Directory.GetFiles(Path.GetDirectoryName(fileName), textBoxSkip.Text))
                        if (file == fileName) stop = true;

                    if (stop) continue;
                }

                // Count the lines in the file
                StreamReader reader = new StreamReader(fileName);

                NumberOfFiles++;

                while (true)
                {
                    reader.ReadLine();
                    if (reader.EndOfStream) break;

                    Count++;
                }

                reader.Close();
            }

            // Format results
            string Lines = Count.ToString();
            string Files = NumberOfFiles.ToString();

            for (int x = Lines.Length - 3; x > 0; x -= 3)
                Lines = Lines.Insert(x, ",");

            for (int x = Files.Length - 3; x > 0; x -= 3)
                Files = Files.Insert(x, ",");

            // Show results
            labelResults.Text = "Results: " + Lines + " lines of code in " + Files + " files.";
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            timer.Enabled = checkBoxAutoUpdate.Checked;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            buttonStart_Click(buttonStart, e);
        }
    }
}