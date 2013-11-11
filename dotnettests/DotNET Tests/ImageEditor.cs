using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNET_Tests
{
    public partial class ImageEditor : Form
    {
        Bitmap image;
        ImageForm parent;

        public ImageEditor(ImageForm parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            ResizeRedraw = true;
        }

        internal void LoadImage(Bitmap image)
        {
            this.image = image;

            this.ClientSize = new Size(image.Size.Width, image.Size.Height + 40);

            PaintImage(this.CreateGraphics());
        }

        private void ImageEditor_Paint(object sender, PaintEventArgs e)
        {
            PaintImage(e.Graphics);
        }

        private void PaintImage(Graphics g)
        {
            g.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(Width, Height), Color.LightSkyBlue, Color.MediumSeaGreen), new Rectangle(0, 0, Width, Height));
            g.DrawImage(image, 0, 0, image.Width, image.Height);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime start = DateTime.Now;
            int StartHeight = this.ClientSize.Height;

            do
            {
                float percentElapsed = (float)(DateTime.Now - start).TotalMilliseconds / 500;
                this.ClientSize = new Size(this.ClientSize.Width, (int)(StartHeight - (percentElapsed * StartHeight)));
            } while ((DateTime.Now - start).TotalMilliseconds < 500);

            this.ClientSize = new Size(this.ClientSize.Width, 0);
        }

        private void ImageEditor_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip.Show(PointToScreen(e.Location));
        }

        private void ImageEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.ChildClosed();
        }

        private void strechImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageTools.Stretch s = new DotNET_Tests.ImageTools.Stretch(image.Size);

            s.ShowDialog();
        }
    }
}