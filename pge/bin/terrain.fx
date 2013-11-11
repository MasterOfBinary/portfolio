//
// Structures
//
struct VS_INPUT
{
    float4 Pos : POSITION;
    float3 Norm : NORMAL;
    float2 Tex : TEXCOORD0;
    float4 TexWeights : TEXCOORD1;
};

struct PS_INPUT
{
    float4 Pos : SV_POSITION;
    float3 Norm : TEXCOORD0;
    float2 Tex : TEXCOORD1;
    float4 TexWeights : TEXCOORD2;
};

Texture2D tx1;
Texture2D tx2;
Texture2D tx3;
Texture2D tx4;

SamplerState sam
{
    Filter = MIN_MAG_MIP_LINEAR;
    AddressU = Wrap;
    AddressV = Wrap;
};

cbuffer cbConstant
{
    float3 LightDir = normalize(float3(-0.1, 1.0, -0.1));
};

cbuffer cbChangesEveryFrame
{
    matrix World;
    matrix View;
    matrix Projection;
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
    Out.Norm = mul(In.Norm, World);
    Out.Tex = In.Tex;
    Out.TexWeights = In.TexWeights;
    return Out;
}


//
// Pixel Shader
//
float4 PS(PS_INPUT In) : SV_Target
{
	// Calculate lighting assuming light color is <1,1,1,1>
	float4 OutputColor;
	float4 DiffuseColor;
	
	DiffuseColor = tx1.Sample(sam, In.Tex) * In.TexWeights.x;
	DiffuseColor += tx2.Sample(sam, In.Tex) * In.TexWeights.y;
	DiffuseColor += tx3.Sample(sam, In.Tex) * In.TexWeights.z;
	DiffuseColor += tx4.Sample(sam, In.Tex) * In.TexWeights.w;
	
	float Brightness = saturate(dot(In.Norm, LightDir));
    
    return saturate(float4(0.1, 0.1, 0.1, 1.0) * DiffuseColor + Brightness * DiffuseColor);
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

