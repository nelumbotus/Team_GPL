Shader "Unlit/CandleShader"
{
	Properties
	{
        _Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha 
		
        Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"
            
            
            float3 mod289(float3 x)
            {
                return x - floor(x / 289.0) * 289.0;
            }

            float2 mod289(float2 x)
            {
                return x - floor(x / 289.0) * 289.0;
            }

            float3 permute(float3 x)
            {
                return mod289((x * 34.0 + 1.0) * x);
            }

            float3 taylorInvSqrt(float3 r)
            {
                return 1.79284291400159 - 0.85373472095314 * r;
            }

            float snoise(float2 v)
            {
                const float4 C = float4( 0.211324865405187,  // (3.0-sqrt(3.0))/6.0
                                         0.366025403784439,  // 0.5*(sqrt(3.0)-1.0)
                                        -0.577350269189626,  // -1.0 + 2.0 * C.x
                                         0.024390243902439); // 1.0 / 41.0
                // First corner
                float2 i  = floor(v + dot(v, C.yy));
                float2 x0 = v -   i + dot(i, C.xx);

                // Other corners
                float2 i1;
                i1.x = step(x0.y, x0.x);
                i1.y = 1.0 - i1.x;

                // x1 = x0 - i1  + 1.0 * C.xx;
                // x2 = x0 - 1.0 + 2.0 * C.xx;
                float2 x1 = x0 + C.xx - i1;
                float2 x2 = x0 + C.zz;

                // Permutations
                i = mod289(i); // Avoid truncation effects in permutation
                float3 p =
                  permute(permute(i.y + float3(0.0, i1.y, 1.0))
                                + i.x + float3(0.0, i1.x, 1.0));

                float3 m = max(0.5 - float3(dot(x0, x0), dot(x1, x1), dot(x2, x2)), 0.0);
                m = m * m;
                m = m * m;

                // Gradients: 41 points uniformly over a line, mapped onto a diamond.
                // The ring size 17*17 = 289 is close to a multiple of 41 (41*7 = 287)
                float3 x = 2.0 * frac(p * C.www) - 1.0;
                float3 h = abs(x) - 0.5;
                float3 ox = floor(x + 0.5);
                float3 a0 = x - ox;

                // Normalise gradients implicitly by scaling m
                m *= taylorInvSqrt(a0 * a0 + h * h);

                // Compute final noise value at P
                float3 g;
                g.x = a0.x * x0.x + h.x * x0.y;
                g.y = a0.y * x1.x + h.y * x1.y;
                g.z = a0.z * x2.x + h.z * x2.y;
                return 130.0 * dot(m, g);
            }


			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
            float4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				//UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
                float noise1 = tex2D(_MainTex, float2(i.uv.x * 0.5f, i.uv.y * 0.5f + _Time.y * 2.0f)).x;
                float noise2 = tex2D(_MainTex, float2(i.uv.x * 0.5f, i.uv.y * 0.5f + _Time.y * 2.0f)).y;
                float fireBase = tex2D(_MainTex, float2(i.uv.x, i.uv.y - 0.01f)).z;
                
                float fire = abs(noise1 + noise2 * 0.05f);
                float3 finalCol = (_Color.xyz + float3(fire,fire,fire)) * fireBase;
				// apply fog
				//UNITY_APPLY_FOG(i.fogCoord, col);
				return float4(finalCol * 2.0f, fireBase);
			}
			ENDCG
		}
	}
}
