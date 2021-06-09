// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using WaveEngine.Framework;
using WaveEngine.MRTK.SDK.Features.UX.Components.PressableButtons;

namespace WaveEngine.MRTK.SDK.Features.UX.Components.ToggleButtons
{
    /// <summary>
    /// Configuration for toggle button in a given state.
    /// </summary>
    [AllowMultipleInstances]
    public class ToggleStateConfigurator : PressableButtonConfigurator
    {
        /// <summary>
        /// Gets or sets target state.
        /// </summary>
        public ToggleState Target { get; set; }
    }
}
