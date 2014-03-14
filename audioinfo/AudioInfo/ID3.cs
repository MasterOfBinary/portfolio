//
// Copyright (c) Vaughn Friesen
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AudioInfo
{
    namespace ID3
    {
        public class ID3
        {
            /// <summary>
            /// The constructor
            /// </summary>
            /// <param name="FileName">The name of the file to read tags from</param>
            public ID3(string FileName)
            {
                m_FileName = FileName;

                m_V1Tag = new ID3v1();
                m_V2Tag = new ID3v2();
            }

            /// <summary>
            /// Copy constructor
            /// </summary>
            /// <param name="Copy">The ID3 object to copy from</param>
            public ID3(ID3 Copy)
            {
                m_FileName = Copy.m_FileName;
                m_V1Tag = new ID3v1(Copy.m_V1Tag);
                m_V2Tag = new ID3v2(Copy.m_V2Tag);
            }

            public readonly List<Error> Errors = new List<Error>();

            private readonly string m_FileName;

            private ID3v1 m_V1Tag;
            private ID3v2 m_V2Tag;

            public ID3v1 V1Tag
            {
                get { return m_V1Tag; }
            }
            public ID3v2 V2Tag
            {
                get { return m_V2Tag; }
            }

            /// <summary>
            /// Loads the ID3v1 tags
            /// </summary>
            /// <returns>One of the following values: Id3Result.Success,
            /// Id3Result.CannotOpenFile, Id3Result.NoTag, Id3Result.InvalidTag.</returns>
            public Id3Result ReadV1Tag()
            {
                BinaryReader reader;

                m_V1Tag = new ID3v1();

                // Open the file
                try { reader = new BinaryReader(File.Open(m_FileName, FileMode.Open)); }
                catch
                {
                    Errors.Add(new Error(471, "Failed to open file \"" + m_FileName + "\"."));
                    return Id3Result.CannotOpenFile;
                }

                // Seek to where the id3v1 tag should be
                try { reader.BaseStream.Seek(-128, SeekOrigin.End); }
                catch
                {
                    reader.Close();
                    return Id3Result.NoTag;
                }

                // Make sure there's an id3v1 tag
                byte[] Header = new byte[3];
                reader.Read(Header, 0, 3);
                if ((Header[0] != 'T') || (Header[1] != 'A') || (Header[2] != 'G'))
                {
                    reader.Close();
                    return Id3Result.NoTag;
                }

                // Read the tag
                if (!m_V1Tag.Read(reader, Errors))
                {
                    reader.Close();
                    return Id3Result.InvalidTag;
                }

                reader.Close();
                return Id3Result.Success;
            }

            /// <summary>
            /// Loads the ID3v2 tags
            /// </summary>
            /// <returns>One of the following values: Id3Result.Success,
            /// Id3Result.CannotOpenFile, Id3Result.NoTag, Id3Result.InvalidTag.</returns>
            public Id3Result ReadV2Tag()
            {
                BinaryReader reader;

                m_V2Tag = new ID3v2();

                // Open the file
                try { reader = new BinaryReader(File.Open(m_FileName, FileMode.Open)); }
                catch
                {
                    Errors.Add(new Error(472, "Failed to open file \"" + m_FileName + "\"."));
                    return Id3Result.CannotOpenFile;
                }

                // Make sure there is an ID3v2 tag
                byte[] HeaderBytes = new byte[3];
                reader.Read(HeaderBytes, 0, 3);

                if ((HeaderBytes[0] != 'I') || (HeaderBytes[1] != 'D') || (HeaderBytes[2] != '3'))
                {
                    reader.Close();
                    return Id3Result.NoTag;
                }

                // Go back to the beginning
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Read the tag
                if (!m_V2Tag.Read(reader, Errors))
                {
                    reader.Close();
                    return Id3Result.InvalidTag;
                }

                reader.Close();
                return Id3Result.Success;
            }

            /// <summary>
            /// Writes the ID3 tags
            /// </summary>
            /// <param name="WriteV1Tag">Whether a version 1 tag should be written</param>
            /// <param name="WriteV2Tag">Whether a version 2 tag should be written</param>
            /// <returns>One of the following values: Id3Result.Success,
            /// Id3Result.CannotOpenFile, Id3Result.CannotCreateTempFile</returns>
            public Id3Result WriteTags(bool WriteV1Tag, bool WriteV2Tag)
            {
                bool HasTag1 = false;
                bool HasTag2 = false;

                // See if there's already an ID3v1 tag
                switch ((new ID3(m_FileName)).ReadV1Tag())
                {
                    case Id3Result.Success:
                    case Id3Result.InvalidTag:
                        HasTag1 = true;
                        break;
                    case Id3Result.NoTag:
                        HasTag1 = false;
                        break;
                    case Id3Result.CannotOpenFile:
                        return Id3Result.CannotOpenFile;
                }

                // See if there's an ID3v2 tag
                switch ((new ID3(m_FileName)).ReadV2Tag())
                {
                    case Id3Result.Success:
                    case Id3Result.InvalidTag:
                        HasTag2 = true;
                        break;
                    case Id3Result.NoTag:
                        HasTag2 = false;
                        break;
                    case Id3Result.CannotOpenFile:
                        return Id3Result.CannotOpenFile;
                }

                // We'll make a temporary copy of the file so we don't lose the original
                // if something messes up
                string TempFileName = "";
                BinaryWriter writer;

                // Try to create a temp file
                try
                {
                    TempFileName = Path.GetTempFileName();
                    writer = new BinaryWriter(File.Open(TempFileName, FileMode.Create));
                }
                catch
                {
                    File.Delete(TempFileName);
                    return Id3Result.CannotCreateTempFile;
                }

                // Open the original file for reading
                BinaryReader reader;

                try
                {
                    reader = new BinaryReader(File.Open(m_FileName, FileMode.Open));
                }
                catch
                {
                    return Id3Result.CannotOpenFile;
                }

                // Copy the file to the temp file
                // If it has a v2 tag already start after the tag

                int StartPos = 0;

                if (HasTag2)
                {
                    // Get the size of the v2 tag
                    byte[] Header = new byte[10];

                    reader.Read(Header, 0, 10);

                    int V2Length;

                    // Get the tag length
                    V2Length = (Header[6] << 21);
                    V2Length += (Header[7] << 14);
                    V2Length += (Header[8] << 7);
                    V2Length += Header[9];

                    StartPos = V2Length + 10;
                }

                // Write a v2 tag to the temp file
                if (WriteV2Tag)
                    V2Tag.Write(writer);

                int BufferSize = 1024 * 1024; // 1MB buffer

                // Copy the actual file data from the file to the temp file
                if (HasTag1)
                {
                    // We have to read up to (but not including) the v1 tag
                    long TagPos = reader.BaseStream.Seek(-128, SeekOrigin.End);

                    // Go to the beginning of the ID3v2 tag (if there is one)
                    reader.BaseStream.Seek(StartPos, SeekOrigin.Begin);

                    long FileLength = TagPos - StartPos; // Length of file minus tags

                    if (FileLength < BufferSize)
                    {
                        // Less than BufferSize from start to beginning of tag, copy it 
                        // all in one shot
                        byte[] buffer = new byte[FileLength];
                        reader.Read(buffer, 0, (int)FileLength);
                        writer.Write(buffer);
                    }
                    else
                    {
                        // Make a buffer
                        byte[] buffer = new byte[BufferSize];

                        // See how many buffers it will take to get to the tag
                        int NumBuffers = (int)(FileLength / BufferSize);

                        for (int x = 0; x < NumBuffers; x++)
                        {
                            reader.Read(buffer, 0, BufferSize);
                            writer.Write(buffer);
                        }

                        int LastBuffer = (int)(FileLength % BufferSize);
                        reader.Read(buffer, 0, LastBuffer);
                        writer.Write(buffer, 0, LastBuffer);
                    }
                }
                else
                {
                    // No v1 tag, just copy the whole file from the v2 tag
                    // Make a buffer
                    byte[] buffer = new byte[BufferSize];

                    // Go to the beginning of the v2 tag
                    reader.BaseStream.Seek(StartPos, SeekOrigin.Begin);

                    int Result = reader.Read(buffer, 0, BufferSize);

                    while (Result > 0)
                    {
                        writer.Write(buffer, 0, Result);
                        Result = reader.Read(buffer, 0, BufferSize);
                    }
                }

                // Write an ID3v1 tag
                if (WriteV1Tag)
                    V1Tag.Write(writer);

                // Close our files
                writer.Close();
                reader.Close();

                // Copy the temp file to the other file
                File.Copy(TempFileName, m_FileName, true);

                // Clean up our mess
                File.Delete(TempFileName);

                // Successful
                return Id3Result.Success;
            }
        }

        public enum Id3Result
        {
            Success, CannotOpenFile, NoTag, InvalidTag, CannotCreateTempFile
        }
    }
}