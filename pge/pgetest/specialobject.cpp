#include "stdafx.h"
#include "pgetest.h"

SpecialObject::SpecialObject(Terrain *Terrain)
{
	m_Terrain = Terrain;
	m_Position = Vector3D();

	// m_RotY is a random number between 0 and Pi2
	m_RotY = (float)((double)rand() / (RAND_MAX + 1) * Pi2);

	m_Mesh = NULL;
}

void SpecialObject::Initialize(Engine *Engine)
{
	m_Engine = Engine;
}

void SpecialObject::Created()
{
	RandomizePosition();
}

void SpecialObject::BeforeUpdate()
{ }

void SpecialObject::Update(float RelativeTime)
{
	//m_RotY += 0.05f * RelativeTime;
	if (m_RotY > Pi2)
		m_RotY -= Pi2;

	Matrix translation, rotation, matrix;
	D3DXMatrixRotationY(&rotation, m_RotY);
	D3DXMatrixTranslation(&translation, m_Position.X, m_Position.Y, m_Position.Z);
	D3DXMatrixMultiply(&matrix, &rotation, &translation);
	m_Mesh->SetWorldMatrix(&matrix);
}

void SpecialObject::Collision(GameObjectBase *Object)
{
	if (Object->GetType() == TYPE_SPACESHIP)
		RandomizePosition();
}

void SpecialObject::SetPosition(Vector3D Position)
{
	m_Position = Position;
}

Vector3D SpecialObject::GetPosition()
{
	return m_Position;
}

Mesh *SpecialObject::GetMesh()
{
	return m_Mesh;
}

BoundingSphere *SpecialObject::GetBoundingSphere()
{
	return new BoundingSphere(m_Position, m_Mesh->GetMeshRadius());
}

void SpecialObject::RandomizePosition()
{
	Rect bounds = m_Terrain->GetBounds();
	m_Position = Vector3D((float)m_Random.NextInt((int)bounds.X, (int)(bounds.W + bounds.X)), 0,
		(float)m_Random.NextInt((int)bounds.Y, (int)(bounds.H + bounds.Y)));

	SceneObjects::PointInfo info = m_Terrain->GetTerrainPointInfo(m_Position.X, m_Position.Z);

	m_Position.Y = info.Position.Y + 4.0f;
}

Coin::Coin(Terrain *Terrain) : SpecialObject(Terrain)
{ }

void Coin::Initialize(Engine *Engine)
{
	SpecialObject::Initialize(Engine);

	m_Mesh = new Mesh(MeshLoader::LoadFromPGM("meshes\\coin.pgm"));
}

BronzeCoin::BronzeCoin(Terrain *Terrain) : Coin(Terrain)
{ }

void BronzeCoin::Initialize(Engine *Engine)
{
	Coin::Initialize(Engine);
}

void BronzeCoin::Created()
{
	SpecialObject::Created();

	m_Mesh->SetAmbientColor(Color(0.42f, 0.32f, 0.08f));
	m_Mesh->SetDiffuseColor(Color(0.84f, 0.64f, 0.17f));
}

int BronzeCoin::GetType()
{
	return TYPE_BRONZECOIN;
}

SilverCoin::SilverCoin(Terrain *Terrain) : Coin(Terrain)
{ }

void SilverCoin::Initialize(Engine *Engine)
{
	SpecialObject::Initialize(Engine);
}

void SilverCoin::Created()
{
	SpecialObject::Created();

	m_Mesh->SetAmbientColor(Color(0.4f, 0.4f, 0.4f));
	m_Mesh->SetDiffuseColor(Color(0.8f, 0.8f, 0.8f));
}

int SilverCoin::GetType()
{
	return TYPE_SILVERCOIN;
}

GoldCoin::GoldCoin(Terrain *Terrain) : Coin(Terrain)
{ }

void GoldCoin::Initialize(Engine *Engine)
{
	SpecialObject::Initialize(Engine);
}

void GoldCoin::Created()
{
	SpecialObject::Created();

	m_Mesh->SetAmbientColor(Color(0.46f, 0.42f, 0.19f));
	m_Mesh->SetDiffuseColor(Color(0.9f, 0.85f, 0.38f));
}

int GoldCoin::GetType()
{
	return TYPE_GOLDCOIN;
}
