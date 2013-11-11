using System;
using System.Collections.Generic;
using System.Text;

namespace DotNET_Tests
{
    class Tools
    {
        internal static void Error(string error)
        {
            System.Windows.Forms.MessageBox.Show(error, ".NET Tests Error", 0, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
