Shader "Custom/WaterShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Color ("Color", Color) = (0.0, 0.5, 0.7, 0.5)
        _WaveSpeed ("Wave Speed", Range(0.0, 5.0)) = 0.1
        _WaveScale ("Wave Scale", Range(0.0, 0.5)) = 0.1
        _WaveStrength ("Wave Strength", Range(0.0, 1.0)) = 0.1
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            sampler2D _NormalMap;
            float4 _Color;
            float _WaveSpeed;
            float _WaveScale;
            float _WaveStrength;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Calculate wave offset
                float wave = sin(i.worldPos.x * _WaveScale + _Time.y * _WaveSpeed) * _WaveStrength;
                float2 uv = i.uv + wave;

                // Sample the texture
                fixed4 col = tex2D(_MainTex, uv) * _Color;

                // Sample the normal map for reflection/distortion
                fixed4 normal = tex2D(_NormalMap, uv);
                col.rgb += normal.rgb * 0.1;

                // Apply alpha for transparency
                col.a *= _Color.a;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Transparent/Cutout/VertexLit"
}
