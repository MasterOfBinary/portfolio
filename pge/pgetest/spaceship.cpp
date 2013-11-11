#include "stdafx.h"
#include "pgetest.h"

SpaceShip::SpaceShip(Terrain *Terrain, Vector3D Position)
{
	m_Terrain = Terrain;
	m_Camera = new Camera();

	m_Position = Position;

	m_Points = 0;

	m_Moving = false;
	m_Turning = false;

	m_Speed = 0.0f;
	m_MaxBank = 0.5f;
	m_MaxSpeed = 6.0f;
	m_RelativeTime = 0.0f;
	m_Acceleration = 0.1f;

	m_NumKPH = 20;
	m_KPH = new int[m_NumKPH];
	ZeroMemory(m_KPH, sizeof(int) * m_NumKPH);
	m_NextKPH = 0;

	m_RotY = 0.0f;
	m_RotZ = 0.0f;
	D3DXQuaternionIdentity(&m_QuatY);
	D3DXQuaternionIdentity(&m_QuatZ);

	m_Mesh = NULL;
}

void SpaceShip::Initialize(Engine *Engine)
{
	m_Engine = Engine;

	MeshParams *params2 = MeshLoader::LoadFromPGM("meshes\\ship1.pgm");

	m_Mesh = new Mesh(params2);
}

void SpaceShip::Created()
{ }

void SpaceShip::BeforeUpdate()
{
	m_Turning = false;
	m_Moving = false;
}

void SpaceShip::Update(float RelativeTime)
{
	m_RelativeTime = RelativeTime;

	if (!m_Moving)
	{
		// Allow friction to slow the ship down
		float NewSpeed = m_Speed - m_Speed * m_Acceleration * m_RelativeTime * 0.2f;

		if (m_Speed > 0)
			m_Speed = (NewSpeed < 0 ? 0 : NewSpeed);
		else
			m_Speed = (NewSpeed > 0 ? 0 : NewSpeed);
	}

	if (!m_Turning)
	{
		// Rotate back to normal
		float NewRot = abs(m_RotZ) - 0.03f * m_RelativeTime;
		if (NewRot < 0)
			NewRot = 0;

		if (m_RotZ > 0)
			m_RotZ = NewRot;
		else
			m_RotZ = -NewRot;
	}

	// Set y-rotation
	m_RotY -= 0.01f * m_RotZ * m_Speed * m_RelativeTime;

	// Rotate ship
	D3DXMATRIX matrix;
	D3DXQuaternionRotationAxis(&m_QuatY, new D3DXVECTOR3(0, 1, 0), m_RotY);
	D3DXQuaternionRotationAxis(&m_QuatZ, new D3DXVECTOR3(0, 0, 1), m_RotZ);

	D3DXVECTOR4 vec = D3DXVECTOR4(0, 0, 1, 1);
	D3DXVec4Transform(&vec, &vec, D3DXMatrixRotationQuaternion(&matrix, &m_QuatY));
	D3DXVec4Normalize(&vec, &vec);

	// Move ship
	Vector3D OldPosition = m_Position;
	D3DXVECTOR4 newvec = vec * m_Speed * m_RelativeTime;
	m_Position += Vector3D(newvec.x, newvec.y, newvec.z);

	FollowTerrain();

	// Compare current position height and new position height
	float Scale = 1.0f;
	if (OldPosition.Y > m_Position.Y) // Ship is going down
		Scale += (OldPosition.Y - m_Position.Y);
	else if (OldPosition.Y < m_Position.Y) // Ship is going up
		Scale -= (m_Position.Y - OldPosition.Y) * 0.1f;

	// Move ship
	vec *= m_Speed * Scale * m_RelativeTime;
	m_Position = OldPosition + Vector3D(vec.x, vec.y, vec.z);

	// Set kilometres per hour
	m_NextKPH++;
	if (m_NextKPH == m_NumKPH)
		m_NextKPH = 0;

	m_KPH[m_NextKPH] = abs((int)(m_Speed * Scale * 100.0f));
	
	FollowTerrain();

	// See if the player is going off the edge
	Rect bounds = m_Terrain->GetBounds();

	if (m_Position.X < bounds.X)
		m_Position.X = bounds.X;
	else if (m_Position.X > bounds.X + bounds.W)
		m_Position.X = bounds.X + bounds.W;

	if (m_Position.Z < bounds.Y)
		m_Position.Z = bounds.Y;
	else if (m_Position.Z > bounds.Y + bounds.H)
		m_Position.Z = bounds.Y + bounds.H;

	// Update camera
	UpdateCamera();

	// Set mesh position
	Matrix pos, rot, out;
	Quaternion quat = m_QuatZ * m_QuatY;
	D3DXMatrixTranslation(&pos, m_Position.X, m_Position.Y, m_Position.Z);
	D3DXMatrixRotationQuaternion(&rot, &quat);
	out = rot * pos;

	m_Mesh->SetWorldMatrix(&out);
}

void SpaceShip::Collision(GameObjectBase *Object)
{
	/*if (Object->GetType() == TYPE_SPACESHIP)
		m_Speed = max(-0.1f, min(0.1f, m_Speed));
	else if (Object->GetType() == TYPE_BRONZECOIN)
		m_Points += 50;
	else if (Object->GetType() == TYPE_SILVERCOIN)
		m_Points += 100;
	else if (Object->GetType() == TYPE_GOLDCOIN)
		m_Points += 500;*/
}

int SpaceShip::GetType()
{
	return TYPE_SPACESHIP;
}

void SpaceShip::SetPosition(Vector3D Position)
{
	m_Position = Position;

	UpdateCamera();
}

Vector3D SpaceShip::GetPosition()
{
	return m_Position;
}

void SpaceShip::SetRotationY(float Rotation)
{
	m_RotY = Rotation;
}

Camera *SpaceShip::GetCamera()
{
	return m_Camera;
}

void SpaceShip::TurnLeft()
{
	// Bank while turning
	m_RotZ += 0.04f * m_RelativeTime;

	// Limit banking
	if (m_RotZ > m_MaxBank)
		m_RotZ = m_MaxBank;

	m_Turning = true;
}

void SpaceShip::TurnRight()
{
	// Bank while turning
	m_RotZ -= 0.04f * m_RelativeTime;

	// Limit banking
	if (m_RotZ < -m_MaxBank)
		m_RotZ = -m_MaxBank;

	m_Turning = true;
}

void SpaceShip::MoveForward()
{
	// Limit speed
	if (m_Speed + m_Acceleration <= m_MaxSpeed)
		m_Speed += m_Acceleration * m_RelativeTime;

	// See if we're going too fast
	if (m_Speed > m_MaxSpeed)
		m_Speed -= m_Acceleration * m_RelativeTime;

	m_Moving = true;
}

void SpaceShip::MoveBackward()
{
	// Backwards we can only go half the speed
	if (m_Speed - m_Acceleration >= -m_MaxSpeed * 0.5f)
		m_Speed -= m_Acceleration * m_RelativeTime;

	// See if we're going too fast
	if (m_Speed < -m_MaxSpeed * 0.5f)
		m_Speed -= m_Acceleration * m_RelativeTime;

	m_Moving = true;
}

void SpaceShip::Brake()
{
	// Slow down quickly
	float NewSpeed = m_Speed - m_Speed * m_Acceleration * m_RelativeTime;

	if (m_Speed > 0)
		m_Speed = (NewSpeed < 0 ? 0 : NewSpeed);
	else
		m_Speed = (NewSpeed > 0 ? 0 : NewSpeed);
}

Mesh *SpaceShip::GetMesh()
{
	return m_Mesh;
}

BoundingSphere *SpaceShip::GetBoundingSphere()
{
	return new BoundingSphere(m_Position, m_Mesh->GetMeshRadius());
}

int SpaceShip::GetSpeed()
{
	// Average the speeds
	int total = 0;
	for (int x = 0; x < m_NumKPH; x++)
		total += m_KPH[x];
	return total / m_NumKPH;
}

int SpaceShip::GetPoints()
{
	return m_Points;
}

void SpaceShip::UpdateCamera()
{
	// Update the camera
	D3DXMATRIX matrix;

	D3DXVECTOR4 vec = D3DXVECTOR4(0, 6, -16, 1);
	D3DXVec4Transform(&vec, &vec, D3DXMatrixRotationQuaternion(&matrix, &m_QuatY));

	Vector3D eye = Vector3D(vec.x + m_Position.X, vec.y + m_Position.Y, vec.z + m_Position.Z);
	m_Camera->SetAllVectors(eye, m_Position, Vector3D(0, 1, 0));
}

void SpaceShip::FollowTerrain()
{
	// Follow terrain
	SceneObjects::PointInfo info = m_Terrain->GetTerrainPointInfo(m_Position.X, m_Position.Z);
	
	float height = info.Position.Y + 2.0f;
	float movement = 1 / abs(m_Speed * m_RelativeTime) * 1.2f;

	if (m_Position.Y - height > movement)
		m_Position.Y -= movement;
	else
	{
		// On the ground
		m_Position.Y = height;
	}
}

UserShip1::UserShip1(SceneObjects::Terrain *Terrain, Vector3D Position) : SpaceShip(Terrain, Position)
{ }

void UserShip1::Created()
{
	SpaceShip::Created();

	m_Mesh->SetAmbientColor(Color(0.2f, 0.0f, 0.0f));
	m_Mesh->SetDiffuseColor(Color(0.6f, 0.0f, 0.0f));
}

void UserShip1::Update(float RelativeTime)
{
	m_RelativeTime = RelativeTime;

	if ((IsKeyDown(VK_UP)) && (IsKeyDown(VK_DOWN)))
		Brake();
	else if (IsKeyDown(VK_UP))
		MoveForward();
	else if (IsKeyDown(VK_DOWN))
		MoveBackward();

	if ((IsKeyDown(VK_LEFT)) && !(IsKeyDown(VK_RIGHT)))
		TurnLeft();
	if ((IsKeyDown(VK_RIGHT)) && !(IsKeyDown(VK_LEFT)))
		TurnRight();

	SpaceShip::Update(RelativeTime);
}

UserShip2::UserShip2(SceneObjects::Terrain *Terrain, Vector3D Position) : SpaceShip(Terrain, Position)
{ }

void UserShip2::Created()
{
	SpaceShip::Created();

	m_Mesh->SetAmbientColor(Color(0.0f, 0.0f, 0.2f));
	m_Mesh->SetDiffuseColor(Color(0.0f, 0.0f, 0.6f));
}

void UserShip2::Update(float RelativeTime)
{
	m_RelativeTime = RelativeTime;

	if ((IsKeyDown('W')) && (IsKeyDown('S')))
		Brake();
	else if (IsKeyDown('W'))
		MoveForward();
	else if (IsKeyDown('S'))
		MoveBackward();

	if ((IsKeyDown('A')) && !(IsKeyDown('D')))
		TurnLeft();
	if ((IsKeyDown('D')) && !(IsKeyDown('A')))
		TurnRight();

	SpaceShip::Update(RelativeTime);
}

UserShip3::UserShip3(SceneObjects::Terrain *Terrain, Vector3D Position) : SpaceShip(Terrain, Position)
{ }

void UserShip3::Created()
{
	SpaceShip::Created();

	m_Mesh->SetAmbientColor(Color(0.0f, 0.2f, 0.0f));
	m_Mesh->SetDiffuseColor(Color(0.0f, 0.6f, 0.0f));
}

void UserShip3::Update(float RelativeTime)
{
	m_RelativeTime = RelativeTime;

	if ((IsKeyDown('I')) && (IsKeyDown('K')))
		Brake();
	else if (IsKeyDown('I'))
		MoveForward();
	else if (IsKeyDown('K'))
		MoveBackward();

	if ((IsKeyDown('J')) && !(IsKeyDown('L')))
		TurnLeft();
	if ((IsKeyDown('L')) && !(IsKeyDown('J')))
		TurnRight();

	SpaceShip::Update(RelativeTime);
}

UserShip4::UserShip4(SceneObjects::Terrain *Terrain, Vector3D Position) : SpaceShip(Terrain, Position)
{ }

void UserShip4::Created()
{
	SpaceShip::Created();

	m_Mesh->SetAmbientColor(Color(0.2f, 0.2f, 0.0f));
	m_Mesh->SetDiffuseColor(Color(0.8f, 0.8f, 0.0f));
}

void UserShip4::Update(float RelativeTime)
{
	m_RelativeTime = RelativeTime;

	if ((IsKeyDown(VK_NUMPAD8)) && (IsKeyDown(VK_NUMPAD5)))
		Brake();
	else if (IsKeyDown(VK_NUMPAD8))
		MoveForward();
	else if (IsKeyDown(VK_NUMPAD5))
		MoveBackward();

	if ((IsKeyDown(VK_NUMPAD4)) && !(IsKeyDown(VK_NUMPAD6)))
		TurnLeft();
	if ((IsKeyDown(VK_NUMPAD6)) && !(IsKeyDown(VK_NUMPAD4)))
		TurnRight();

	SpaceShip::Update(RelativeTime);
}
