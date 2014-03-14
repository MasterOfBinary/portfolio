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
        /// <summary>
        /// The ID3v1 class can read ID3v1 and ID3v1.1 tags from MP3 files.
        /// </summary>
        public class ID3v1
        {
            /// <summary>
            /// The constructor
            /// </summary>
            public ID3v1()
            { }

            /// <summary>
            /// Copy constructor
            /// </summary>
            /// <param name="Copy">The ID3v1 object to copy</param>
            public ID3v1(ID3v1 Copy)
            {
                m_Title = Copy.m_Title;
                m_Artist = Copy.m_Artist;
                m_Album = Copy.m_Album;
                m_Track = Copy.m_Track;
                m_Year = Copy.m_Year;
                m_Genre = Copy.m_Genre;
                m_Comment = Copy.m_Comment;
            }

            #region Private variables

            string m_Title;
            string m_Artist;
            string m_Album;
            int m_Track;
            int m_Year;
            int m_Genre;
            string m_Comment;

            #endregion

            #region Public properties

            public string Title
            {
                get { return m_Title; }
                set { m_Title = (value.Length > 30 ? value.Substring(0, 30) : value); }
            }

            public string Artist
            {
                get { return m_Artist; }
                set { m_Artist = (value.Length > 30 ? value.Substring(0, 30) : value); }
            }

            public string Album
            {
                get { return m_Album; }
                set { m_Album = (value.Length > 30 ? value.Substring(0, 30) : value); }
            }

            public int Year
            {
                get { return m_Year; }
                set { m_Year = (value > 9999 ? 9999 : value); }
            }

            public string Comment
            {
                get { return m_Comment; }
                set { m_Comment = (value.Length > 30 ? value.Substring(0, 30) : value); }
            }

            public int Track
            {
                get { return m_Track; }
                set { m_Track = (value > 255 ? 255 : value); }
            }

            public int Genre
            {
                get { return m_Genre; }
                set { m_Genre = value; }
            }

            #endregion

            /// <summary>
            /// Reads the ID3v1 tag, excluding the header from the current position of
            /// the bitstream.
            /// </summary>
            /// <param name="reader"></param>
            /// <returns>True if the tag is valid, false if it isn't</returns>
            internal bool Read(BinaryReader reader, List<Error> Errors)
            {
                // We'll read the tag
                byte[] Tag = new byte[125];

                bool Invalid = false;

                // Read the entire v1 tag
                if (reader.Read(Tag, 0, 125) < 125)
                {
                    Errors.Add(new Error(4324, "Unable to read 125 bytes"));
                    return false;
                }

                ClearAll();

                // Get the title
                for (int x = 0; x < 30; x++)
                {
                    if (Tag[x] == '\0')
                        break;

                    Title += (char)Tag[x];
                }

                // Get the artist
                for (int x = 30; x < 60; x++)
                {
                    if (Tag[x] == '\0')
                        break;

                    Artist += (char)Tag[x];
                }

                // Get the album
                for (int x = 60; x < 90; x++)
                {
                    if (Tag[x] == '\0')
                        break;

                    Album += (char)Tag[x];
                }

                // Get the year
                string StrYear = "";
                for (int x = 90; x < 94; x++)
                {
                    if (((char)Tag[x] < '0') || ((char)Tag[x] > '9'))
                    {
                        Errors.Add(new Error(1242, "Year contains null characters"));
                        Invalid = true;
                        break;
                    }

                    StrYear += (char)Tag[x];
                }

                if (!Invalid)
                    Year = (StrYear != "" ? int.Parse(StrYear) : 0);

                // Get the comment
                for (int x = 94; x < 124; x++)
                {
                    if (Tag[x] == '\0')
                        break;

                    Comment += (char)Tag[x];
                }

                // See if there's a track
                if ((Tag[122] == 0) && (Tag[123] != 0))
                    Track = (char)Tag[123];

                Genre = Tag[124];

                TrimAll();

                return !Invalid;
            }

            /// <summary>
            /// Write an ID3v1 tag and header to the current position in the bitstream.
            /// </summary>
            /// <param name="writer"></param>
            internal void Write(BinaryWriter writer)
            {
                byte[] Tag = new byte[125]; // The entire tag minus the header

                // Write the title
                for (int x = 0; x < 30; x++)
                {
                    if (Title.Length <= x)
                        Tag[x] = 0;
                    else
                        Tag[x] = (byte)Title[x];
                }

                // Write the artist
                for (int x = 30; x < 60; x++)
                {
                    if (Artist.Length <= x - 30)
                        Tag[x] = 0;
                    else
                        Tag[x] = (byte)Artist[x - 30];
                }

                // Write the album
                for (int x = 60; x < 90; x++)
                {
                    if (Album.Length <= x - 60)
                        Tag[x] = 0;
                    else
                        Tag[x] = (byte)Album[x - 60];
                }

                // Write the year
                string StrYear = Year.ToString();
                for (int x = 93; x >= 90; x--)
                {
                    if (StrYear.Length <= x - 90)
                        Tag[x] = (byte)'0';
                    else
                        Tag[x] = (byte)StrYear[x - 90];
                }

                // If there's a track the comment should only be 28 bytes long
                if (Track == 0)
                {
                    // There's no track, make the comment 30 bytes
                    for (int x = 94; x < 124; x++)
                    {
                        if (Comment.Length <= x - 94)
                            Tag[x] = 0;
                        else
                            Tag[x] = (byte)Album[x - 94];
                    }
                }
                else
                {
                    // There is a track, the comment should be 28 bytes
                    for (int x = 94; x < 122; x++)
                    {
                        if (Comment.Length <= x - 94)
                            Tag[x] = 0;
                        else
                            Tag[x] = (byte)Comment[x - 94];
                    }

                    // Write the track
                    Tag[122] = 0;
                    Tag[123] = (byte)Track;
                }

                // Write the genre
                Tag[124] = (byte)Genre;

                // Now write the tag
                writer.Write(new byte[] { (byte)'T', (byte)'A', (byte)'G' });
                writer.Write(Tag);
            }

            /// <summary>
            /// Sets all the fields to null.
            /// </summary>
            public void ClearAll()
            {
                m_Title = "";
                m_Artist = "";
                m_Album = "";
                m_Track = 0;
                m_Year = 0;
                m_Genre = 0;
                m_Comment = "";
            }

            /// <summary>
            /// Trims whitespace off the end of all the fields.
            /// </summary>
            void TrimAll()
            {
                m_Title = m_Title.TrimEnd();
                m_Artist = m_Artist.TrimEnd();
                m_Album = m_Album.TrimEnd();
                m_Comment = m_Comment.TrimEnd();
            }
        }
    }
}
