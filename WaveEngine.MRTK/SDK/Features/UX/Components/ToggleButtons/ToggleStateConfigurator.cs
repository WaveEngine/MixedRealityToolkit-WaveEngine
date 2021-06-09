// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using WaveEngine.MRTK.SDK.Features.UX.Components.PressableButtons;

namespace WaveEngine.MRTK.SDK.Features.UX.Components.ToggleButtons
{
    /// <summary>
    /// Configuration for toggle button in a given state.
    /// </summary>
    public abstract class ToggleStateConfigurator : PressableButtonConfigurator
    {
        /// <summary>
        /// Gets target state.
        /// </summary>
        public abstract ToggleState Target { get; }
    }
}
