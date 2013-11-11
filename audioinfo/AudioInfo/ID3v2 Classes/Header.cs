using System;
using System.Collections.Generic;
using System.Text;

namespace AudioInfo
{
    namespace ID3
    {
        /// <summary>
        /// An ID3v2 header
        /// </summary>
        internal class Header
        {
            /// <summary>
            /// The constructor
            /// </summary>
            public Header()
            { }

            /// <summary>
            /// Copy constructor
            /// </summary>
            /// <param name="Copy">The Header object to copy</param>
            public Header(Header Copy)
            {
                MajorVersion = Copy.MajorVersion;
                MinorVersion = Copy.MinorVersion;
                Flags = Copy.Flags;
                Size = Copy.Size;
            }

            public byte MajorVersion, MinorVersion; // Version # is 16 bits
            public byte Flags; // Flags is 8 bits
            public uint Size; // Size is 32 bits

            // Some friendly functions
            public void SetVersion(byte Major, byte Minor)
            {
                MajorVersion = Major;
                MinorVersion = Minor;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Header">A 10-byte long header</param>
            /// <returns>true if successful, false otherwise</returns>
            public bool GetFromBytes(byte[] Header)
            {
                if (Header.Length != 10) return false;

                if ((Header[0] != 'I') || (Header[1] != 'D') || (Header[2] != '3'))
                    return false;

                MajorVersion = Header[3];
                MinorVersion = Header[4];

                Flags = Header[5];

                Size = (uint)(Header[6] << 21);
                Size += (uint)(Header[7] << 14);
                Size += (uint)(Header[8] << 7);
                Size += (uint)Header[9];

                return true;
            }

            /// <summary>
            /// Writes the header to the current position in the bitstream.
            /// </summary>
            /// <param name="writer"></param>
            internal void Write(System.IO.BinaryWriter writer)
            {
                // Version is 2.4.0
                MajorVersion = 4;
                MinorVersion = 0;

                // Write tag id
                writer.Write(AudioInfoTools.ToByteArray("ID3"));
                // Write version
                writer.Write((byte)MajorVersion);
                writer.Write((byte)MinorVersion);
                // Write flags
                writer.Write(Flags);
                // Write size
                writer.Write((byte)((Size >> 21) & 0x7fu));
                writer.Write((byte)((Size >> 14) & 0x7fu));
                writer.Write((byte)((Size >> 7) & 0x7fu));
                writer.Write((byte)(Size & 0x7fu));
            }
        }
    }
}
