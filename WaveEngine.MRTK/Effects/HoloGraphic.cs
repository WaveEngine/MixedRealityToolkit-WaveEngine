//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WaveEngine.MRTK.Effects
{
    using WaveEngine.Common.Graphics;
    using WaveEngine.Framework.Graphics;
    using WaveEngine.Framework.Graphics.Effects;
    using WaveEngine.Mathematics;
    
    
    [WaveEngine.Framework.Graphics.MaterialDecoratorAttribute("4f7e4c24-e83c-4350-9cd4-511fb2199cf4")]
    public partial class HoloGraphic : WaveEngine.Framework.Graphics.MaterialDecorator
    {
        
        public HoloGraphic(WaveEngine.Framework.Graphics.Effects.Effect effect) : 
                base(new Material(effect))
        {
        }
        
        public HoloGraphic(WaveEngine.Framework.Graphics.Material material) : 
                base(material)
        {
        }
        
        public WaveEngine.Mathematics.Matrix4x4 PerDrawCall_WorldViewProj
        {
            get
            {
                return this.material.CBuffers[0].GetBufferData<WaveEngine.Mathematics.Matrix4x4>(0);
            }
            set
            {
				this.material.CBuffers[0].SetBufferData(value, 0);
            }
        }
        
        public WaveEngine.Mathematics.Matrix4x4 PerDrawCall_World
        {
            get
            {
                return this.material.CBuffers[0].GetBufferData<WaveEngine.Mathematics.Matrix4x4>(64);
            }
            set
            {
				this.material.CBuffers[0].SetBufferData(value, 64);
            }
        }
        
        public WaveEngine.Mathematics.Vector3 Parameters_Color
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector3>(0);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 0);
            }
        }
        
        public float Parameters_Alpha
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(12);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 12);
            }
        }
        
        public WaveEngine.Mathematics.Vector3 Parameters_InnerGlowColor
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector3>(16);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 16);
            }
        }
        
        public float Parameters_InnerGlowAlpha
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(28);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 28);
            }
        }
        
        public float Parameters_InnerGlowPower
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(32);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 32);
            }
        }
        
        public float Parameters_BorderWidth
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(36);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 36);
            }
        }
        
        public float Parameters_BorderMinValue
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(40);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 40);
            }
        }
        
        public float Parameters_FluentLightIntensity
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(44);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 44);
            }
        }
        
        public float Parameters_RoundCornerRadious
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(48);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 48);
            }
        }
        
        public float Parameters_RoundCornerMargin
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(52);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 52);
            }
        }
        
        public float Parameters_Cutoff
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(56);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 56);
            }
        }
        
        public float Parameters_EdgeSmoothingValue
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(60);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 60);
            }
        }
        
        public float Parameters_FadeBeginDistance
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(64);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 64);
            }
        }
        
        public float Parameters_FadeCompleteDistance
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(68);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 68);
            }
        }
        
        public float Parameters_FadeMinValue
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(72);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 72);
            }
        }
        
        public WaveEngine.Mathematics.Vector3 Parameters_HoverColorOverride
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector3>(80);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 80);
            }
        }
        
        public WaveEngine.Mathematics.Vector4 Parameters_ProximityLightCenterColorOverride
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector4>(96);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 96);
            }
        }
        
        public WaveEngine.Mathematics.Vector4 Parameters_ProximityLightMiddleColorOverride
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector4>(112);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 112);
            }
        }
        
        public WaveEngine.Mathematics.Vector4 Parameters_ProximityLightOuterColorOverride
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector4>(128);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 128);
            }
        }
        
        public WaveEngine.Mathematics.Vector4 Parameters_LightColor0
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector4>(144);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 144);
            }
        }
        
        public float Parameters_Metallic
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(160);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 160);
            }
        }
        
        public float Parameters_Smoothness
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<System.Single>(164);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 164);
            }
        }
        
        public WaveEngine.Mathematics.Vector2 Parameters_Tiling
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector2>(176);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 176);
            }
        }
        
        public WaveEngine.Mathematics.Vector2 Parameters_Offset
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector2>(184);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 184);
            }
        }
        
        public WaveEngine.Mathematics.Vector4 Parameters_HoverLightData
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector4>(320);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 320);
            }
        }
        
        public WaveEngine.Mathematics.Vector4 Parameters_ProximityLightData
        {
            get
            {
                return this.material.CBuffers[1].GetBufferData<WaveEngine.Mathematics.Vector4>(416);
            }
            set
            {
				this.material.CBuffers[1].SetBufferData(value, 416);
            }
        }
        
        public WaveEngine.Mathematics.Matrix4x4 PerCamera_MultiviewViewProj
        {
            get
            {
                return this.material.CBuffers[2].GetBufferData<WaveEngine.Mathematics.Matrix4x4>(0);
            }
            set
            {
				this.material.CBuffers[2].SetBufferData(value, 0);
            }
        }
        
        public int PerCamera_EyeCount
        {
            get
            {
                return this.material.CBuffers[2].GetBufferData<System.Int32>(160);
            }
            set
            {
				this.material.CBuffers[2].SetBufferData(value, 160);
            }
        }
        
        public WaveEngine.Common.Graphics.Texture Texture
        {
            get
            {
                return this.material.TextureSlots[0].Texture;
            }
            set
            {
				this.material.SetTexture(value, 0);
            }
        }
        
        public WaveEngine.Common.Graphics.SamplerState Sampler
        {
            get
            {
                return this.material.SamplerSlots[0].Sampler;
            }
            set
            {
				this.material.SetSampler(value, 0);
            }
        }
    }
}
