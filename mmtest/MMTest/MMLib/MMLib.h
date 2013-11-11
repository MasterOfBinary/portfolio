// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the MMLIB_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// MMLIB_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef MMLIB_EXPORTS
#define MMLIB_API __declspec(dllexport)
#else
#define MMLIB_API __declspec(dllimport)
#endif

#include <vector>

#define FADE_NONE 0
#define FADE_LINEAR 1
#define FADE_LOGARITHMIC 2
#define FADE_EXPONENTIAL 3

struct MMLIB_API Event
{
	Event();
	Event(TCHAR *NoteName, float Position = 0, float Speed = 1);
	Event(const Event &Copy);

	TCHAR *NoteName;

	float Position;
	float Speed;
};

struct MMLIB_API MusicTrack
{
	MusicTrack();
	MusicTrack(TCHAR *InstrumentName);

	// Instrument name, e.g. "Piano"
	TCHAR *InstrumentName;

	// Events
	Event *Events;
	int NumEvents;
};

struct MMLIB_API Composition
{
	Composition();

	// Time signature
	int BeatsPerMeasure;
	int NoteValue;

	// Music speed
	float BeatsPerMinute;

	// Music volume
	float Gain;
	float GainLeft;
	float GainRight;

	// Music fade
	float FadeTime; // Fade time in seconds
	int FadeType;
	bool FadeInBeginning, FadeOutEnd;

	// Tracks
	MusicTrack *Tracks;
	int NumTracks;
};

MMLIB_API bool BuildComposition(Composition *Composition, TCHAR *OutputFileName);
