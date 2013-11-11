using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNET_Tests.ImageTools
{
    public partial class Stretch : Form
    {
        Size StartSize;

        internal Size NewSize;

        public Stretch(Size StartSize)
        {
            InitializeComponent();

            this.StartSize = StartSize;
        }

        private void Stretch_Load(object sender, EventArgs e)
        {
            labelCurrentSize.Text = "Size: " + StartSize.Width + " x " + StartSize.Height;

            textBoxWidth.Text = "" + StartSize.Width;
            textBoxHeight.Text = "" + StartSize.Height;

            CenterToParent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            NewSize = StartSize;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            NewSize = new Size();

            try { NewSize.Width = int.Parse(textBoxWidth.Text); }
            catch
            {
                MessageBox.Show("Width is invalid.", "Error", 0, MessageBoxIcon.Error);
                textBoxWidth.Focus();
                textBoxWidth.SelectAll();

                return;
            }

            try { NewSize.Height = int.Parse(textBoxHeight.Text); }
            catch
            {
                MessageBox.Show("Height is invalid.", "Error", 0, MessageBoxIcon.Error);
                textBoxHeight.Focus();
                textBoxHeight.SelectAll();

                return;
            }

            Close();
        }
    }
}