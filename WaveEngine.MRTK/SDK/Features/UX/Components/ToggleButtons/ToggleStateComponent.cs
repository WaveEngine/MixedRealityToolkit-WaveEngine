// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using WaveEngine.MRTK.SDK.Features.UX.Components.States;

namespace WaveEngine.MRTK.SDK.Features.UX.Components.ToggleButtons
{
    /// <summary>
    /// State component for toggle.
    /// </summary>
    public class ToggleStateComponent : BaseStateComponent
    {
        /// <inheritdoc />
        protected override List<State> GetStateList()
        {
            var states = new List<State>();
            states.Add(new State<ToggleState>
            {
                Name = ToggleState.Off.ToString(),
                Value = ToggleState.Off,
            });
            states.Add(new State<ToggleState>
            {
                Name = ToggleState.On.ToString(),
                Value = ToggleState.On,
            });

            return states;
        }
    }
}
