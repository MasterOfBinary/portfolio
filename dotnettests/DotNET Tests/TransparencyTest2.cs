using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNET_Tests
{
    public partial class TransparencyTest2 : Form
    {
        Color TransparentColor = Color.FromArgb(234, 78, 195);

        public TransparencyTest2()
        {
            InitializeComponent();
        }

        internal void OpenForm()
        {
            this.BackColor = TransparentColor;
            this.TransparencyKey = TransparentColor;
            this.TopMost = true;

            ShowDialog();
        }

        private void TransparencyTest4_Paint(object sender, PaintEventArgs e)
        {
            // Draw a background gradient
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(Width, Height), Color.SteelBlue, Color.GreenYellow);
            CreateGraphics().FillEllipse(brush, new Rectangle(0, 0, Width, Height));
            
        }

        private void TransparencyTest4_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}