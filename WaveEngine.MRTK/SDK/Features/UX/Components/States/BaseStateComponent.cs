// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.Linq;
using WaveEngine.Framework;
using WaveEngine.MRTK.SDK.Features.UX.Components.PressableButtons;

namespace WaveEngine.MRTK.SDK.Features.UX.Components.States
{
    /// <summary>
    /// Handles states on a component.
    /// </summary>
    public abstract class BaseStateComponent : Component
    {
        [BindComponent(source: BindComponentSource.ChildrenSkipOwner, isRequired: true)]
        private PressableButton button = null;

        private State currentState;
        private List<State> allStates;

        /// <summary>
        /// Gets current state.
        /// </summary>
        public State CurrentState { get => this.currentState; }

        /// <summary>
        /// Raised when state changes.
        /// </summary>
        public event EventHandler<StateChangedEventArgs> StateChanged;

        /// <inheritdoc />
        protected override bool OnAttached()
        {
            bool attached = base.OnAttached();
            if (attached)
            {
                this.button.ButtonPressed += this.Button_ButtonPressed;
                this.allStates = this.GetStateList();
                this.currentState = this.allStates.FirstOrDefault();
            }

            return attached;
        }

        /// <inheritdoc />
        protected override void OnDetach()
        {
            base.OnDetach();
            this.button.ButtonPressed -= this.Button_ButtonPressed;
        }

        /// <summary>
        /// Child classes should load here the list of states.
        /// </summary>
        /// <returns>List of states to handle.</returns>
        protected abstract List<State> GetStateList();

        /// <summary>
        /// Retrieves next state once user presses the button.
        /// </summary>
        /// <returns>Next state.</returns>
        protected virtual State GetNextState()
        {
            return this.currentState == null
                ? this.allStates.FirstOrDefault()
                : this.allStates[(this.allStates.IndexOf(this.currentState) + 1) % this.allStates.Count];
        }

        private void Button_ButtonPressed(object sender, EventArgs e)
        {
            var newState = this.GetNextState();
            if (newState != this.currentState)
            {
                var oldState = this.currentState;
                this.currentState = newState;
                this.StateChanged?.Invoke(this, new StateChangedEventArgs(oldState, newState));
            }
        }
    }
}
