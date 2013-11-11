using System;
using System.Collections.Generic;
using System.Text;

namespace AudioInfo
{
    namespace ID3
    {
        /// <summary>
        /// All the frame id's defined in the ID3v2 tag standard
        /// </summary>
        public class FrameIDs
        {
            // Unique file identifier
            public static readonly FrameID UniqueFileIdentifier = new FrameID('U', 'F', 'I', 'D', "Unique File Identifier", "Unique File Identifier");
            // Text information frames (start with 'T')
            public static readonly FrameID Album = new FrameID('T', 'A', 'L', 'B', "Album", "Album/Movie/Show title");
            public static readonly FrameID BPM = new FrameID('T', 'B', 'P', 'M', "Beats per Minute", "BPM");
            public static readonly FrameID Composer = new FrameID('T', 'C', 'O', 'M', "Composer", "Composer");
            public static readonly FrameID Genre = new FrameID('T', 'C', 'O', 'N', "Genre", "Content type");
            public static readonly FrameID Copyright = new FrameID('T', 'C', 'O', 'P', "Copyright", "Copyright message");
            public static readonly FrameID EncodingTime = new FrameID('T', 'D', 'E', 'N', "Encoding Time", "Encoding time");
            public static readonly FrameID PlaylistDelay = new FrameID('T', 'D', 'L', 'Y', "Playlist Delay", "Playlist delay");
            public static readonly FrameID OriginalReleaseTime = new FrameID('T', 'D', 'O', 'R', "Original Release Time", "Original release time");
            public static readonly FrameID RecordingTime = new FrameID('T', 'D', 'R', 'L', "Recording Time", "Recording time");
            public static readonly FrameID TaggingTime = new FrameID('T', 'D', 'T', 'G', "Tagging Time", "Tagging Time");
            public static readonly FrameID Encoder = new FrameID('T', 'E', 'N', 'C', "Encoder", "Encoded by");
            public static readonly FrameID Lyricist = new FrameID('T', 'E', 'X', 'T', "Lyricist", "Lyricist/Text writer");
            public static readonly FrameID FileType = new FrameID('T', 'F', 'L', 'T', "File Type", "File type");
            public static readonly FrameID InvolvedPeople = new FrameID('T', 'I', 'P', 'L', "Involved People", "Involved people list");
            public static readonly FrameID ContentGroup = new FrameID('T', 'I', 'T', '1', "Content Group", "Content group description");
            public static readonly FrameID Title = new FrameID('T', 'I', 'T', '2', "Title", "Title/songname/content description");
            public static readonly FrameID Subtitle = new FrameID('T', 'I', 'T', '3', "Subtitle", "Subtitle/Description refinement");
            public static readonly FrameID InitialKey = new FrameID('T', 'K', 'E', 'Y', "Initial Key", "Initial key");
            public static readonly FrameID Language = new FrameID('T', 'L', 'A', 'N', "Language", "Language(s)");
            public static readonly FrameID Length = new FrameID('T', 'L', 'E', 'N', "Length", "Length");
            public static readonly FrameID MusicianCreditList = new FrameID('T', 'M', 'C', 'L', "Musician Credit List", "Musician credit list");
            public static readonly FrameID MediaType = new FrameID('T', 'M', 'E', 'D', "Media Type", "Media type");
            public static readonly FrameID Mood = new FrameID('T', 'M', 'O', 'O', "Mood", "Mood");
            public static readonly FrameID OriginalAlbum = new FrameID('T', 'O', 'A', 'L', "Original Album", "Original album/movie/show title");
            public static readonly FrameID OriginalFilename = new FrameID('T', 'O', 'F', 'N', "Original Filename", "Original filename");
            public static readonly FrameID OriginalLyricist = new FrameID('T', 'O', 'L', 'Y', "Original Lyricist", "Original lyricist(s)/text writer(s)");
            public static readonly FrameID OriginalArtist = new FrameID('T', 'O', 'P', 'E', "Original Artist", "Original artist(s)/performer(s)");
            public static readonly FrameID FileOwner = new FrameID('T', 'O', 'W', 'N', "File Owner", "File owner/licensee");
            public static readonly FrameID Artist = new FrameID('T', 'P', 'E', '1', "Artist", "Lead performer(s)/Soloist(s)");
            public static readonly FrameID Accompaniment = new FrameID('T', 'P', 'E', '2', "Accompaniment", "Band/orchestra/accompaniment");
            public static readonly FrameID Conductor = new FrameID('T', 'P', 'E', '3', "Conductor", "Conductor/performer refinement");
            public static readonly FrameID ModifiedBy = new FrameID('T', 'P', 'E', '4', "Modified By", "Interpreted, remixed, or otherwise modified by");
            public static readonly FrameID PartOfSet = new FrameID('T', 'P', 'O', 'S', "Part of Set", "Part of a set");
            public static readonly FrameID ProducedNotice = new FrameID('T', 'P', 'R', 'O', "Produced Notice", "Produced notice");
            public static readonly FrameID Publisher = new FrameID('T', 'P', 'U', 'B', "Publisher", "Publisher");
            public static readonly FrameID Track = new FrameID('T', 'R', 'C', 'K', "Track", "Track number/Position in set");
            public static readonly FrameID InternetRadioStation = new FrameID('T', 'R', 'S', 'N', "Internet Radio Station", "Internet radio station name");
            public static readonly FrameID InternetRadioStationOwner = new FrameID('T', 'R', 'S', 'O', "Internet Radio Station Owner", "Internet radio station owner");
            public static readonly FrameID AlbumSortOrder = new FrameID('T', 'S', 'O', 'A', "Album Sort Order", "Album sort order");
            public static readonly FrameID PerformerSortOrder = new FrameID('T', 'S', 'O', 'P', "Performer Sort Order", "Performer sort order");
            public static readonly FrameID TitleSortOrder = new FrameID('T', 'S', 'O', 'T', "Title Sort Order", "Title sort order");
            public static readonly FrameID ISRC = new FrameID('T', 'S', 'R', 'C', "ISRC", "ISRC");
            public static readonly FrameID EncoderSettings = new FrameID('T', 'S', 'S', 'E', "Encoder Settings", "Software/Hardware and settings used for encoding");
            public static readonly FrameID SetSubtitle = new FrameID('T', 'S', 'S', 'T', "Set Subtitle", "Set subtitle");
            public static readonly FrameID UserDefinedTextInformationFrame = new FrameID('T', 'X', 'X', 'X', "User Defined Text Information Frame", "User defined text information frame");
            // URL link frames (start with 'W')
            public static readonly FrameID CommercialInformation = new FrameID('W', 'C', 'O', 'M', "Commercial Information", "Commercial information");
            public static readonly FrameID LegalInformation = new FrameID('W', 'C', 'O', 'P', "Legal Information", "Copyright/Legal information");
            public static readonly FrameID OfficialAudioFileWebpage = new FrameID('W', 'O', 'A', 'F', "Official Audio File Webpage", "Official audio file webpage");
            public static readonly FrameID OfficialArtistWebpage = new FrameID('W', 'O', 'A', 'R', "Official Artist Webpage", "Official artist/performer webpage");
            public static readonly FrameID OfficialAudioSourceWebpage = new FrameID('W', 'O', 'A', 'S', "Official Audio Source Webpage", "Official audio source webpage");
            public static readonly FrameID OfficialInternetRadioStationWebpage = new FrameID('W', 'O', 'R', 'S', "Official Internet Radio Station Webpage", "Official Internet radio station homepage");
            public static readonly FrameID Payment = new FrameID('W', 'P', 'A', 'Y', "Payment", "Payment");
            public static readonly FrameID OfficialPublishersWebpage = new FrameID('W', 'P', 'U', 'B', "Official Publisher's Webpage", "Publishers official webpage");
            public static readonly FrameID UserDefinedUrlLinkFrame = new FrameID('W', 'X', 'X', 'X', "User Defined URL Link Frame", "User defined URL link frame");
            // A's
            public static readonly FrameID AudioEncryption = new FrameID('A', 'E', 'N', 'C', "Audio Encryption", "Audio encryption");
            public static readonly FrameID AttachedPicture = new FrameID('A', 'P', 'I', 'C', "Attached Picture", "Attached picture");
            public static readonly FrameID AudioSeekPointIndex = new FrameID('A', 'S', 'P', 'I', "Audio Seek Point Index", "Audio seek point index");
            // C's
            public static readonly FrameID Comments = new FrameID('C', 'O', 'M', 'M', "Comments", "Comments");
            public static readonly FrameID Commercial = new FrameID('C', 'O', 'M', 'R', "Commercial", "COMR Commercial frame");
            // E's
            public static readonly FrameID EncryptionMethod = new FrameID('E', 'N', 'C', 'R', "Encryption Method", "Encryption method registration");
            public static readonly FrameID Equalization = new FrameID('E', 'Q', 'U', '2', "Equalization", "Equalisation (2)");
            public static readonly FrameID EventTimingCodes = new FrameID('E', 'T', 'C', 'O', "Event Timing Codes", "Event timing codes");
            // G's
            public static readonly FrameID GeneralEncapsulatedObject = new FrameID('G', 'E', 'O', 'B', "General Encapsulated Object", "General encapsulated object");
            public static readonly FrameID GroupIdentification = new FrameID('G', 'R', 'I', 'D', "Group Identification", "Group identification registration");
            // L's
            public static readonly FrameID LinkedInformation = new FrameID('L', 'I', 'N', 'K', "Linked Information", "Linked information");
            // M's
            public static readonly FrameID MusicCdIdentifier = new FrameID('M', 'C', 'D', 'I', "Music CD Identifier", "Music CD identifier");
            public static readonly FrameID MpegLocationLookupTable=new FrameID('M','L','L','T',"MPEG Location Lookup Table","MPEG location lookup table");
            // O's
            public static readonly FrameID Ownership = new FrameID('O', 'W', 'N', 'E', "Ownership", "Ownership frame");
            // P's
            public static readonly FrameID PrivateFrame = new FrameID('P', 'R', 'I', 'V', "Private Frame", "Private frame");
            public static readonly FrameID PlayCounter = new FrameID('P', 'C', 'N', 'T', "Play Counter", "Play counter");
            public static readonly FrameID Popularimeter = new FrameID('P', 'O', 'P', 'M', "Popularimeter", "Popularimeter");
            public static readonly FrameID PositionSynchronization = new FrameID('P', 'O', 'S', 'S', "Position Synchronization", "Position synchronisation frame");
            // R's
            public static readonly FrameID RecommenderBufferSize = new FrameID('R', 'B', 'U', 'F', "Recommended Buffer Size", "Recommended buffer size");
            public static readonly FrameID RelativeVolumeAdjustment = new FrameID('R', 'V', 'A', '2', "Relative Volume Adjustment", "Relative volume adjustment (2)");
            public static readonly FrameID Reverb = new FrameID('R', 'V', 'R', 'B', "Reverb", "Reverb");
            // S's
            public static readonly FrameID Seek = new FrameID('S', 'E', 'E', 'K', "Seek", "Seek frame");
            public static readonly FrameID Signature = new FrameID('S', 'I', 'G', 'N', "Signature", "Signature frame");
            public static readonly FrameID SynchronizedLyrics = new FrameID('S', 'Y', 'L', 'T', "Synchronized Lyrics", "Synchronised lyric/text");
            public static readonly FrameID SynchronizedTempoCodes = new FrameID('S', 'Y', 'T', 'C', "Synchronized Tempo Codes", "Synchronised tempo codes");
            // U's
            public static readonly FrameID TermsOfUse = new FrameID('U', 'S', 'E', 'R', "Terms of Use", "Terms of use");
            public static readonly FrameID UnsynchronizedLyrics = new FrameID('U', 'S', 'L', 'T', "Unsynchronized Lyrics", "Unsynchronised lyric/text transcription");

            // Non-standard frame id's that seem to be used a lot
            public static readonly FrameID Year = new FrameID('T', 'Y', 'E', 'R', "Year", "(Non-standard)");

            public static readonly FrameID[] All ={ UniqueFileIdentifier, Album, BPM, Composer,
                Genre, Copyright, EncodingTime, PlaylistDelay, OriginalReleaseTime,
                RecordingTime, TaggingTime, Encoder, Lyricist, FileType, InvolvedPeople,
                ContentGroup, Title, Subtitle, InitialKey, Language, Length, 
                MusicianCreditList, MediaType, Mood, OriginalAlbum, OriginalFilename,
                OriginalLyricist, OriginalArtist, FileOwner, Artist, Accompaniment,
                Conductor, ModifiedBy, PartOfSet, ProducedNotice, Publisher, Track,
                InternetRadioStation, InternetRadioStationOwner, AlbumSortOrder,
                PerformerSortOrder, TitleSortOrder, ISRC, EncoderSettings, SetSubtitle,
                UserDefinedTextInformationFrame,
                CommercialInformation, LegalInformation, OfficialAudioFileWebpage,
                OfficialArtistWebpage, OfficialAudioSourceWebpage,
                OfficialInternetRadioStationWebpage, Payment, OfficialPublishersWebpage,
                UserDefinedUrlLinkFrame,
                AudioEncryption, AttachedPicture, AudioSeekPointIndex, Comments,
                Commercial, EncryptionMethod, Equalization, EventTimingCodes,
                GeneralEncapsulatedObject, GroupIdentification, LinkedInformation,
                MusicCdIdentifier, MpegLocationLookupTable, Ownership, PrivateFrame,
                PlayCounter, Popularimeter, PositionSynchronization, RecommenderBufferSize,
                RelativeVolumeAdjustment, Reverb, Seek, Signature, SynchronizedLyrics,
                SynchronizedTempoCodes, TermsOfUse, UnsynchronizedLyrics,
                Year };
        }
    }
}