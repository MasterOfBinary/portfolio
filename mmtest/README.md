MMTest Project
===========

*C++ application - uses winmm.lib*

A semi-functional wavetable synthesizer. I recorded a bunch of notes on the guitar into separate files, and made this library to make a song with the notes given to it. It uses winmm to open the wave files and work directly with the audio data.

Problems
----------

When testing it, I had it running but the output file wouldn't open in Windows Media Player. It opened fine in GoldWave, though, so I saved it as an MP3 in the binaries zip so you can see (or rather, hear) what the output sounds like.

Another problem I had when I ran it from the zip file - it wouldn't work. It most likely has something to do with the hard-coded (bad, I know) file and folder names. It will write a file "C:\MMTest.wav", and read from the "Century Sound Studio" folder in the zip file. If you want the program to run you might have to get the source code and change the #defines so that it will work.
