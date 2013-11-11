using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DotNET_Tests
{
    public partial class TransparencyTest : Form
    {
        int Frame = 1;
        Color TransparentColor = Color.FromArgb(234, 78, 195);

        public TransparencyTest()
        {
            InitializeComponent();
        }

        internal void OpenForm()
        {
            timer.Enabled = true;

            this.BackColor = TransparentColor;
            this.TransparencyKey = TransparentColor;
            this.TopMost = true;

            ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (++Frame > 90)
            {
                Frame = 90;
                timer.Enabled = false;
                buttonExit.Visible = true;
                buttonNext.Visible = true;
            }

            Refresh();
        }

        private void FormTest_Paint(object sender, PaintEventArgs e)
        {
            // Draw an opening animation
            // The first 60 frames will be drawing the outside edge
            // The last 20 will be drawing the inside

            // First draw some text
            e.Graphics.DrawString(".NET Tests", new Font("NeuroChrome", 16, FontStyle.Bold), new SolidBrush(GetTextColor()), new PointF(100, 100));

            // -- First 60 frames --
            LinearGradientBrush OusideGradient = new LinearGradientBrush(new Point(0, 0), new Point(Width, Height), Color.Black, Color.LightGray);

            // First 20 frames - top edge
            if (Frame < 20)
            {
                int RectWidth = Frame * Width / 20;
                Rectangle rect = new Rectangle(0, 0, RectWidth, 12);

                e.Graphics.FillRectangle(OusideGradient, rect);

                return;
            }

            // Next 10 frames - right edge
            e.Graphics.FillRectangle(OusideGradient, new Rectangle(0, 0, Width, 12));

            if (Frame < 30)
            {
                int RectHeight = (Frame - 20) * Height / 10;
                Rectangle rect = new Rectangle(Width - 12, 0, 12, RectHeight);

                e.Graphics.FillRectangle(OusideGradient, rect);

                return;
            }

            // Next 20 frames - bottom edge
            e.Graphics.FillRectangle(OusideGradient, new Rectangle(Width - 12, 0, 12, Height));

            if (Frame < 50)
            {
                int RectWidth = (Frame - 30) * Width / 20;
                Rectangle rect = new Rectangle(Width - RectWidth, Height - 12, RectWidth, 12);

                e.Graphics.FillRectangle(OusideGradient, rect);

                return;
            }

            // Next 10 frames - left edge
            e.Graphics.FillRectangle(OusideGradient, new Rectangle(0, Height - 12, Width, 12));

            if (Frame < 60)
            {
                int RectHeight = (Frame - 50) * Width / 10;
                Rectangle rect = new Rectangle(0, Height - RectHeight, 12, RectHeight);

                e.Graphics.FillRectangle(OusideGradient, rect);

                return;
            }

            // -- Last 20 frames --
            e.Graphics.FillRectangle(OusideGradient, new Rectangle(0, 0, 12, Height));

            LinearGradientBrush InsideGradient = new LinearGradientBrush(new Point(Width, Height), new Point(0, 0), Color.DimGray, Color.FromArgb(120, 120, 140));

            e.Graphics.Clip = new Region(new Rectangle(12, 12, Width - 24, Height - 24));
            e.Graphics.FillRectangle(InsideGradient, new Rectangle(12, 12, Width - 24, Height - 24));

            if (Frame < 80)
            {
                // Draw a transparent ellipse
                int EllipseTop = Height / 20 * (Frame - 60);
                int EllipseLeft = Width / 20 * (Frame - 60);
                Rectangle EllipseRect = new Rectangle(EllipseLeft, EllipseTop, Width + (Width - EllipseLeft), Height + (Height - EllipseTop));

                e.Graphics.FillEllipse(new SolidBrush(this.TransparentColor), EllipseRect);

                e.Graphics.DrawString(".NET Tests", new Font("NeuroChrome", 16, FontStyle.Bold), new SolidBrush(GetTextColor()), new PointF(100, 100));

                return;
            }

            e.Graphics.DrawString(".NET Tests", new Font("NeuroChrome", 16, FontStyle.Bold), new SolidBrush(GetTextColor()), new PointF(100, 100));
        }

        private Color GetTextColor()
        {
            int Red = 255 / 80 * Frame;

            return Color.FromArgb(Red < 255 ? Red : 255, 0, 0);
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Hide();
            TransparencyTest2 tt2 = new TransparencyTest2();
            tt2.OpenForm();
            Close();
        }
    }
}