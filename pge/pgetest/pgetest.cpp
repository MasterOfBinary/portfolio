// pgedemo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "pgetest.h"

// Global Variables
HINSTANCE hInst;								          // Current instance
HWND hWnd;                                                // Main window
TCHAR szWindowClass[] = L"pgewdclass";			          // The main window class name
const int ScreenWidth = 800, ScreenHeight = 600;          // Screen size
const bool FullScreen = false;                            // Full screen
const float TerrainScale = 10.0f;                         // The terrain horizontal scale
Engine *pgeEngine = NULL;                                 // The Perspective engine
Camera *pgeCamera = NULL;                                 // The camera
Scene *pgeScene = NULL;                                   // The game scene
Font *FontCourier = NULL;                                 // The Courier font
Font *FontTimes = NULL;                                   // The Times New Roman font
SceneObjects::Terrain *terrain = NULL;                    // The terrain
Random pgeRandom;                                         // The random number generator
Timer pgeTimer;                                           // The timer
Viewport *v1 = NULL, *v2 = NULL, *v3 = NULL, *v4 = NULL, *vf = NULL; // The viewports
int NumPlayers = 1;                                       // Number of players - 1 - 4
String TrackDir = "tracks\\track1\\";                     // The current track directory
vector<SpaceShip *> Ships;                                // All the player ships
vector<SpecialObject *> SpecialObjects;                   // All the special objects
bool TopView = false;                                     // Whether the world is viewed from the top
bool Paused = false;                                      // Whether the game is paused

// Forward declarations of functions included in this code module
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
float *LoadTextureData(String FileName, int Width, int Height);
void PositionPlayers(String FileName);
void PositionWindow();
void SetupViewports();
void SetupProjection();
void SetupCamera(int ShipNum);

int WINAPI _tWinMain(HINSTANCE hInstance, HINSTANCE, LPTSTR, INT)
{
	// Parse command line
	LPWSTR *cmd;
	int args;
	cmd = CommandLineToArgvW(GetCommandLineW(), &args);
	if (cmd != NULL)
	{
		for (int x = 0; x < args; x++)
		{
			if (cmd[x][0] == '-')
			{
				if (cmd[x][1] == 'p')
				{
					switch (cmd[x][2])
					{
					case '2':
						NumPlayers = 2;
						break;
					case '3':
						NumPlayers = 3;
						break;
					case '4':
						NumPlayers = 4;
						break;
					}
				}
				else if (cmd[x][1] == 't')
				{
					if ((cmd[x][2] >= '1') && (cmd[x][2] <= '6'))
					{
						TrackDir = "tracks\\track";
						TrackDir += cmd[x][2];
						TrackDir += "\\";
					}
				}
			}
		}
	}

	LocalFree(cmd);

	hInst = hInstance; // Store instance handle in our global variable

	WNDCLASSEX wcex;
	ClearStruct(wcex);
	wcex.cbSize         = sizeof(WNDCLASSEX);
	wcex.style			= CS_CLASSDC;
	wcex.lpfnWndProc	= WndProc;
	wcex.hInstance		= hInstance;
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.lpszClassName	= szWindowClass;

	RegisterClassEx(&wcex);

	hWnd = CreateWindow(szWindowClass, L"Perspective GX Game Engine Demo",
		(FullScreen ? WS_EX_TOPMOST | WS_POPUP : WS_OVERLAPPEDWINDOW), CW_USEDEFAULT, 0,
		ScreenWidth, ScreenHeight, GetDesktopWindow(), NULL, hInstance, NULL);

	if (!hWnd)
		return 0;

	PositionWindow();

	pgeEngine = new Engine(hWnd);

	// Set the engine parameters
	InitParams params;
	ClearStruct(params);
	params.Width = ScreenWidth;
	params.Height = ScreenHeight;
	params.Windowed = !FullScreen;
	params.CreateDepthStencil = true;
	//params.RenderWireframe = true;
	//params.NoCulling = true;

	// Initialize the pge device
	if (pgeEngine->Create(&params) == PGE_RETURN_NOERROR)
	{
		// Turn on vertical sync
		pgeEngine->SetVSync(true);

		// Set up the viewports and projection matrix
		SetupViewports();
		SetupProjection();

		// Create the scene
		pgeScene = new Scene(pgeEngine);

		// Get the scene object collection
		SceneObjectCollection *c = pgeScene->GetObjectCollection();

		// Initialize the terrain
		SceneObjects::TerrainParams *p = SceneObjects::TerrainLoader::LoadFromBitmap(TrackDir + "map.bmp");
		
		// Setup textures
		p->TexturePaths = new String[4];
		p->TexturePaths[0] = TrackDir + "tex1.dds";
		p->TexturePaths[1] = TrackDir + "tex2.dds";
		p->TexturePaths[2] = TrackDir + "tex3.dds";
		p->TexturePaths[3] = TrackDir + "tex4.dds";
		p->NumTextures = 4;
		p->TextureCoords = Vector2D(80.0f, 80.0f);

		// Load texture data
		float *t1 = LoadTextureData(TrackDir + "texindex1.bmp", p->Width, p->Height);
		float *t2 = LoadTextureData(TrackDir + "texindex2.bmp", p->Width, p->Height);
		float *t3 = LoadTextureData(TrackDir + "texindex3.bmp", p->Width, p->Height);
		float *t4 = LoadTextureData(TrackDir + "texindex4.bmp", p->Width, p->Height);

		p->TextureData = new Vector4D[p->Width * p->Height];

		if ((t1) && (t2) && (t3) && (t4))
		{
			for (int x = 0; x < p->Width; x++)
			{
				for (int y = 0; y < p->Height; y++)
				{
					int index = x + y * p->Width;
					p->TextureData[index].X = t1[index];
					p->TextureData[index].Y = t2[index];
					p->TextureData[index].Z = t3[index];
					p->TextureData[index].W = t4[index];

					float total = p->TextureData[index].X + p->TextureData[index].Y +
						p->TextureData[index].Z + p->TextureData[index].W;
					if (total != 1.0)
					{
						p->TextureData[index].X /= total;
						p->TextureData[index].Y /= total;
						p->TextureData[index].Z /= total;
						p->TextureData[index].W /= total;
					}
				}
			}
		}

		delete []t1;
		delete []t2;
		delete []t3;
		delete []t4;

		// Scaling
		p->VScale = 1;
		p->HScale = TerrainScale;

		p->NumSmoothingPasses = 2;

		terrain = new SceneObjects::Terrain(p);

		// Create the user ships
		Ships.push_back((SpaceShip *)new UserShip1(terrain, Vector3D()));
		if (NumPlayers > 1)
		{
			Ships.push_back((SpaceShip *)new UserShip2(terrain, Vector3D()));
			if (NumPlayers > 2)
			{
				Ships.push_back((SpaceShip *)new UserShip3(terrain, Vector3D()));
				if (NumPlayers > 3)
					Ships.push_back((SpaceShip *)new UserShip4(terrain, Vector3D()));
			}
		}

		vector<SpaceShip *>::iterator iter;
		vector<SpecialObject *>::iterator so;

#define FOR_SHIPS for (iter = Ships.begin(); iter != Ships.end(); iter++)
#define CUR_SHIP (*iter)

#define FOR_SPECIAL for (so = SpecialObjects.begin(); so != SpecialObjects.end(); so++)
#define CUR_SPECIAL (*so)

		// Create the special objects
		/*for (int x = 0; x < 20; x++)
			SpecialObjects.push_back((SpecialObject *)new BronzeCoin(terrain));
		for (int x = 0; x < 10; x++)
			SpecialObjects.push_back((SpecialObject *)new SilverCoin(terrain));
		for (int x = 0; x < 1; x++)
			SpecialObjects.push_back((SpecialObject *)new GoldCoin(terrain));*/

		FOR_SHIPS
			CUR_SHIP->Initialize(pgeEngine);
		FOR_SPECIAL
			CUR_SPECIAL->Initialize(pgeEngine);

		// Add the scene objects
		c->AddSceneObject((SceneObject *)terrain);

		FOR_SHIPS
			c->AddSceneObject((SceneObject *)CUR_SHIP->GetMesh());
		FOR_SPECIAL
			c->AddSceneObject((SceneObject *)CUR_SPECIAL->GetMesh());

		// Create all the scene objects
		if (c->CreateAllSceneObjects(pgeEngine))
		{
			FOR_SHIPS
				CUR_SHIP->Created();
			FOR_SPECIAL
				CUR_SPECIAL->Created();

			// Position the ships
			PositionPlayers(TrackDir + "pos.bmp");

			// Create the top view camera
			pgeCamera = new Camera();
			pgeCamera->Create(pgeEngine);
			pgeCamera->SetAllVectors(Vector3D(0, terrain->GetTerrainPointInfo(0, 0).Position.Y + 40, 0),
				Vector3D(0, 0, 0), Vector3D(0, 1, 0));

			// Create the fonts
			FontParams font;
			ClearStruct(font);

			font.Width = 30;
			font.Bold = true;
			font.FaceName = "Courier New";
			FontCourier = new Font(&font);
			FontCourier->Create(pgeEngine);

			font.FaceName = "Times New Roman";
			FontTimes = new Font(&font);
			FontTimes->Create(pgeEngine);

			// Speeds
			Timer SpeedUpdate;
			SpeedUpdate.StartTimer();
			int Speeds[4] = { 0, 0, 0, 0 };

			// Show the window
			ShowWindow(hWnd, SW_SHOWDEFAULT);
			UpdateWindow(hWnd);

			// Main message loop
			MSG msg;
			DWORD StartTime = timeGetTime();

			ZeroMemory(&msg, sizeof(msg));
			while(msg.message != WM_QUIT)
			{
				if(PeekMessage(&msg, NULL, 0U, 0U, PM_REMOVE))
				{
					TranslateMessage(&msg);
					DispatchMessage(&msg);
				}
				else
				{
					if (Paused)
					{
						Sleep(50);

						pgeTimer.StartTimer();
					}
					else
					{
						// Update the scene
						FOR_SHIPS
							CUR_SHIP->BeforeUpdate();
						FOR_SPECIAL
							CUR_SPECIAL->BeforeUpdate();

						DWORD Elapsed = pgeTimer.EndTimer();
						float time = GetRelativeTime(Elapsed);

						FOR_SHIPS
							CUR_SHIP->Update(time);
						FOR_SPECIAL
							CUR_SPECIAL->Update(time);

						pgeTimer.StartTimer();

						// Check for ship/ship collision
						for (UINT x = 0; x < Ships.size(); x++)
						{
							for (UINT y = 0; y < Ships.size(); y++)
							{
								if ((Ships[x] != Ships[y]) &&
									(Ships[x]->GetBoundingSphere()->Intersects(Ships[y]->GetBoundingSphere())))
									Ships[x]->Collision(Ships[y]);
							}
						}

						// Check for ship/special collision
						for (UINT x = 0; x < Ships.size(); x++)
						{
							for (UINT y = 0; y < SpecialObjects.size(); y++)
							{
								if (Ships[x]->GetBoundingSphere()->Intersects(SpecialObjects[y]->GetBoundingSphere()))
								{
									Ships[x]->Collision(SpecialObjects[y]);
									SpecialObjects[y]->Collision(Ships[x]);
								}
							}
						}

						// Update the speed
						if (SpeedUpdate.GetTimeElapsed() > 100)
						{
							// Update speed every tenth of a second
							for (int x = 0; x < NumPlayers; x++)
								Speeds[x] = Ships[x]->GetSpeed();
							SpeedUpdate.ResetTimer();
						}
					}

					// Render the scene
					pgeEngine->BeginScene();

					if (TopView)
						pgeEngine->SetCurrentCamera(pgeCamera);

					pgeEngine->SetViewport(v1);
					SetupCamera(0);
					pgeEngine->DrawEntireScene(pgeScene);

					if (NumPlayers > 1)
					{
						pgeEngine->SetViewport(v2);
						SetupCamera(1);
						pgeEngine->DrawEntireScene(pgeScene);

						if (NumPlayers > 2)
						{
							pgeEngine->SetViewport(v3);
							SetupCamera(2);
							pgeEngine->DrawEntireScene(pgeScene);

							if (NumPlayers > 3)
							{
								pgeEngine->SetViewport(v4);
								SetupCamera(3);
								pgeEngine->DrawEntireScene(pgeScene);
							}
						}
					}

					// Display the speeds
					pgeEngine->SetViewport(vf);
					RECT rect;
					GetWindowRect(hWnd, &rect);
					Rect positions[4];
					ZeroMemory(positions, sizeof(Rect) * 4);
					positions[0].W = (float)v1->Width;
					positions[0].H = (float)v1->Height;

					if (NumPlayers > 1)
					{
						positions[1].X = (float)v2->TopLeftX;
						positions[1].Y = (float)v2->TopLeftY;
						positions[1].W = (float)v2->Width;
						positions[1].H = (float)v2->Height;

						if (NumPlayers > 2)
						{
							positions[2].X = (float)v3->TopLeftX;
							positions[2].Y = (float)v3->TopLeftY;
							positions[2].W = (float)v3->Width;
							positions[2].H = (float)v3->Height;

							if (NumPlayers > 3)
							{
								positions[3].X = (float)v4->TopLeftX;
								positions[3].Y = (float)v4->TopLeftY;
								positions[3].W = (float)v4->Width;
								positions[3].H = (float)v4->Height;
							}
						}
					}
					
					for (int x = 0; x < NumPlayers; x++)
					{
						// Get the color for the speed
						float red = 0.0f;
						float green = 0.0f;
						float blue = 0.0f;
						if (Speeds[x] < 200)
						{
							red = 1.0f;
							green = (float)Speeds[x] / 200.0f;
						}
						else if (Speeds[x] < 400)
						{
							red = 1.0f - (float)min(Speeds[x] - 200, 200) / 200.0f;
							green = 1.0f;
						}
						else if (Speeds[x] < 600)
						{
							green = 1.0f;
							blue = (float)(Speeds[x] - 400) / 200.0f;
						}
						else if (Speeds[x] < 800)
						{
							green = 1.0f - (float)min(Speeds[x] - 600, 200) / 200.0f;
							blue = 1.0f;
						}
						else
							blue = 1.0f;

						// Display speed at the bottom-left corner of each viewport
						String str = IntToString(Speeds[x]) + " km/h";
						Rect size = FontCourier->GetStringRect(str);
						Rect pos;
						pos.X = positions[x].X + 10;
						pos.Y = positions[x].Y + positions[x].H - size.H - 10;
						FontCourier->DrawString(str, pos, Color(red, green, blue));

						// Display score at the top-right corner of each viewport
						str = "Score: " + IntToString(Ships[x]->GetPoints());
						size = FontCourier->GetStringRect(str);
						pos.X = positions[x].X + positions[x].W - size.W - 10;
						pos.Y = positions[x].Y + 10;
						//FontTimes->DrawString(str, pos, Color(0.0f, 0.0f, 0.9f));
					}

					if (Paused)
					{
						String str = "Paused - Press F1 to start";
						Rect size = FontTimes->GetStringRect(str);
						float x = (rect.right - rect.left) / 2 - size.W / 2;
						FontTimes->DrawString(str, Rect(x, 10, 0, 0), Color(0.0f, 0.0f, 0.9f));
					}

					pgeEngine->EndSceneAndPresent();
				}
			}

			SpeedUpdate.EndTimer();
		}
		else
			MessageBox(NULL, L"An error occurred while creating the scene objects. The demo will now exit.", L"Perspective GX", MB_ICONERROR);

		FOR_SHIPS
			delete CUR_SHIP;
		FOR_SPECIAL
			delete CUR_SPECIAL;

		FontCourier->Destroy();
		FontTimes->Destroy();
		pgeScene->Destroy(true);
	}
	else
		MessageBox(NULL, L"An error occurred while setting up the Perspective GX Engine. The demo will now exit.", L"Perspective GX", MB_ICONERROR);
	
	float fps = pgeEngine->GetFramesPerSecond();

	pgeEngine->Destroy();

	UnregisterClass(szWindowClass, hInst);

	return 0;
}

float *LoadTextureData(String FileName, int Width, int Height)
{
	// Load the texture data
	float *texmap = NULL;

	Bitmap bitmap(FileName);

	UINT w = bitmap.GetWidth();
	UINT h = bitmap.GetHeight();

	if ((w == Width) && (h == Height))
	{
		texmap = new float[w * h];

		byte *b;

		for (UINT x = 0; x < w; x++)
		{
			for (UINT y = 0; y < h; y++)
			{
				b = (byte *)bitmap.GetPixel(x, y);

				// We need to invert Y because we are using left-handed coordinates
				texmap[x + (h - y - 1) * w] = (float)b[0] / 255.0f;
			}
		}
	}

	return texmap;
}

void PositionPlayers(String FileName)
{
	// Set each player position
	Bitmap bitmap(FileName);

	UINT w = bitmap.GetWidth();
	UINT h = bitmap.GetHeight();
	byte *b;

	Rect bounds = terrain->GetBounds();
	Vector3D at;

	for (UINT x = 0; x < w; x++)
	{
		for (UINT y = 0; y < h; y++)
		{
			b = (byte *)bitmap.GetPixel(x, y);

			if ((b) && (b[0] != 0))
			{
				float NewX = x * TerrainScale + bounds.X;
				float NewY = y * TerrainScale + bounds.Y;

				Vector3D vec = Vector3D(NewX, 0, -NewY);
				if (b[0] == 128)
					at = vec;
				else if (b[0] == 255)
					Ships[0]->SetPosition(vec);
				else if ((b[0] == 254) && (NumPlayers > 1))
					Ships[1]->SetPosition(vec);
				else if ((b[0] == 253) && (NumPlayers > 2))
					Ships[2]->SetPosition(vec);
				else if ((b[0] == 252) && (NumPlayers > 3))
					Ships[3]->SetPosition(vec);
			}
		}
	}

	// Point the ships at the look at vector
	for (int x = 0; x < NumPlayers; x++)
	{
		Vector3D pos = Ships[x]->GetPosition();
		D3DXVECTOR3 angle = D3DXVECTOR3(at.X - pos.X, 0.0f, at.Z - pos.Z);
		float yrot = atan2(angle.x, angle.z);
		if (yrot < 0)
			yrot += Pi2;
		Ships[x]->SetRotationY(yrot);
	}
}

void PositionWindow()
{
	// Position the window
	if (FullScreen)
		SetWindowPos(hWnd, NULL, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOREPOSITION);
	else
	{
		// Center the window
		RECT desktop, rc;
		GetWindowRect(hWnd, &rc);
		GetWindowRect(GetDesktopWindow(), &desktop);
		int x = (desktop.right - desktop.left) / 2 - (rc.right - rc.left) / 2;
		int y = (desktop.bottom - desktop.top) / 2 - (rc.bottom - rc.top) / 2;
		SetWindowPos(hWnd, NULL, x, y, 0, 0, SWP_NOSIZE | SWP_NOREPOSITION);
	}
}

void SetupViewports()
{
	SafeDelete(v1);
	SafeDelete(v2);
	SafeDelete(v3);
	SafeDelete(v4);
	SafeDelete(vf);

	vf = pgeEngine->CreateDefaultViewport();

	v1 = pgeEngine->CreateDefaultViewport();

	if (NumPlayers > 1)
		v2 = pgeEngine->CreateDefaultViewport();

	if (NumPlayers > 2)
		v3 = pgeEngine->CreateDefaultViewport();

	if (NumPlayers > 3)
		v4 = pgeEngine->CreateDefaultViewport();

	RECT rect;
	GetClientRect(hWnd, &rect);
	int width = rect.right - rect.left;
	int height = rect.bottom - rect.top;

	if (NumPlayers == 2)
	{
		v2->TopLeftY = v1->Height = v2->Height = height / 2;
	}
	else if (NumPlayers == 3)
	{
		v2->TopLeftY = v3->TopLeftY = v1->Height = v2->Height = v3->Height = height / 2;
		v3->TopLeftX = v2->Width = v3->Width = width / 2;
	}
	else if (NumPlayers == 4)
	{
		v3->TopLeftY = v4->TopLeftY = v1->Height = v2->Height = v3->Height = v4->Height = height / 2;
		v2->TopLeftX = v4->TopLeftX = v1->Width = v2->Width = v3->Width = v4->Width = width / 2;
	}
}

void SetupProjection()
{
	ProjectionFov *fov = pgeEngine->CreateDefaultProjectionFov();

	fov->FovY = PiDiv3;

	if (NumPlayers == 2)
		fov->Aspect *= 2;

	pgeEngine->SetProjectionFov(fov);
}

void SetupCamera(int ShipNum)
{
	if (TopView)
	{
		pgeCamera->SetLookAtVector(Ships[ShipNum]->GetPosition());
		if ((Ships[ShipNum]->GetPosition().X == 0) &&
			(Ships[ShipNum]->GetPosition().Z == 0))
			pgeCamera->SetUpVector(Vector3D(0, 0, 1));
		else
			pgeCamera->SetUpVector(Vector3D(0, 1, 0));
	}
	else
		pgeEngine->SetCurrentCamera(Ships[ShipNum]->GetCamera());
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_ACTIVATE:
		if ((LOWORD(wParam) != WA_ACTIVE) && LOWORD(wParam) != WA_CLICKACTIVE)
			Paused = true;
		return 0;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	case WM_KEYDOWN:
		if (wParam == VK_ESCAPE)
			PostQuitMessage(0);
		else if (wParam == VK_F1)
			Paused = !Paused;
		else if (wParam == VK_F2)
			TopView = !TopView;
		else if (wParam == VK_F4)
			pgeEngine->SetFullScreen(!pgeEngine->IsFullScreen());
		return 0;
	case WM_SIZE:
		if (wParam == SIZE_MINIMIZED)
			Paused = true;
		else
		{
			SetupViewports();
			SetupProjection();
			pgeEngine->ResizeWindow();
		}
		return 0;
	}

	return DefWindowProc(hWnd, message, wParam, lParam);
}
