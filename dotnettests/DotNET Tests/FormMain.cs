using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNET_Tests
{
    public partial class FormMain : Form
    {
        Bitmap background;

        Color TextColor = Color.Red;
        bool ToOrange = true;

        const int FadeInTime = 800, FadeOutTime = 500; // Fade times in ms

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            background = global::DotNET_Tests.Properties.Resources.My_Cool_Picture;

            if (background == null) return;

            Width = background.Width;
            Height = background.Height;

            this.CenterToScreen();

            // Fade in the window
            this.Opacity = 0;
            this.Show();

            DateTime Start = DateTime.Now;

            // Fade in
            while (((TimeSpan)(DateTime.Now - Start)).TotalMilliseconds < FadeInTime)
            {
                this.Opacity = ((TimeSpan)(DateTime.Now - Start)).TotalMilliseconds / FadeInTime;
                this.Refresh();
            }

            this.Opacity = 1;

            timer.Enabled = true;

            buttonGraphicsAndTransparency.Visible = true;
            buttonImaging.Visible = true;
            buttonAssembly.Visible = true;
            buttonAudio.Visible = true;
            linkLabelGoToMicrosoftCom.Visible = true;
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            if (background == null) return;

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            e.Graphics.DrawImage(background, 0, 0, Width, Height);
            e.Graphics.DrawString(".NET Tests", new Font("NeuroChrome", 16), new SolidBrush(TextColor), new PointF(20, 260));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ToOrange)
            {
                // To Orange
                if (TextColor.G + 5 > 180)
                    ToOrange = false;
                else
                    TextColor = Color.FromArgb(255, TextColor.G + 5, 0);
            }
            else
            {
                // To red
                if (TextColor.G - 5 < 0)
                    ToOrange = true;
                else
                    TextColor = Color.FromArgb(255, TextColor.G - 5, 0);
            }

            Refresh();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DateTime Start = DateTime.Now;

            buttonGraphicsAndTransparency.Visible = false;
            buttonImaging.Visible = false;
            buttonAssembly.Visible = false;
            buttonAudio.Visible = false;
            linkLabelGoToMicrosoftCom.Visible = false;
            menuStrip.Visible = false;

            // Fade out
            while (((TimeSpan)(DateTime.Now - Start)).TotalMilliseconds < FadeOutTime)
            {
                this.Opacity = 1 - (((TimeSpan)(DateTime.Now - Start)).TotalMilliseconds / FadeOutTime);
                this.Refresh();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y <= 24)
                menuStrip.Visible = true;
            else
                menuStrip.Visible = false;
        }

        private void buttonGraphicsAndTransparency_Click(object sender, EventArgs e)
        {
            Hide();
            TransparencyTest ft = new TransparencyTest();
            ft.OpenForm();
            TopMost = true;
            Show();
        }

        private void buttonImaging_Click(object sender, EventArgs e)
        {
   
            Hide();
            ImageForm frm = new ImageForm();
            frm.ShowDialog();
            TopMost = true;
            Show();
        }

        private void buttonAssembly_Click(object sender, EventArgs e)
        {
            throw new Exception("Method not yet implemented");
        }

        private void buttonAudio_Click(object sender, EventArgs e)
        {
            Hide();
            AudioTest frm = new AudioTest();
            frm.ShowDialog();
            TopMost = true;
            Show();
        }

        private void linkLabelGoToMicrosoftCom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.microsoft.com");
        }
    }
}