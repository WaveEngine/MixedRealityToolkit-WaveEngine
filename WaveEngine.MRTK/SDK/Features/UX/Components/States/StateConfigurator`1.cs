// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using WaveEngine.Framework;
using WaveEngine.MRTK.SDK.Features.UX.Components.PressableButtons;

namespace WaveEngine.MRTK.SDK.Features.UX.Components.States
{
    /// <summary>
    /// Configuration for toggle button in a given state.
    /// </summary>
    /// <typeparam name="TState">Configuration state type.</typeparam>
    [AllowMultipleInstances]
    public class StateConfigurator<TState> : PressableButtonConfigurator
    {
        /// <summary>
        /// Gets or sets target state.
        /// </summary>
        public TState TargetState { get; set; }
    }
}
