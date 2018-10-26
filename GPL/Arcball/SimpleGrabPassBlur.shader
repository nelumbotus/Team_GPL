// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SimpleGrabPassBlur" {
	Properties {
		_Size ("size of blur", Range(0,10)) = 1.0
	}
    SubShader
    {
        // Draw ourselves after all opaque geometry
        Tags { "Queue" = "Transparent" }

        // Grab the screen behind the object into _BackgroundTexture
        GrabPass
        {
            "_BackgroundTexture"
        }

        // Render the object with the texture generated above, and invert the colors
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f
            {
                float4 grabPos : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            v2f vert(appdata_base v) {
                v2f o;
                // use UnityObjectToClipPos from UnityCG.cginc to calculate 
                // the clip-space of the vertex
                o.pos = UnityObjectToClipPos(v.vertex);
                // use ComputeGrabScreenPos function from UnityCG.cginc
                // to get the correct texture coordinate
                o.grabPos = ComputeGrabScreenPos(o.pos);
                return o;
            }

            sampler2D _BackgroundTexture;
            float4 _BackgroundTexture_TexelSize;
			half _Size;

            half4 frag(v2f i) : SV_Target
            {
			
                half4 center = tex2Dproj(_BackgroundTexture, float4(i.grabPos.x, i.grabPos.y, i.grabPos.z, i.grabPos.w));
				half4 u = tex2Dproj(_BackgroundTexture, float4(i.grabPos.x, i.grabPos.y + _BackgroundTexture_TexelSize.y * _Size, i.grabPos.z, i.grabPos.w));
				half4 l = tex2Dproj(_BackgroundTexture, float4(i.grabPos.x - _BackgroundTexture_TexelSize.x * _Size, i.grabPos.y, i.grabPos.z, i.grabPos.w));
				half4 r = tex2Dproj(_BackgroundTexture, float4(i.grabPos.x + _BackgroundTexture_TexelSize.x * _Size, i.grabPos.y, i.grabPos.z, i.grabPos.w));
				half4 d = tex2Dproj(_BackgroundTexture, float4(i.grabPos.x, i.grabPos.y - _BackgroundTexture_TexelSize.y * _Size, i.grabPos.z, i.grabPos.w));

				half4 ul = tex2Dproj(_BackgroundTexture, float4(i.grabPos.x - _BackgroundTexture_TexelSize.x * _Size, i.grabPos.y - _BackgroundTexture_TexelSize.y * _Size, i.grabPos.z, i.grabPos.w));
				half4 ur = tex2Dproj(_BackgroundTexture, float4(i.grabPos.x + _BackgroundTexture_TexelSize.x * _Size, i.grabPos.y - _BackgroundTexture_TexelSize.y * _Size, i.grabPos.z, i.grabPos.w));
				half4 dl = tex2Dproj(_BackgroundTexture, float4(i.grabPos.x - _BackgroundTexture_TexelSize.x * _Size, i.grabPos.y + _BackgroundTexture_TexelSize.y * _Size, i.grabPos.z, i.grabPos.w));
				half4 dr = tex2Dproj(_BackgroundTexture, float4(i.grabPos.x + _BackgroundTexture_TexelSize.x * _Size, i.grabPos.y + _BackgroundTexture_TexelSize.y * _Size, i.grabPos.z, i.grabPos.w));
				half gaussian1 = 1.0f/16.0f;
				half gaussian2 = 2.0f/16.0f;
				half gaussian4 = 4.0f/16.0f;
				half4 sub = (center*gaussian4 + u*gaussian2 + l*gaussian2 + r*gaussian2 + d*gaussian2 + ul*gaussian1 + ur*gaussian1 + dl*gaussian1 + dr*gaussian1);
                return sub;
            }
            ENDCG
        }

    }
}