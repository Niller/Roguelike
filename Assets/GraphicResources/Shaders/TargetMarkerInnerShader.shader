Shader "Unlit/TargetMarkerShaderInner"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
		_Border ("Border", int) = 4
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 100
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
				float custom : float;
                float4 vertex : SV_POSITION;
            };

            float4 _Color;
			int _Border;

            v2f vert (appdata v)
            {
                v2f o;
				o.custom = distance(float2(0, 0), v.vertex.xz);
                o.vertex = UnityObjectToClipPos(v.vertex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _Color;
				col.a = pow(i.custom.x + 0.05, _Border);
                return col;
            }
            ENDCG
        }
    }
}
