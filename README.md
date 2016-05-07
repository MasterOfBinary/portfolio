Vaughn Friesen's Portfolio
==========================

Some of the programming work I've done in the past is available here. These are mostly projects I did by myself, in my spare time. The exception is the Bubble Cursor project, which I developed with one teammate for a university project.

Each project has a `README.md` file that describes the project, and most have source code. Binaries for Windows are in a `bin/` directory under the project directory.

Most of these projects used Visual Studio 2005. My favourite programming language for Windows development is C#, so that's the language I used for nearly all of them. But I'll indicate where I used a different language (usually C++), or a specific library.

Project Overview
----------------

* [audioinfo](audioinfo) - An MP3 tag editor.
* [binaryviewer](binaryviewer) - Opens files and displays them in ASCII, decimal, hexadecimal, and binary notations.
* [bubblecursor](bubblecursor) - A variation of the basic mouse cursor that always selects the nearest control.
* [codecounter](codecounter) - Counts the lines of code and number of files in a folder.
* [dotnettests](dotnettests) - Several tests I used to try out features of .NET.
* [mmtest](mmtest) - A semi-functional wavetable synthesizer.
* [onyxtouch](onyxtouch) - An FFT ocean test using the gameplay3d engine from BlackBerry.
* [pagerank](pagerank) - A simple Matlab application to test the convergence of the PageRank algorithm.
* [pge](pge) - A game and game engine using DirectX 10.

ePeriod Software
----------------

I have also developed two BlackBerry 10 apps which I've recently open-sourced. They are available at https://github.com/eperiod-software.

Problems
--------

Many of these were just for my learning, or for my own use, and haven't been tested like they should. There are definitely problems and areas that could be improved considerably, but I probably won't be developing them anymore. That being said, go ahead and use anything that you think may be useful - they are all free, and you can get the source code for most of them too!

Much as I would like to get them all to work right out of the box when you download them, some may not. I'll try to let you know where you might have problems and what you might be able to do to fix them. But I can't make any guarantees that they will compile or run.

For the C++ ones, if you don't have Visual Studio you will need to download the Visual C++ 2010 redistributable. Install the 32-bit one on 32-bit Windows, and both on 64-bit Windows. For the DirectX 10 one (*pge*) you will need the latest version of DirectX. Links are at the bottom of this file.

Compiling
---------

I made sure I could compile all the code here before uploading it, but while doing so, I updated the solutions for Visual Studio 2010. They still target the .NET 2.0 though, so it may be possible to load the solutions in earlier versions of Visual Studio. I'm not sure. But you can download the binaries still, and try them out (again, except where I indicate there may be a problem).

Redistributables
----------------

As promised, here are links to the redistributables you may need:

**Visual C++ 2010 SP1** for Windows XP or higher

- 32-bit: http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=8328
- 64-bit: http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=13523

**.NET Framework 4.0** for Windows XP SP3 or higher

- 32-bit or 64-bit: http://www.microsoft.com/download/en/details.aspx?id=17851

**DirectX 10**

- Windows Vista+: http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=35
