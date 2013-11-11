//
// Structures
//
struct VS_INPUT
{
    float4 Pos : POSITION;
    float3 Norm : NORMAL;
    float2 Tex : TEXCOORD0;
};

struct PS_INPUT
{
    float4 Pos : SV_POSITION;
    float3 Norm : TEXCOORD0;
    float2 Tex : TEXCOORD1;
    float3 HalfVec : TEXCOORD2;
};

Texture2D tx;

SamplerState sam
{
    Filter = MIN_MAG_MIP_LINEAR;
    AddressU = Wrap;
    AddressV = Wrap;
};

cbuffer cbConstant
{
	float4 SpecularColor = float4(1.0, 1.0, 1.0, 1.0);
	float3 LightDir = normalize(float3(-0.1, 1.0, -0.1));
	float Shininess = 24.0f;
};

cbuffer cbChangesSometimes
{
	float4 AmbientColor = float4(0.2, 0.2, 0.2, 1.0);
	float4 DiffuseColor = float4(0.5, 0.5, 0.5, 1.0);
	bool Textured = false;
};

cbuffer cbChangesEveryFrame
{
    matrix World;
    matrix View;
    matrix Projection;
    matrix ViewInverse;
};

//
// Vertex Shader
//
PS_INPUT VS(VS_INPUT In)
{
	PS_INPUT Out = (PS_INPUT)0;
	
	Out.Pos = mul(In.Pos, World);
    Out.Pos = mul(Out.Pos, View);
    Out.Pos = mul(Out.Pos, Projection);
    Out.Norm = normalize(mul(In.Norm, World));
    Out.Tex = In.Tex;
    
    // Get the half vector
    float3 EyePos = ViewInverse[3];
    float3 WorldPos = mul(In.Pos, World);
    float3 EyeVector = normalize(EyePos - WorldPos);
    Out.HalfVec = normalize(EyeVector + LightDir);
    
    return Out;
}


//
// Pixel Shader
//
float4 PS(PS_INPUT In) : SV_Target
{
	float Brightness = saturate(dot(In.Norm, LightDir));
	float SpecularAmt = pow(dot(In.Norm, In.HalfVec), Shininess);
	float4 Specular = saturate(SpecularColor * SpecularAmt);
	
	float4 diffuse = DiffuseColor;
	
	if (Textured)
		diffuse *= tx.Sample(sam, In.Tex);
	
    return (AmbientColor + Brightness * diffuse) + Specular;
}


technique10 Render
{
    pass P0
    {
        SetVertexShader(CompileShader(vs_4_0, VS()));
        SetGeometryShader(NULL);
        SetPixelShader(CompileShader(ps_4_0, PS()));
    }
}