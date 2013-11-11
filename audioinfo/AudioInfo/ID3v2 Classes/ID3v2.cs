using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AudioInfo
{
    namespace ID3
    {
        /// <summary>
        /// The ID3v2 class can read ID3v2 tags from MP3 files.
        /// </summary>
        public class ID3v2
        {
            #region Flags

            internal bool m_Unsynchronization;
            internal bool m_Experimental;
            internal bool m_AddFooter;
            internal bool m_AddPadding;
            internal PaddingSize m_PaddingSizeType;
            internal int m_PaddingSizeValue;

            public bool Unsynchronization
            {
                get { return m_Unsynchronization; }
                set { m_Unsynchronization = value; }
            }

            public bool Experimental
            {
                get { return m_Experimental; }
                set { m_Experimental = value; }
            }

            public bool AddFooter
            {
                get { return m_AddFooter; }
                set
                {
                    m_AddFooter = value;
                    if (value) m_AddPadding = false;
                }
            }

            public bool AddPadding
            {
                get { return m_AddPadding; }
                set
                {
                    m_AddPadding = value;
                    if (value)
                        m_AddFooter = false;
                }
            }

            public PaddingSize PaddingSizeType
            {
                get { return m_PaddingSizeType; }
                set { m_PaddingSizeType = value; }
            }

            public int PaddingSizeValue
            {
                get { return m_PaddingSizeValue; }
                set { m_PaddingSizeValue = value; }
            }

            #endregion

            /// <summary>
            /// The constructor
            /// </summary>
            public ID3v2()
            { m_Header = new Header(); }

            /// <summary>
            /// Copy constructor
            /// </summary>
            /// <param name="Copy">The ID3v2 object to copy</param>
            public ID3v2(ID3v2 Copy)
            {
                // Copy header
                m_Header = Copy.m_Header;

                // Copy flags
                m_Unsynchronization = Copy.m_Unsynchronization;
                m_Experimental = Copy.m_Experimental;
                m_AddFooter = Copy.m_AddFooter;
                m_AddPadding = Copy.m_AddPadding;
                m_PaddingSizeType = Copy.m_PaddingSizeType;
                m_PaddingSizeValue = Copy.m_PaddingSizeValue;

                // Copy frames
                foreach (Frame f in Copy.Frames)
                    Frames.Add(f);
            }

            public List<Frame> Frames = new List<Frame>();

            /// <summary>
            /// Reads the ID3v2 tag from the current position of the
            /// bitstream.  If there is not a tag at the current position
            /// it will fail.
            /// </summary>
            /// <param name="reader"></param>
            /// <returns>True if it succeeds, false if it doesn't</returns>
            internal bool Read(BinaryReader reader, List<Error> Errors)
            {
                // Make sure there is an ID3v2 tag
                byte[] HeaderBytes = new byte[10];
                reader.Read(HeaderBytes, 0, 10);

                bool Invalid = false;

                // Now we'll read the header
                m_Header = new Header();

                if (!m_Header.GetFromBytes(HeaderBytes))
                    return false;

                long beginpos = reader.BaseStream.Position;

                // Read in all the frames
                while (reader.BaseStream.Position - beginpos < m_Header.Size)
                {
                    Frame frame = new Frame();

                    FrameResult result = frame.Read(reader);

                    if (result == FrameResult.NoMoreFrames)
                        break;
                    else if (result == FrameResult.NullFrame)
                    {
                        Errors.Add(new Error(3534, frame.ID.ToString() + " frame is 0 bytes"));
                        Invalid = true;
                    }
                    else // Successful
                    {
                        bool Add = true;
                        // Make sure there aren't any previous frames like it
                        foreach (Frame f in Frames)
                        {
                            if (frame.ID.CompareID(f.ID))
                            {
                                // There's already a frame with the same id
                                // We'll check if this is allowed
                                if ((frame.ID.ToString() == "WXXX") ||
                                    (frame.ID.ToString() == "TXXX"))
                                {
                                    // Check the frame descriptions to make sure
                                    // they're different
                                    if (frame.UserDescription == f.UserDescription)
                                    {
                                        Errors.Add(new Error(3547, frame.ID.ToString() + " frames have same user description"));
                                        Invalid = true;
                                        Add = false;
                                        break;
                                    }
                                }
                                else if ((frame.ID.ToString() == "WCOM") ||
                                    (frame.ID.ToString() == "WOAR"))
                                {
                                    // The content must be different
                                    if (frame.Data == f.Data)
                                    {
                                        Errors.Add(new Error(3548, frame.ID.ToString() + " frames have same data"));
                                        Invalid = true;
                                        Add = false;
                                        break;
                                    }
                                }
                                else if ((frame.ID[0] == (byte)'T') ||
                                    (frame.ID[0] == (byte)'W'))
                                {
                                    Errors.Add(new Error(3549, "Duplicate " + frame.ID.ToString() + " frames"));
                                    Invalid = true;
                                    Add = false;
                                    break;
                                }
                                else if ((frame.ID.ToString() == "MCDI") ||
                                (frame.ID.ToString() == "ETCO") ||
                                (frame.ID.ToString() == "MLLT") ||
                                (frame.ID.ToString() == "SYTC") ||
                                (frame.ID.ToString() == "RVRB") ||
                                (frame.ID.ToString() == "POSS") ||
                                (frame.ID.ToString() == "OWNE") ||
                                (frame.ID.ToString() == "SEEK") ||
                                (frame.ID.ToString() == "ASPI"))
                                {
                                    Errors.Add(new Error(3550, "Multiple " + frame.ID.ToString() + " frames"));
                                    Invalid = true;
                                    Add = false;
                                    break;
                                }
                                // We'll just leave the rest since we can't handle them
                            }
                        }

                        if (Add)
                            Frames.Add(frame);
                    }
                }

                return !Invalid;
            }

            /// <summary>
            /// Writes an id3v2 tag and header to the current position in the bitstream.
            /// </summary>
            /// <param name="writer"></param>
            internal void Write(BinaryWriter writer)
            {
                // TODO Add support for extended header

                // Calculate the full tag size starting with the header
                uint TagSize = 10;

                if (AddFooter)
                    TagSize += 10; // Footer is 10 bytes

                foreach (Frame frame in Frames)
                {
                    TagSize += (uint)frame.Size;
                }

                // Get adjusted tag size
                uint AdjustedTagSize = TagSize - 10;
                AdjustedTagSize -= (uint)(AddFooter ? 10 : 0);

                if (AdjustedTagSize <= 0) // Tags MUST be at least 1 byte long
                    return;

                // Prepare the header
                m_Header.Size = AdjustedTagSize;

                // Now we'll start writing.  Write the header
                m_Header.Write(writer);

                // Write the tags
                foreach (Frame frame in Frames)
                {
                    frame.Write(writer);
                }


            }

            Header m_Header;
        }

        public enum PaddingSize
        {
            Fixed, RoundFileSize, PercentOfTag
        }
    }
}
