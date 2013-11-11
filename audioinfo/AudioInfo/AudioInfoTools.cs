using System;
using System.Collections.Generic;
using System.Text;

namespace AudioInfo
{
    public class AudioInfoTools
    {
        public static void ShowLastError(List<Error> Errors)
        {
            if (Errors.Count > 0)
                Errors[Errors.Count - 1].ShowMessage();
        }

        public static void ShowAllErrors(List<Error> Errors)
        {
            string Message = "AudioInfo encountered the following errors:\n";

            if (Errors.Count == 0)
                Message += "No errors";
            else
                foreach (Error e in Errors)
                    Message += "\nError #" + e.Number + ": " + e.Description;

            Message += "\n\nThese will be fixed when you save the current file.";

            System.Windows.Forms.MessageBox.Show(Message, "AudioInfo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static char[] ToCharArray(byte[] Input)
        {
            if (Input == null)
                return new char[0];

            char[] ret = new char[Input.Length];

            for (int x = 0; x < Input.Length; x++)
                ret[x] = (char)Input[x];

            return ret;
        }

        public static string ToString(byte[] Input)
        {
            if (Input == null)
                return "";

            string ret = "";

            for (int x = 0; x < Input.Length; x++)
                ret += (char)Input[x];

            return ret;
        }

        public static byte[] ToByteArray(string Input)
        {
            byte[] ret = new byte[Input.Length];

            for (int x = 0; x < Input.Length; x++)
                ret[x] = (byte)Input[x];

            return ret;
        }

        public static bool IsUrl(string Url)
        {
            if (Url == "") return false;

            if (Url.IndexOf(' ') >= 0) return false;

            if ((Url.Length > 7) && (Url.Substring(0, 7) == "http://")) return true;

            if (Url.IndexOf('/') >= 0) return true;

            if ((Url.Length > 3) && (Url.Substring(0, 3) == "www")) return true;

            return false;
        }
    }
}
