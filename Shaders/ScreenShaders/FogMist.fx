sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);
float3 uColor;
float3 uSecondaryColor;
float2 uScreenResolution;
float2 uScreenPosition;
float2 uTargetPosition;
float2 uDirection;
float uOpacity;
float uTime;
float uIntensity;
float uProgress;
float2 uImageSize1;
float2 uImageSize2;
float2 uImageSize3;
float2 uImageOffset;
float uSaturation;
float4 uSourceRect;
float2 uZoom;
bool uHasLantern;

float4 FogMist(float2 coords : TEXCOORD0) : COLOR0
{
    float2 squareUV = coords * 2. - 1.;
    
    float4 color = tex2D(uImage2, coords * 2. - 1.  + uTime * 0.1) * uColor.rgbr;
    float4 mask = tex2D(uImage2,coords+ uTime * 0.1);
    
    color *= mask.r * 5;
    float circle = length(squareUV);
    
    return saturate(tex2D(uImage0, coords) + color * smoothstep(0., uHasLantern ? 25 : 5, circle) * 25) * uColor.rgbr * mask.r;
    
    
}

technique Technique1
{
    pass FogMistPass
    {
        PixelShader = compile ps_3_0 FogMist();
    }
}