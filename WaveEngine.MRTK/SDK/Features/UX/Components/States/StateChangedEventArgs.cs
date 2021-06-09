// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

using System;

namespace WaveEngine.MRTK.SDK.Features.UX.Components.States
{
    /// <summary>
    /// Event args for state changes in a button.
    /// </summary>
    public class StateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateChangedEventArgs"/> class.
        /// </summary>
        public StateChangedEventArgs()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateChangedEventArgs"/> class.
        /// </summary>
        /// <param name="oldState">Old state instance.</param>
        /// <param name="newState">New state instance.</param>
        public StateChangedEventArgs(State oldState, State newState)
        {
            this.OldState = oldState;
            this.NewState = newState;
        }

        /// <summary>
        /// Gets or sets old state instance.
        /// </summary>
        public State OldState { get; set; }

        /// <summary>
        /// Gets or sets new state instance.
        /// </summary>
        public State NewState { get; set; }
    }
}
