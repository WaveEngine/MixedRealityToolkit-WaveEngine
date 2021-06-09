// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.
using WaveEngine.Common.Graphics;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.MRTK.Effects;
using WaveEngine.MRTK.Extensions;

namespace WaveEngine.MRTK.SDK.Features.UX.Components.PressableButtons
{
    /// <summary>
    /// Configures some UI elements for an entity that uses <see cref="PressableButton"/>.
    /// </summary>
    public class PressableButtonConfigurator : Component
    {
        [BindComponent(source: BindComponentSource.ChildrenSkipOwner, tag: "backPlate", isRequired: true)]
        private MaterialComponent backPlateMaterial = null;

        [BindComponent(source: BindComponentSource.ChildrenSkipOwner, tag: "icon", isRequired: true)]
        private MaterialComponent iconMaterial = null;

        private Material backPlate;
        private Material icon;
        private HoloGraphic backPlateHoloMaterial;
        private HoloGraphic iconHoloMaterial;
        private Color primaryColor = Color.White;

        /// <summary>
        /// Gets or sets back plate material.
        /// </summary>
        public Material BackPlate
        {
            get => this.backPlate;

            set
            {
                if (this.backPlate != value)
                {
                    this.backPlate = value;
                    this.OnBackPlateUpdate();
                }
            }
        }

        /// <summary>
        /// Gets or sets button icon.
        /// </summary>
        public Material Icon
        {
            get => this.icon;

            set
            {
                if (this.icon != value)
                {
                    this.icon = value;
                    this.OnIconUpdate();
                }
            }
        }

        /// <summary>
        /// Gets or sets button primary color. This color is used to tint icon and set
        /// text color.
        /// </summary>
        public Color PrimaryColor
        {
            get => this.primaryColor;
            set
            {
                if (this.primaryColor != value)
                {
                    this.primaryColor = value;
                    this.OnPrimaryColorUpdate();
                }
            }
        }

        /// <inheritdoc />
        protected override bool OnAttached()
        {
            bool attached = base.OnAttached();
            if (attached)
            {
                this.OnBackPlateUpdate();
                this.OnIconUpdate();
            }

            return attached;
        }

        private void OnBackPlateUpdate()
        {
            if (this.backPlate != null && this.backPlateMaterial != null)
            {
                var newMaterialInstance = this.backPlate.LoadNewInstance(this.Managers.AssetSceneManager);
                this.backPlateMaterial.Material = newMaterialInstance;
                this.backPlateHoloMaterial = new HoloGraphic(newMaterialInstance);
            }
        }

        private void OnIconUpdate()
        {
            if (this.icon != null && this.iconMaterial != null)
            {
                var newMaterialInstance = this.icon.LoadNewInstance(this.Managers.AssetSceneManager);
                this.iconMaterial.Material = newMaterialInstance;
                this.iconHoloMaterial = new HoloGraphic(newMaterialInstance);
                this.UpdateIconTint();
            }
        }

        private void OnPrimaryColorUpdate()
        {
            this.UpdateIconTint();
        }

        private void UpdateIconTint()
        {
            if (this.iconHoloMaterial != null)
            {
                this.iconHoloMaterial.Albedo = this.primaryColor;
            }
        }
    }
}
