// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.Linq;
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
                this.AddDefaultComponents();
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

        private void AddDefaultComponents()
        {
            var allConfigurations = this.Owner.FindComponents<ToggleButtonConfigurator>();
            if (!allConfigurations.Any())
            {
                return;
            }

            var allStates = Enum.GetValues(typeof(ToggleState))
                .Cast<ToggleState>()
                .ToArray();

            for (int i = 0; i < allStates.Length; i++)
            {
                var state = allStates[i];
                if (!allConfigurations.Any(config => config.TargetState == state))
                {
                    this.Owner.AddComponent(new ToggleButtonConfigurator() { TargetState = state });
                }
            }
        }
    }
}
