using System;
using System.Collections.Generic;
using System.Text;
using AudioInfo;
using AudioInfo.ID3;

namespace AudioInfoProgram
{
    class Id3v2FrameListViewItem : System.Windows.Forms.ListViewItem
    {
        Frame m_Frame;

        public Frame Frame
        { get { return m_Frame; } }

        public Id3v2FrameListViewItem(System.Windows.Forms.ListViewGroupCollection Groups, Frame Frame)
        {
            this.m_Frame = Frame;

            if (Frame.Data != null)
            {
                // Set the frame id
                Text = Frame.ID.ToString();
                Checked = true;

                // Set the name
                bool Found = false;
                foreach (FrameID id in FrameIDs.All)
                {
                    if (Frame.ID.CompareID(id))
                    {
                        SubItems.Add(id.Description);
                        Found = true;
                        break;
                    }
                }
                if (!Found)
                    SubItems.Add("");

                // Set the data
                if (Frame.Data.Length > 1000)
                {
                    byte[] str = new byte[1000];
                    for (int x = 0; x < 1000; x++)
                        str[x] = Frame.Data[x];
                    SubItems.Add(AudioInfoTools.ToString(str));
                }
                else
                    SubItems.Add(AudioInfoTools.ToString(Frame.Data));

                // Set the official description
                Found = false;
                foreach (FrameID id in FrameIDs.All)
                {
                    if (Frame.ID.CompareID(id))
                    {
                        SubItems.Add(id.OfficialDescription);
                        Found = true;
                        break;
                    }
                }
                if (!Found)
                    SubItems.Add("");

                // Add to one of the groups
                if (Frame.ID[0] == 'T')
                    Group = Groups[0];
                else if (Frame.ID[0] == 'W')
                    Group = Groups[1];
                else if (Frame.ID.ToString() == "PRIV")
                    Group = Groups[2];
                else if ((Frame.ID[0] == 'X') || (Frame.ID[0] == 'Y') ||
               (Frame.ID[0] == 'Z'))
                    Group = Groups[3];
                else
                    Group = Groups[4];
            }
        }
    }
}
