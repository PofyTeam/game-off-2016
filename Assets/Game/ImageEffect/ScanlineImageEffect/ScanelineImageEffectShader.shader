Shader "PofyTools/Image Effects/Scanline" {
	
	Properties{
		[HideInInspector]
		_MainTex("Base (RGB)", 2D) = "white" {}

		//Scanline
		_MaskTex("Scanline Texture", 2D) = "white" {}
		_maskBlend("Scanline Blend", Range(0,1)) = 0.5
		_maskSize("Scanline Size", Float) = 1
		
		//Screen Vignette
		_VignetteTex("Vignette Texture",2D) = "white" {}
		_vignetteBlend("Vignette Blend", Range(0,1)) = 0.0
		//Glow blend
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
				uniform sampler2D _VignetteTex;

				fixed _maskBlend;
				fixed _maskSize;
				fixed _vignetteBlend;
				fixed _glowBlend;

				uniform fixed4 _MainTex_TexelSize;


				fixed4 frag(v2f_img i) : COLOR{

					fixed4 c =0;

					fixed4 base = tex2D(_MainTex, i.uv);
					
					fixed4 vignette = tex2D(_VignetteTex, i.uv);
					vignette = lerp(fixed4(1, 1, 1, 1),pow(vignette,1 + _vignetteBlend), _vignetteBlend);

					fixed4 mask = tex2D(_MaskTex, i.uv * _maskSize);
					mask = lerp(fixed4(1, 1, 1, 1), mask, _maskBlend);

					c = base * mask;

					fixed4 glow = tex2D(_MainTex, i.uv + float2(-_MainTex_TexelSize.x, -_MainTex_TexelSize.y)) + tex2D(_MainTex, i.uv + float2(0, -_MainTex_TexelSize.y)) + tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x, -_MainTex_TexelSize.y)) +
							tex2D(_MainTex, i.uv + float2(-_MainTex_TexelSize.x, 0)) + c + tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x, 0)) +
							tex2D(_MainTex, i.uv + float2(-_MainTex_TexelSize.x, _MainTex_TexelSize.y)) + tex2D(_MainTex, i.uv + float2(0, _MainTex_TexelSize.y)) + tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x, _MainTex_TexelSize.y));
						glow /= 9;

						glow = lerp(c, glow, _glowBlend);
						//glow *= 0.5;
						return saturate((c + glow)*0.5)*vignette;
				}
			ENDCG
		}
	}
}
