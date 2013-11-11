Perspective GX Game Engine
=============

*C++ application - uses DirectX 10*

This was a game engine I was working on that used DirectX 10, and a game to go with it. I originally made a similar game with XNA, but wasn't able to get that one to compile with VS 2010. It was much the same as this one, only you could have several players and play a game of tag.

This project is fairly simple as it is, but can be customized easily if you change the parameters. I made 6 tracks, which are made using 4 bitmap files in a folder. The game automatically creates the terrain using the bitmaps. To change the map, all you have to do is add a parameter to the command line: "-t" + the number of the track you want (1 - 6). For example, "-t3" to choose the third track.

Another thing that can be customized is the number of players. If you use the command line "-p1" to "-p4" you can have from 1 to 4 players.

Another thing I sometimes did was enable wireframe mode - usually for debugging (or just for fun). You can turn on wireframe mode by uncommenting lines 99 and 100 in pgetest.cpp. At one point I had random coins placed on the map that you could get for points, and I noticed lines commented some places that make that happen. If you like, you can try to find them and uncomment them and see what happens - it's better with more than one player though.

Problems
--------

If you have problems with the program, make sure you have DirectX 10 - which only works on Windows Vista. I found when I ran it from Visual Studio it would sometimes start from a different folder, so the files wouldn't load and it would crash. If that happens, try making a shortcut to pgetest.exe, check the shortcut properties, and make sure the Start in folder is the folder it's in.

Compiling
---------

If it doesn't compile in Visual Studio, make sure each project has (1) the DirectX include directory and (2) the DirectX x86 library directory set. It seems like you can't set directories that are used by every project anymore like you could in VS 2005 - maybe I just haven't found out how yet. *Edit: I figured out how, but I haven't updated the project. Sorry.*
