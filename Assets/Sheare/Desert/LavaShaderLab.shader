Shader "Custom/LavaShaderLab"
{
    Properties
    {
        _LavaTex ("Lava Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture", 2D) = "black" {}
        _Flow1 ("Flow 1", Vector) = (1, 0, 0, 0)
        _Flow2 ("Flow 2", Vector) = (-1, -1, 0, 0)
        _Pulse ("Pulse", Range(0, 5)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        CGPROGRAM
        #pragma surface surf Lambert
        
        struct Input
        {
            float2 uv_LavaTex;
            float2 uv_NoiseTex;
        };
        
        sampler2D _LavaTex;
        sampler2D _NoiseTex;
        float4 _Flow1;
        float4 _Flow2;
        float _Pulse;
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            // Base texture coordinates
            float2 lava_uv = IN.uv_LavaTex;
            float2 noise_uv = IN.uv_NoiseTex;
            
            // Apply flow over time
            lava_uv += _Flow1.xy * _Time.x;
            noise_uv += _Flow2.xy * _Time.x;
            
            // Sample noise texture
            fixed4 noise = tex2D(_NoiseTex, noise_uv);
            
            // Perturbation strength
            fixed2 perturb = noise.xy * 0.5 - 0.25;
            
            // Sample lava texture with perturbation
            fixed4 lavacol = tex2D(_LavaTex, lava_uv + perturb);
            
            // Pulse effect
            fixed pulse = noise.a;
            fixed4 temper = lavacol * pulse * _Pulse + (lavacol * lavacol - 0.1);
            
            // Exposure effects
            if (temper.r > 1.0)
            {
                temper.bg += clamp(temper.r - 2.0, 0.0, 5.0);
            }
            if (temper.g > 1.0)
            {
                temper.rb += temper.g - 1.0;
            }
            if (temper.b > 1.0)
            {
                temper.rg += temper.b - 1.0;
            }
            
            // Assign final color with alpha
            o.Albedo = temper.rgb;
            o.Alpha = 1.0;
        }
        ENDCG
    }
    Fallback "Diffuse"
}
