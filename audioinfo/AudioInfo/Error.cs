using System;
using System.Collections.Generic;
using System.Text;

namespace AudioInfo
{
    public class Error
    {
        public Error() { }

        public Error(int Number, string Description)
        {
            this.Number = Number;
            this.Description = Description;
        }

        public int Number;
        public string Description;

        public void ShowMessage()
        {
            System.Windows.Forms.MessageBox.Show(Description, "AudioInfo Error #" + Number, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
