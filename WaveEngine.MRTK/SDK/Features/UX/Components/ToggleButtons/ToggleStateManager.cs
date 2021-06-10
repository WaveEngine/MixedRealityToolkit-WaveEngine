// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using System.Collections.Generic;
using WaveEngine.MRTK.SDK.Features.UX.Components.States;

namespace WaveEngine.MRTK.SDK.Features.UX.Components.ToggleButtons
{
    /// <summary>
    /// State component for toggle.
    /// </summary>
    public class ToggleStateManager : BaseStateManager<ToggleState>
    {
        /// <inheritdoc />
        protected override bool OnAttached()
        {
            bool attached = base.OnAttached();
            if (attached)
            {
                this.Owner.AddComponent(new ToggleButtonConfigurator() { TargetState = ToggleState.Off });
                this.Owner.AddComponent(new ToggleButtonConfigurator() { TargetState = ToggleState.On });
            }

            return attached;
        }

        /// <inheritdoc />
        protected override List<State<ToggleState>> GetStateList()
        {
            var states = new List<State<ToggleState>>();
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
