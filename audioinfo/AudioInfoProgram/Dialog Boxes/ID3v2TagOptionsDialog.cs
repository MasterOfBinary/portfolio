using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AudioInfo.ID3;

namespace AudioInfoProgram.Dialog_Boxes
{
    public partial class ID3v2TagOptionsDialog : Form
    {
        readonly FormMain m_Parent;

        public ID3v2TagOptionsDialog(FormMain Parent)
        {
            m_Parent = Parent;

            InitializeComponent();
        }

        private void checkBoxAddPadding_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAddPadding.Checked)
                checkBoxAddFooter.Checked = false;

            groupBoxPaddingLength.Enabled = checkBoxAddPadding.Checked;
        }

        private void checkBoxAddFooter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAddFooter.Checked)
                checkBoxAddPadding.Checked = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_Parent.Unsynchronization = checkBoxUnsynchronization.Checked;
            m_Parent.Experimental = checkBoxExperimental.Checked;
            m_Parent.AddFooter = checkBoxAddFooter.Checked;
            m_Parent.AddPadding = checkBoxAddPadding.Checked;

            if (radioButtonFixed.Checked)
            {
                m_Parent.PaddingSizeType = PaddingSize.Fixed;
                m_Parent.PaddingSizeValue = int.Parse(comboBoxSize.Text);
            }
            else if (radioButtonRoundFileSize.Checked)
            {
                m_Parent.PaddingSizeType = PaddingSize.RoundFileSize;
                m_Parent.PaddingSizeValue = int.Parse(comboBoxRoundTo.Text);
            }
            else if (radioButtonPercentOfTag.Checked)
            {
                m_Parent.PaddingSizeType = PaddingSize.PercentOfTag;
                m_Parent.PaddingSizeValue = int.Parse(comboBoxPercent.Text);
            }

            Close();
        }

        private void radioButtonFixed_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSize.Enabled = radioButtonFixed.Checked;
            labelBytes1.Enabled = radioButtonFixed.Checked;
        }

        private void radioButtonRoundFileSize_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxRoundTo.Enabled = radioButtonRoundFileSize.Checked;
            labelBytes2.Enabled = radioButtonRoundFileSize.Checked;
        }

        private void radioButtonPercentOfTag_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxPercent.Enabled = radioButtonPercentOfTag.Checked;
            labelPercent.Enabled = radioButtonPercentOfTag.Checked;
        }

        private void checkBoxAddExtendedHeader_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxExtendedHeader.Enabled = checkBoxAddExtendedHeader.Checked;
        }

        private void comboBoxSize_Leave(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSize.Text != "")
                    int.Parse(comboBoxSize.Text);
            }
            catch
            {
                MessageBox.Show("Invalid number", "AudioInfo Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comboBoxSize.Focus();
            }
        }

        private void comboBoxRoundTo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRoundTo.Text != "")
                    int.Parse(comboBoxRoundTo.Text);
            }
            catch
            {
                MessageBox.Show("Invalid number", "AudioInfo Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comboBoxSize.Focus();
            }
        }

        private void comboBoxPercent_Leave(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPercent.Text != "")
                    int.Parse(comboBoxPercent.Text);
            }
            catch
            {
                MessageBox.Show("Invalid number", "AudioInfo Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comboBoxSize.Focus();
            }
        }
    }
}