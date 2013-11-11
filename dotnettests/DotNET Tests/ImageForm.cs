using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNET_Tests
{
    public partial class ImageForm : Form
    {
        ImageEditor editor;
        Bitmap CurrentImage;

        public ImageForm()
        {
            InitializeComponent();
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            contextMenuStrip.Items[0].Image = global::DotNET_Tests.Properties.Resources.DotNET_Tests;
            contextMenuStrip.Items[1].Image = global::DotNET_Tests.Properties.Resources.DotNet;
            contextMenuStrip.Items[2].Image = global::DotNET_Tests.Properties.Resources.My_Cool_Picture;
            contextMenuStrip.Items[3].Image = global::DotNET_Tests.Properties.Resources.Transparency;
            contextMenuStrip.Items[4].Image = global::DotNET_Tests.Properties.Resources.Squares;

            editor = new ImageEditor(this);
            editor.Show();

            LoadImage(global::DotNET_Tests.Properties.Resources.My_Cool_Picture);
        }

        private void LoadImage(Bitmap image)
        {
            editor.Close();
            editor = new ImageEditor(this);
            editor.Show();
            
            CurrentImage = image;

            pictureBoxThumb.Image = image;

            editor.LoadImage(image);

            checkBox1.Checked = true;
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == contextMenuStrip.Items[0])
                LoadImage(global::DotNET_Tests.Properties.Resources.DotNET_Tests);
            else if (sender == contextMenuStrip.Items[1])
                LoadImage(global::DotNET_Tests.Properties.Resources.DotNet);
            else if (sender == contextMenuStrip.Items[2])
                LoadImage(global::DotNET_Tests.Properties.Resources.My_Cool_Picture);
            else if (sender == contextMenuStrip.Items[3])
                LoadImage(global::DotNET_Tests.Properties.Resources.Transparency);
            else if (sender == contextMenuStrip.Items[4])
                LoadImage(global::DotNET_Tests.Properties.Resources.Squares);
        }

        private void ImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            editor.Close();
        }

        private void buttonFromResource_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(PointToScreen(new Point(buttonFromResource.Left, buttonFromResource.Bottom)), ToolStripDropDownDirection.BelowRight);
        }

        private void buttonFromFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            LoadImage(new Bitmap(openFileDialog.FileName));
        }

        internal void ChildClosed()
        {
            checkBox1.Checked = false;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                editor = new ImageEditor(this);
                editor.Show();

                LoadImage(CurrentImage);
            }
            else
                editor.Close();
        }
    }
}