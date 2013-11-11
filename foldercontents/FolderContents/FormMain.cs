using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FolderContents
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            string folderName = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);

            string[] files = System.IO.Directory.GetFiles(folderName);

            textBoxFiles.Text = "";

            foreach (string file in files)
            {
                textBoxFiles.Text += System.IO.Path.GetFileName(file) + "\r\n";
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            textBoxFiles.SelectAll();
            textBoxFiles.Copy();
            textBoxFiles.Select(0, 0);
        }
    }
}