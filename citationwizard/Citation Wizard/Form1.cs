using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Citation_Wizard
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            // Long citation
            StringBuilder output = new StringBuilder();

            if (textBoxAuthor.Text.Length != 0)
            {
                output.Append(textBoxAuthor.Text);
                output.Append(". ");
            }

            if (textBoxArticle.Text.Length != 0)
            {
                output.Append("“");
                output.Append(textBoxArticle.Text);
                output.Append(".” ");
            }

            if (textBoxWebsite.Text.Length != 0)
            {
                output.Append("*");
                output.Append(textBoxWebsite.Text);
                output.Append(".* ");
            }

            if (textBoxPublisher.Text.Length != 0)
                output.Append(textBoxPublisher.Text);
            else
                output.Append("n.p.");

            output.Append(", ");

            if (dateTimePickerDate.Value <= DateTime.Now)
                output.Append(dateTimePickerDate.Value.ToString("d MMM. yyyy. "));
            else
                output.Append("n.d. ");

            output.Append("Web. ");

            if (dateTimePickerRetrieved.Value <= DateTime.Now)
                output.Append(dateTimePickerRetrieved.Value.ToString("d MMM. yyyy. "));

            if (textBoxURL.Text.Length != 0)
            {
                output.Append("<");
                output.Append(textBoxURL.Text);
                output.Append("> ");
            }

            textBoxCitation.Text = output.ToString().Trim();

            // In text citation
            output = new StringBuilder("(");

            if (textBoxAuthor.Text.Length != 0)
                output.Append(textBoxAuthor.Text.Substring(0, textBoxAuthor.Text.IndexOf(",")));
            else if (textBoxArticle.Text.Length != 0)
                output.Append("“" + textBoxArticle.Text + "”");
            else if (textBoxWebsite.Text.Length != 0)
                output.Append("*" + textBoxWebsite.Text + "*");

            output.Append(")");

            textBoxInText.Text = output.ToString();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dateTimePickerDate.Format = dateTimePickerRetrieved.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = dateTimePickerRetrieved.CustomFormat = "MMMM d, yyyy";
        }
    }
}
