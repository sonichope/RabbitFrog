// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/OutLine"
{
    Properties{
        _MainTex("Base (RGB)", 2D) = "white" {}
        _Color("Color", Color) = (1, 1, 1, 1) // outlineの色
        _Width("Width", float) = 0.1 // outlineの幅
    }
        SubShader{
            Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
            Cull Off
            Blend One OneMinusSrcAlpha

            Pass {

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex;

                struct v2f {
                    float4 pos : SV_POSITION;
                    half2 uv : TEXCOORD0;
                };

                v2f vert(appdata_base v) {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.texcoord;
                    return o;
                }

                fixed4 _Color;
                float4 _MainTex_TexelSize;
                float _Width;

                fixed4 frag(v2f i) : COLOR
                {
                    half4 c = tex2D(_MainTex, i.uv); // texture色を取得
                    c.rgb *= c.a; //色が付けないところを半透明化する。。
                    half4 outlineC = _Color; //outLineの色を決める
                    outlineC.a *= ceil(c.a);
                    outlineC.rgb *= outlineC.a; //

                    fixed alpha_up = tex2D(_MainTex, i.uv + fixed2(0, _MainTex_TexelSize.y * _Width)).a;
                    fixed alpha_down = tex2D(_MainTex, i.uv - fixed2(0, _MainTex_TexelSize.y * _Width)).a;
                    fixed alpha_right = tex2D(_MainTex, i.uv + fixed2(_MainTex_TexelSize.x * _Width, 0)).a;
                    fixed alpha_left = tex2D(_MainTex, i.uv - fixed2(_MainTex_TexelSize.x * _Width, 0)).a;

                    return lerp(outlineC, c, ceil(alpha_up * alpha_down * alpha_right * alpha_left));
                    //return ceil(alpha_up * alpha_down * alpha_right * alpha_left);
                    //return outlineC;
                }

                ENDCG
            }
        }
            FallBack "Diffuse"
}