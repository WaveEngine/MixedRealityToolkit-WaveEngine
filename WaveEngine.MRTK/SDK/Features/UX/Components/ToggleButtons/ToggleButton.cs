// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using System;
using System.Linq;
using WaveEngine.Framework;
using WaveEngine.MRTK.SDK.Features.UX.Components.States;

namespace WaveEngine.MRTK.SDK.Features.UX.Components.ToggleButtons
{
    /// <summary>
    /// Toggle button component.
    /// </summary>
    public class ToggleButton : Component
    {
        private ToggleStateComponent toggleStateComponent;

        /// <summary>
        /// Raised when toggle status changes.
        /// </summary>
        public event EventHandler Toggled;

        /// <summary>
        /// Gets a value indicating whether button is on or not.
        /// </summary>
        public bool IsOn { get => this.IsOnState(); }

        /// <inheritdoc />
        protected override bool OnAttached()
        {
            bool attached = base.OnAttached();
            if (attached)
            {
                this.AddComponents();
                this.SubscribeEvents();
            }

            return attached;
        }

        /// <inheritdoc />
        protected override void Start()
        {
            base.Start();
            this.OnStateChanged(this.toggleStateComponent.CurrentState as State<ToggleState>);
        }

        /// <inheritdoc />
        protected override void OnDetach()
        {
            base.OnDetach();
            this.UnsubscribeEvents();
        }

        private void AddComponents()
        {
            this.toggleStateComponent = this.Owner.FindComponent<ToggleStateComponent>();
            if (this.toggleStateComponent == null)
            {
                this.toggleStateComponent = new ToggleStateComponent();
                this.Owner.AddComponent(this.toggleStateComponent);
                this.Owner.AddComponent(new ToggleStateConfigurator() { Target = ToggleState.Off });
                this.Owner.AddComponent(new ToggleStateConfigurator() { Target = ToggleState.On });
            }
        }

        private bool IsOnState()
        {
            var toggleState = this.GetToggleState();
            return toggleState?.Value == ToggleState.On;
        }

        private void OnStateChanged(State<ToggleState> newState)
        {
            var allConfigurators = this.Owner.FindComponents<ToggleStateConfigurator>(isExactType: false);
            for (int i = 0; i < allConfigurators.Count(); i++)
            {
                var current = allConfigurators.ElementAt(i);
                current.IsEnabled = current.Target == newState.Value;
            }
        }

        private void SubscribeEvents()
        {
            if (this.toggleStateComponent != null)
            {
                this.toggleStateComponent.StateChanged += this.ToggleStateComponent_StateChanged;
            }
        }

        private void UnsubscribeEvents()
        {
            if (this.toggleStateComponent != null)
            {
                this.toggleStateComponent.StateChanged -= this.ToggleStateComponent_StateChanged;
            }
        }

        private void ToggleStateComponent_StateChanged(object sender, StateChangedEventArgs e)
        {
            this.OnStateChanged(e.NewState as State<ToggleState>);
            this.Toggled?.Invoke(this, EventArgs.Empty);
        }

        private State<ToggleState> GetToggleState() => this.toggleStateComponent?.CurrentState as State<ToggleState>;
    }
}
