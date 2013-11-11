// MMTest.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "MMTest.h"
#include "MMLib.h"

#define OUTPUT_FILENAME L"C:\\MMTest.wav"

bool DoSound()
{
	// Note time:
	// 1 is a whole note, 2 a half note, 4 a quarter note, etc.
	// Decimals are allowed, for example, 1.33 is a dotted half note (3 beats).
	// Todo: does this work in times other than 4/4? - 3/4? 2/4? others?

	// To calculate # of beats: 4 / Time = Beats.
	//   4 / 2 = 2 beats (half note).
	//   4 / 1.33 = 3 beats (dotted half note).
	//   4 / 8 = 0.5 beats (eighth note).
	// Therefore, to calculate time: 4 / Beats = Time.
	//   4 / 1.5 beats = 2.67 (dotted quarter note).
	//   4 / 0.75 beats = 5.33 (dotted eighth note).
	//   4 / 1 beats = 4 (quarter note).

	// Note position:
	// Position is the number of beats from the beginning of the song.
	// Decimals are allowed, for example, 0.5 is half a beat from the beginning.
	Composition c;
	c.BeatsPerMinute = 120;
	c.Gain = 0.5f;
	c.FadeOutEnd = true;
	c.FadeTime = 2.0f;

	MusicTrack track;

	Event evts[11];

	evts[0] = Event(L"C-1", 0, 4);
	evts[1] = Event(L"D-1", 1, 4);
	evts[2] = Event(L"E-1", 2, 4);
	evts[3] = Event(L"C-1", 3, 4);
	evts[4] = Event(L"C-1", 4, 4);
	evts[5] = Event(L"D-1", 5, 4);
	evts[6] = Event(L"E-1", 6, 4);
	evts[7] = Event(L"C-1", 7, 4);
	evts[8] = Event(L"E-1", 8, 4);
	evts[9] = Event(L"F-1", 9, 4);
	evts[10] = Event(L"G-1", 10, 2);

	c.Tracks = &track;
	c.NumTracks = 1;

	track.Events = evts;
	track.NumEvents = sizeof(evts) / sizeof(Event);

	return BuildComposition(&c, OUTPUT_FILENAME);
}

int APIENTRY _tWinMain(HINSTANCE, HINSTANCE, LPTSTR, int)
{
	if (!DoSound())
	{
		while (MessageBox(NULL, L"Error creating sound file.", L"MMTest", MB_RETRYCANCEL | MB_ICONERROR) == IDRETRY)
		{
			if (DoSound())
				break;
		}
	}

	return 0;
}
