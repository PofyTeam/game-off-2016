Shader "PofyTools/Image Effects/Scanline" {
	
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_MaskTex("Mask texture", 2D) = "white" {}
		_maskBlend("Mask Blending", Range(0,1)) = 0.5
		_maskSize("Mask Size", Float) = 1
		
		_DisplacementTex("Displacement Texture", 2D) = "white"{}
		_Strength("Displacement Strength", Range(0,1)) = 0

		_glowBlend("Glow", Range(0,1)) = 0.0
	}
	SubShader{
		Pass{
			CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
				#include "UnityCG.cginc"

				uniform sampler2D _MainTex;
				uniform sampler2D _MaskTex;
				uniform sampler2D _DisplacementTex;
				fixed _maskBlend;
				fixed _maskSize;
				fixed _glowBlend;

				fixed _Strength;

				uniform fixed4 _MainTex_TexelSize;

				//float4 frag(v2f_img i) : COLOR{


				//	float4 c = tex2D(_MainTex, i.uv);
				//	return c;
				//}

				fixed4 frag(v2f_img i) : COLOR{
					
						half2 n = tex2D(_DisplacementTex, i.uv);
						//half2 n = i.uv;
						half2 d = n * 2 - 1;
						i.uv += d * _Strength;
						i.uv = saturate(i.uv);

					fixed4 c =0;

					fixed4 mask = lerp(fixed4(1,1,1,1),tex2D(_MaskTex, i.uv * _maskSize),_maskBlend);
					fixed4 base = tex2D(_MainTex, i.uv);
					//base += pow(base,1+_glowBlend);
					c = base * mask;

					fixed4 glow = tex2D(_MainTex, i.uv + float2(-_MainTex_TexelSize.x, -_MainTex_TexelSize.y)) + tex2D(_MainTex, i.uv + float2(0, -_MainTex_TexelSize.y)) + tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x, -_MainTex_TexelSize.y)) +
							tex2D(_MainTex, i.uv + float2(-_MainTex_TexelSize.x, 0)) + c + tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x, 0)) +
							tex2D(_MainTex, i.uv + float2(-_MainTex_TexelSize.x, _MainTex_TexelSize.y)) + tex2D(_MainTex, i.uv + float2(0, _MainTex_TexelSize.y)) + tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x, _MainTex_TexelSize.y));
						glow /= 9;
					
						//glow *= _glowBlend;
						glow = lerp(c, glow, _glowBlend);
						glow *= 0.5;
					return saturate(c*0.5 + glow);

					//return c;
				}

					/*fixed4 box(fixed4 color, sampler2D tex, float2 uv, float4 size) {
						fixed4 c = color;
						fixed4 glow = tex2D(tex, uv + float2(-size.x, -size.y)) + tex2D(tex, uv + float2(0, -size.y)) + tex2D(tex, uv + float2(size.x, -size.y)) +
							tex2D(tex, uv + float2(-size.x, 0)) + c + tex2D(tex, uv + float2(size.x, 0)) +
							tex2D(tex, uv + float2(-size.x, size.y)) + tex2D(tex, uv + float2(0, size.y)) + tex2D(tex, uv + float2(size.x, size.y));
						glow /= 9;
						return c+glow;
					}*/
			ENDCG
		}
	}
}
