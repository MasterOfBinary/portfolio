// MMLib.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include "MMLib.h"

// Defines
#define WAVETABLE_FOLDER L"..\\Century Sound Studio\\Wavetable\\"

#define CHUNK_WAVE mmioFOURCC('W', 'A', 'V', 'E')
#define CHUNK_FMT mmioFOURCC('f', 'm', 't', ' ')
#define CHUNK_DATA mmioFOURCC('d', 'a', 't', 'a')

// Macros
#define IN_WAVETABLE_FOLDER(x) WAVETABLE_FOLDER x

void MixMemory(short *Dest, short *Source, int Count, float Gain = 1.0f, float GainLeft = 1.0f, float GainRight = 1.0f, bool ToStereo = false);
void FadeIn(short *Dest, int Count, int Type = FADE_LINEAR);
void FadeOut(short *Dest, int Count, int Type = FADE_LINEAR);
bool InsertInstrument(short *Dest, short *Source, int Count, float Gain = 1.0f, float GainLeft = 1.0f, float GainRight = 1.0f, bool ToStereo = false, int FadeOutType = FADE_NONE, int FadeOutCount = 0);
TCHAR *GetSoundFileName(TCHAR *InstrumentName, TCHAR *NoteName, bool WaveExtension = false);
HMMIO OpenSound(TCHAR *FileName, int *DataSize);


BOOL APIENTRY DllMain(HMODULE hModule,
					  DWORD  ul_reason_for_call,
					  LPVOID lpReserved)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

Event::Event()
{
	// Default to middle C
	NoteName = L"C0";

	Position = 0; // Right at the beginning
	Speed = 1; // Whole note
}

Event::Event(TCHAR *NoteName, float Position, float Speed)
{
	this->NoteName = NoteName;
	this->Position = Position;
	this->Speed = Speed;
}

Event::Event(const Event &Copy)
{
	NoteName = Copy.NoteName;
	Position = Copy.Position;
	Speed = Copy.Speed;
}

MusicTrack::MusicTrack()
{
	// Todo: Default to piano when piano is made
	InstrumentName = L"Guitar";

	Events = 0;
	NumEvents = 0;
}

MusicTrack::MusicTrack(TCHAR *InstrumentName)
{
	this->InstrumentName = InstrumentName;
}

Composition::Composition()
{
	BeatsPerMeasure = 4;
	NoteValue = 4;

	BeatsPerMinute = 60;

	Gain = 1.0;
	GainLeft = 1.0;
	GainRight = 1.0;

	FadeTime = 0;
	FadeType = FADE_LINEAR;
	FadeInBeginning = false;
	FadeOutEnd = false;

	Tracks = 0;
	NumTracks = 0;
}

void MixMemory(short *Dest, short *Source, int Count, float Gain, float GainLeft, float GainRight, bool ToStereo)
{
	// Mix by using formula A + B - A * B
	if (ToStereo)
	{
		for (int x = 0; x < Count; x++)
		{
			float dest = (float)Dest[x];
			float source = (float)Source[x / 2] * (x % 2 == 0 ? GainLeft : GainRight) * Gain;

			Dest[x] = (short)(dest + source - dest * source / 32768);
		}
	}
	else
	{
		float TotalGain = (GainLeft + GainRight) / 2 * Gain;

		for (int x = 0; x < Count; x++)
		{
			float dest = (float)Dest[x];
			float source = (float)Source[x] * TotalGain;

			Dest[x] = (short)(dest + source - dest * source / 32768);
		}
	}
}

void FadeIn(short *Dest, int Count, int Type)
{
	if (Type == FADE_LINEAR)
	{
		float Gain = 0.0f;
		float GainPerSample = 1.0f / (float)Count;

		for (int x = 0; x < Count; x++)
		{
			Gain += GainPerSample;

			Dest[x] = (short)(Dest[x] * Gain);
		}
	}
	else if (Type == FADE_LOGARITHMIC)
	{
		float e = 2.718f;
		float LogPerSample = (e - 1.0f) / (float)Count;
		float Log = 1.0f;

		for (int x = 0; x < Count; x++)
		{
			Log += LogPerSample;

			Dest[x] = (short)(Dest[x] * log(Log));
		}
	}
	else if (Type == FADE_EXPONENTIAL)
	{
		float ExpPerSample = 10.0f / (float)Count;
		float Exp = -10.0f;

		for (int x = 0; x < Count; x++)
		{
			Exp += ExpPerSample;

			float Gain = exp(Exp);

			Dest[x] = (short)(Dest[x] * Gain);
		}
	}
}

void FadeOut(short *Dest, int Count, int Type)
{
	if (Type == FADE_LINEAR)
	{
		float Gain = 1.0f;
		float GainPerSample = 1.0f / (float)Count;

		for (int x = 0; x < Count; x++)
		{
			Gain -= GainPerSample;

			Dest[x] = (short)(Dest[x] * Gain);
		}
	}
	else if (Type == FADE_LOGARITHMIC)
	{
		float e = 2.718f;
		float LogPerSample = (e - 1.0f) / (float)Count;
		float Log = e;

		for (int x = 0; x < Count; x++)
		{
			Log -= LogPerSample;

			Dest[x] = (short)(Dest[x] * log(Log));
		}
	}
	else if (Type == FADE_EXPONENTIAL)
	{
		float Exp = 0.0f;
		float ExpPerSample = 10.0f / (float)Count;

		for (int x = 0; x < Count; x++)
		{
			Exp -= ExpPerSample;

			float Gain = exp(Exp);

			Dest[x] = (short)(Dest[x] * Gain);
		}
	}
}

bool InsertInstrument(short *Dest, short *Source, int Count, float Gain, float GainLeft, float GainRight, bool ToStereo, int FadeOutType, int FadeOutCount)
{
	// Copy the instrument data
	int Size = Count * 2;
	HANDLE hDataNew = HeapCreate(0, Size, 0);
	if (!hDataNew)
		return false;

	short *lpDataNew;
	if ((lpDataNew = (short *)HeapAlloc(hDataNew, HEAP_ZERO_MEMORY, Size)) == NULL)
	{
		HeapDestroy(hDataNew);
		return false;
	}

	CopyMemory((void *)lpDataNew, (void *)Source, Size);

	// Fade out the end of the instrument
	FadeOut(lpDataNew + Count - FadeOutCount, FadeOutCount, FadeOutType);

	// Mix the memory
	MixMemory(Dest, lpDataNew, (ToStereo ? Count * 2 : Count), Gain, GainLeft, GainRight, ToStereo);

	// Clean up
	HeapFree(hDataNew, 0, lpDataNew); 
	HeapDestroy(hDataNew);

	return true;
}

TCHAR *GetSoundFileName(TCHAR *InstrumentName, TCHAR *NoteName, bool WaveExtension)
{
	TCHAR Note = NoteName[0];
	bool Sharp = (NoteName[1] == '#');
	bool Flat = (NoteName[1] == 'b');

	basic_ostringstream<TCHAR> FileName;
	FileName << WAVETABLE_FOLDER << InstrumentName << "\\";

	int NoteNumber;

	switch (Note)
	{
	case 'A':
		NoteNumber = -3;
		break;
	case 'B':
		NoteNumber = -1;
		break;
	case 'C':
		NoteNumber = 0;
		break;
	case 'D':
		NoteNumber = 2;
		break;
	case 'E':
		NoteNumber = 4;
		break;
	case 'F':
		NoteNumber = 5;
		break;
	case 'G':
		NoteNumber = 7;
		break;
	}

	if (Sharp)
		NoteNumber++;
	else if (Flat)
		NoteNumber--;

	int tmp;
	basic_string<TCHAR> nn(NoteName);
	basic_istringstream<TCHAR> in(nn.substr((Sharp || Flat ? 2 : 1)));
	in >> tmp;

	FileName << (NoteNumber + 12 * tmp);

	if (WaveExtension)
		FileName << ".wav";

	basic_string<TCHAR> st = FileName.str();
	TCHAR *tc = (TCHAR *)st.c_str();
	TCHAR *ret = new TCHAR[st.length() + 1];

	wcscpy_s(ret, st.length() + 1, tc);

	return ret;
}

HMMIO OpenSound(TCHAR *FileName, int *DataSize)
{
	int FileSize;

	// Get the file length
	HANDLE hFile = CreateFile(FileName, 0,
		FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING,
		0, NULL);

	if (hFile == INVALID_HANDLE_VALUE)
		return NULL;

	FileSize = GetFileSize(hFile, NULL);

	CloseHandle(hFile);

	HMMIO hmmio = mmioOpen(FileName, NULL, MMIO_READ | MMIO_ALLOCBUF);

	if (!hmmio)
		return NULL;

	MMCKINFO mmckinfoParent; // parent chunk information
	MMCKINFO mmckinfoSubchunk; // subchunk information structure
	DWORD dwFmtSize; // size of "FMT" chunk
	PCMWAVEFORMAT * pFormat; // address of "FMT" chunk

	// Locate a "RIFF" chunk with a "WAVE" form type to make
	// sure the file is a waveform-audio file.
	mmckinfoParent.fccType = CHUNK_WAVE;

	if (mmioDescend(hmmio, (LPMMCKINFO) & mmckinfoParent, NULL,
		MMIO_FINDRIFF))
	{
		// Not a wave file, just treat it as a raw file
		mmioSeek(hmmio, 0, SEEK_SET);

		*DataSize = FileSize;

		return hmmio;
	}

	// Find the "FMT" chunk (form type "FMT"); it must be
	// a subchunk of the "RIFF" chunk.
	mmckinfoSubchunk.ckid = CHUNK_FMT;

	if (mmioDescend(hmmio, & mmckinfoSubchunk, & mmckinfoParent,
		MMIO_FINDCHUNK))
	{
		mmioClose(hmmio, 0);
		return NULL;
	}

	// Get the size of the "FMT" chunk. Allocate
	// and lock memory for it.
	dwFmtSize = mmckinfoSubchunk.cksize;
	pFormat = new PCMWAVEFORMAT;

	// Read the "FMT" chunk.
	if (mmioRead(hmmio, (HPSTR)pFormat, dwFmtSize) != dwFmtSize)
	{
		delete pFormat;
		mmioClose(hmmio, 0);
		return NULL;
	}

	// Ascend out of the "FMT" subchunk.
	mmioAscend(hmmio, & mmckinfoSubchunk, 0);

	// Find the data subchunk. The current file position should be at
	// the beginning of the data chunk; however, you should not make
	// this assumption. Use mmioDescend to locate the data chunk.
	mmckinfoSubchunk.ckid = CHUNK_DATA;
	if (mmioDescend(hmmio, & mmckinfoSubchunk, & mmckinfoParent,
		MMIO_FINDCHUNK))
	{
		delete pFormat;
		mmioClose(hmmio, 0);
		return NULL;
	}

	if (DataSize != NULL)
		*DataSize = mmckinfoSubchunk.cksize;

	// Make sure the audio is 44.1KHz 16-bit mono PCM (the only type we can
	// work with)
	if ((pFormat->wf.nChannels != 1) || (pFormat->wf.nSamplesPerSec != 44100) ||
		(pFormat->wBitsPerSample != 16) || (pFormat->wf.wFormatTag != WAVE_FORMAT_PCM))
	{
		delete pFormat;
		mmioClose(hmmio, 0);
		return NULL;
	}

	return hmmio;
}

MMLIB_API bool BuildComposition(Composition *Composition, TCHAR *OutputFileName)
{
	// Note speed:
	// 1 is a whole note, 2 a half note, 4 a quarter note, etc.
	// Decimals are allowed, for example, 1.33 is a dotted half note (3 beats).
	// Todo: does this work in times other than 4/4? - 3/4? 2/4? others?

	// To calculate # of beats: 4 / Speed = Beats.
	//   4 / 2 = 2 beats (half note).
	//   4 / 1.33 = 3 beats (dotted half note).
	//   4 / 8 = 0.5 beats (eighth note).
	// Therefore, to calculate speed: 4 / Beats = Speed.
	//   4 / 1.5 beats = 2.67 (dotted quarter note).
	//   4 / 0.75 beats = 5.33 (dotted eighth note).
	//   4 / 1 beats = 4 (quarter note).

	// Note position:
	// Position is the number of beats from the beginning of the song.
	// Decimals are allowed, for example, 1.5 is 3 half notes from the beginning.
	const float BeatsPerSecond = Composition->BeatsPerMinute / 60;
	const float Speed = BeatsPerSecond / 4 * Composition->BeatsPerMeasure / Composition->NoteValue;

	// Sound format
	const int Channels = 2;
	const int SamplesPerSecond = 44100;
	const int BytesPerSample = 2; // 16-bit sound

	// Length of the output file
	float FileSeconds = 0;

	// Get the total length of the file in seconds
	for (int x = 0; x < Composition->NumTracks; x++)
	{
		// Loop through the events in each track
		MusicTrack Track = Composition->Tracks[x];
		for (int y = 0; y < Track.NumEvents; y++)
		{
			Event Event = Track.Events[y];
			float EventSpeed = 1.0f / Event.Speed / Speed;
			float EventStart = Event.Position / BeatsPerSecond;
			float EventEnd = EventStart + EventSpeed;
			FileSeconds = (FileSeconds > EventEnd ? FileSeconds : EventEnd);
		}
	}

	// Allocate memory for the new file
	int countNew = (int)(SamplesPerSecond * FileSeconds * Channels);
	int sizeNew = countNew * BytesPerSample;

	HANDLE hDataNew = HeapCreate(0, sizeNew, 0);
	if (!hDataNew)
		return false;

#define CLEANUP HeapDestroy(hDataNew);

	short *lpDataNew;
	if ((lpDataNew = (short *)HeapAlloc(hDataNew, HEAP_ZERO_MEMORY, sizeNew)) == NULL)
	{
		CLEANUP;
		return false;
	}

#undef CLEANUP
#define CLEANUP HeapFree(hDataNew, 0, lpDataNew); HeapDestroy(hDataNew);

	// Loop through the tracks and events
	for (int x = 0; x < Composition->NumTracks; x++)
	{
		// Loop through the events in each track
		MusicTrack Track = Composition->Tracks[x];
		for (int y = 0; y < Track.NumEvents; y++)
		{
			// Todo: Use Track.Position
			Event Event = Track.Events[y];
			int size = 0;
			TCHAR *FileName = GetSoundFileName(Track.InstrumentName, Event.NoteName, true); // Todo: Get rid of wave extension

			// Load the sound file
			HMMIO file = OpenSound(FileName, &size);

			// Make sure file is valid
			if (!file)
				return false;

#define CLEANUP2 mmioClose(file, 0);

			// File is at the beginning of the data chunk so we can just start
			// reading the files
			HANDLE hData = HeapCreate(0, size, 0);
			if (!hData)
			{
				CLEANUP;
				CLEANUP2;
				return false;
			}

#undef CLEANUP2
#define CLEANUP2 HeapDestroy(hData); mmioClose(file, 0);

			short *lpData;
			if ((lpData = (short *)HeapAlloc(hData, HEAP_ZERO_MEMORY, size)) == NULL)
			{
				CLEANUP;
				CLEANUP2;
				return false;
			}

#undef CLEANUP2
#define CLEANUP2 HeapFree(hData, 0, lpData); HeapDestroy(hData); mmioClose(file, 0);

			// Finally we can read in the file
			if (mmioRead(file, (char *)lpData, size) != size)
			{
				CLEANUP;
				CLEANUP2;
				return false;
			}

			// Get the offset from the beginning of the file
			float EventStart = Event.Position / BeatsPerSecond;
			int offset = (int)(SamplesPerSecond * Channels * EventStart);

			// Mix the data
			int MixCount = (int)(SamplesPerSecond / Event.Speed / Speed);
			InsertInstrument(lpDataNew + offset, lpData, MixCount, Composition->Gain, Composition->GainLeft, Composition->GainRight, (Channels == 2), FADE_LOGARITHMIC, SamplesPerSecond / 16);

			CLEANUP2;
		}
	}

	// Fade in the beginning
	if (Composition->FadeInBeginning)
		FadeIn(lpDataNew, (int)(Composition->FadeTime * SamplesPerSecond), Composition->FadeType);

	// Fade out the end
	if (Composition->FadeOutEnd)
		FadeOut(lpDataNew + countNew - (int)(Composition->FadeTime * SamplesPerSecond), (int)(Composition->FadeTime * SamplesPerSecond), Composition->FadeType);

	// Create a new file
	HMMIO fileNew = mmioOpen(OutputFileName, NULL, MMIO_CREATE | MMIO_WRITE | MMIO_ALLOCBUF);

	if (!fileNew)
	{
		CLEANUP;
		return false;
	}

#undef CLEANUP
#define CLEANUP HeapFree(hDataNew, 0, lpDataNew); HeapDestroy(hDataNew); mmioClose(fileNew, 0);

	// Create a "WAVE" chunk of type "RIFF"
	MMCKINFO mmckinfoWave;
	mmckinfoWave.cksize = 0;
	mmckinfoWave.fccType = CHUNK_WAVE;

	mmioCreateChunk(fileNew, &mmckinfoWave, MMIO_CREATERIFF);

	// Create format chunk
	MMCKINFO mmckinfo;
	ZeroMemory(&mmckinfo, sizeof(MMCKINFO));
	mmckinfo.ckid = CHUNK_FMT;
	mmckinfo.cksize = sizeof(PCMWAVEFORMAT);

	PCMWAVEFORMAT pwf;
	pwf.wBitsPerSample = 16;
	pwf.wf.wFormatTag = WAVE_FORMAT_PCM;
	pwf.wf.nChannels = Channels;
	pwf.wf.nSamplesPerSec = 44100;
	pwf.wf.nBlockAlign = pwf.wf.nChannels * pwf.wBitsPerSample / 8;
	pwf.wf.nAvgBytesPerSec = pwf.wf.nSamplesPerSec * pwf.wf.nBlockAlign * pwf.wf.nChannels;

	mmioCreateChunk(fileNew, &mmckinfo, 0);

	mmioWrite(fileNew, (char *)&pwf, sizeof(PCMWAVEFORMAT));

	// Ascend out of fmt chunk
	mmioAscend(fileNew, &mmckinfo, 0);

	// Create data chunk
	ZeroMemory(&mmckinfo, sizeof(MMCKINFO));
	mmckinfo.ckid = CHUNK_DATA;
	mmckinfo.cksize = sizeNew;

	mmioCreateChunk(fileNew, &mmckinfo, 0);

	mmioWrite(fileNew, (char *)lpDataNew, sizeNew);

	// Ascend out of the wave chunk, corrects the chunk size
	mmioAscend(fileNew, &mmckinfoWave, 0);

	CLEANUP;

	return true;
}
