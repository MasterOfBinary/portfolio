//
// Copyright (c) Vaughn Friesen
//

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AudioInfo
{
    namespace ID3
    {
        /// <summary>
        /// An ID3v2 frame
        /// </summary>
        public class Frame
        {
            /// <summary>
            /// The constructor
            /// </summary>
            public Frame()
            { }

            public FrameID ID;
            public byte Flags1, Flags2;
            public byte EncodingDescriptor;
            public byte UserDescription;

            public byte[] Data;

            /// <summary>
            /// Gets the size of the header plus the actual data
            /// </summary>
            internal int Size
            {
                get
                {
                    if (AdjustedSize <= 1)
                        return 0;

                    // Adjusted size + 10 byte header
                    return AdjustedSize + 10;
                }
            }

            /// <summary>
            /// Gets the size of the actual data
            /// </summary>
            internal int AdjustedSize
            {
                get
                {
                    int size = 0;

                    if ((ID[0] == 'T') || (ID.CompareID(FrameIDs.Comments)) ||
                        (ID.CompareID(FrameIDs.UserDefinedUrlLinkFrame)))
                    {
                        // Encoding descriptor
                        size++;
                    }

                    if ((ID.CompareID(FrameIDs.UserDefinedUrlLinkFrame)) ||
                        (ID.CompareID(FrameIDs.UserDefinedTextInformationFrame)))
                    {
                        // User description
                        size++;
                    }

                    if (ID.CompareID(FrameIDs.Comments))
                    {
                        // Language and content descriptors
                        size += 4;
                    }

                    // Add the size of the content
                    size += Data.Length;

                    // Add 1 NULL byte
                    size += 1;

                    return size;
                }
            }

            /// <summary>
            /// Reads a frame
            /// </summary>
            /// <param name="reader"></param>
            /// <returns></returns>
            internal FrameResult Read(BinaryReader reader)
            {
                // Read the frame id
                byte[] ByteValue = new byte[4];

                ByteValue = reader.ReadBytes(4);

                // Check for padding
                if ((ByteValue[0] == 0) && (ByteValue[1] == 0) && (ByteValue[2] == 0) && (ByteValue[3] == 0))
                    return FrameResult.NoMoreFrames;

                ID = new FrameID(ByteValue);

                // Read the length
                ByteValue = reader.ReadBytes(4);

                uint Size = (new FrameID(ByteValue)).ToUInt();

                // Read header flags
                Flags1 = reader.ReadByte();
                Flags2 = reader.ReadByte();

                // TODO When this is updated, Size and Write must be updated also

                // Read the text encoding descriptor for some frame types
                if ((ID[0] == 'T') || (ID.CompareID(FrameIDs.Comments)) ||
                    (ID.CompareID(FrameIDs.UserDefinedUrlLinkFrame)))
                {
                    EncodingDescriptor = reader.ReadByte();
                    Size--;
                }

                // Read the user description for some frame types
                if ((ID.CompareID(FrameIDs.UserDefinedUrlLinkFrame)) ||
                    (ID.CompareID(FrameIDs.UserDefinedTextInformationFrame)))
                {
                    UserDescription = reader.ReadByte();
                    Size--;
                }

                // Some frames have language and content descriptors
                if (ID.CompareID(FrameIDs.Comments))
                {
                    reader.ReadBytes(4);
                    Size -= 4;
                }

                // Now we'll read the actual frame
                if (Size > 0)
                {
                    Data = new byte[Size];
                    Data = reader.ReadBytes((int)Size);
                }

                return FrameResult.Success;
            }

            /// <summary>
            /// Writes the frame
            /// </summary>
            /// <param name="writer"></param>
            internal void Write(BinaryWriter writer)
            {
                if (Size == 0)
                    return;

                // TODO Add support for unsynchronization

                // Write the ID
                byte[] id = new byte[4];
                uint Value = ID.ToUInt();
                for (int x = 3; x >= 0; x--)
                {
                    id[x] = (byte)(Value & 0xfful);
                    Value >>= 8;
                }
                writer.Write(id);

                // Write the size
                byte[] size = new byte[4];
                Value = (uint)AdjustedSize;
                for (int x = 3; x >= 0; x--)
                {
                    size[x] = (byte)(Value & 0xfful);
                    Value >>= 8;
                }
                writer.Write(size);

                // Write flags
                writer.Write(Flags1);
                writer.Write(Flags2);

                if ((ID[0] == 'T') || (ID.CompareID(FrameIDs.Comments)) ||
                    (ID.CompareID(FrameIDs.UserDefinedUrlLinkFrame)))
                {
                    // Write encoding descriptor
                    writer.Write(EncodingDescriptor);
                }

                if ((ID.CompareID(FrameIDs.UserDefinedUrlLinkFrame)) ||
                    (ID.CompareID(FrameIDs.UserDefinedTextInformationFrame)))
                {
                    // Write user description
                    writer.Write(UserDescription);
                }

                if (ID.CompareID(FrameIDs.Comments))
                {
                    // Write language and content descriptors
                    writer.Write(AudioInfoTools.ToByteArray("ENG"));

                    // Clear 1 byte to make content descriptor empty string
                    writer.Write((byte)0);
                }

                writer.Write(Data);

                // Add null character
                writer.Write((byte)0);
            }
        }

        /// <summary>
        /// An ID3v2 frame id
        /// </summary>
        public class FrameID
        {
            /// <summary>
            /// Constructor
            /// </summary>
            public FrameID()
            { Description = ""; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="Description">A string describing the frame id (for
            /// example, "Title")</param>
            public FrameID(string Description)
            { this.Description = Description; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="id">Array containing the four characters of the id</param>
            public FrameID(byte[] id)
            {
                if (id.Length == 4)
                    Set(id[0], id[1], id[2], id[3]);

                Description = "";
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="id">Array containing the four characters of the id</param>
            /// <param name="Description">A string describing the frame id (for
            /// example, "Title")</param>
            public FrameID(byte[] id, string Description)
            {
                if (id.Length == 4)
                    Set(id[0], id[1], id[2], id[3]);

                this.Description = Description;
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="a">First character of the frame id</param>
            /// <param name="b">Second character of the frame id</param>
            /// <param name="c">Third character of the frame id</param>
            /// <param name="d">Fourth character of the frame id</param>
            public FrameID(byte a, byte b, byte c, byte d)
            {
                Set(a, b, c, d);

                Description = "";
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="a">First character of the frame id</param>
            /// <param name="b">Second character of the frame id</param>
            /// <param name="c">Third character of the frame id</param>
            /// <param name="d">Fourth character of the frame id</param>
            /// <param name="Description">A string describing the frame id (for
            /// example, "Title")</param>
            public FrameID(byte a, byte b, byte c, byte d, string Description)
            {
                Set(a, b, c, d);

                this.Description = Description;
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="a">First character of the frame id</param>
            /// <param name="b">Second character of the frame id</param>
            /// <param name="c">Third character of the frame id</param>
            /// <param name="d">Fourth character of the frame id</param>
            public FrameID(char a, char b, char c, char d)
            {
                Set((byte)a, (byte)b, (byte)c, (byte)d);

                Description = "";
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="a">First character of the frame id</param>
            /// <param name="b">Second character of the frame id</param>
            /// <param name="c">Third character of the frame id</param>
            /// <param name="d">Fourth character of the frame id</param>
            /// <param name="Description">A string describing the frame id (for
            /// example, "Title")</param>
            public FrameID(char a, char b, char c, char d, string Description)
            {
                Set((byte)a, (byte)b, (byte)c, (byte)d);

                this.Description = Description;
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="a">First character of the frame id</param>
            /// <param name="b">Second character of the frame id</param>
            /// <param name="c">Third character of the frame id</param>
            /// <param name="d">Fourth character of the frame id</param>
            /// <param name="Description">A string describing the frame id (for
            /// example, "Title")</param>
            /// <param name="OfficialDescription">A string containing the official
            /// description of the frame id (for example, "Title/songname/content 
            /// description)</param>
            public FrameID(char a, char b, char c, char d, string Description, string OfficialDescription)
            {
                Set((byte)a, (byte)b, (byte)c, (byte)d);

                this.Description = Description;
                this.OfficialDescription = OfficialDescription;
            }

            byte[] m_ID = new byte[4];
            public readonly string Description;
            public readonly string OfficialDescription;

            /// <summary>
            /// Sets it up all in one shot
            /// </summary>
            /// <param name="a">First character of the frame id</param>
            /// <param name="b">Second character of the frame id</param>
            /// <param name="c">Third character of the frame id</param>
            /// <param name="d">Fourth character of the frame id</param>
            public void Set(byte a, byte b, byte c, byte d)
            {
                m_ID[0] = a;
                m_ID[1] = b;
                m_ID[2] = c;
                m_ID[3] = d;
            }

            /// <summary>
            /// Compares the frame id with another one.
            /// Description and OfficialDescription are ignored.
            /// </summary>
            /// <param name="CompareWith">The FrameID to compare with</param>
            /// <returns>true if they are the same, or false if they aren't</returns>
            public bool CompareID(FrameID CompareWith)
            {
                return ((m_ID[0] == CompareWith.m_ID[0]) && (m_ID[1] == CompareWith.m_ID[1]) &&
                    (m_ID[2] == CompareWith.m_ID[2]) && (m_ID[3] == CompareWith.m_ID[3]));
            }


            /// <summary>
            /// Gets or sets a character of the id
            /// </summary>
            /// <param name="index">The index of the character to get.  Must be 
            /// between 0 and 3.</param>
            /// <returns>The selected character</returns>
            public byte this[int index]
            {
                get { return m_ID[index]; }
                set { m_ID[index] = value; }
            }

            public uint ToUInt()
            {
                uint ret = ((uint)(m_ID[0]) << 24);
                ret += ((uint)(m_ID[1]) << 16);
                ret += ((uint)(m_ID[2]) << 8);
                ret += (uint)m_ID[3];
                return ret;
            }

            public override string ToString()
            {
                return "" + (char)m_ID[0] + (char)m_ID[1] + (char)m_ID[2] + (char)m_ID[3];
            }
        }

        internal enum FrameResult
        {
            NoMoreFrames, NullFrame, Success
        }
    }
}