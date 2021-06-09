// Copyright © Wave Engine S.L. All rights reserved. Use is subject to license terms.

namespace WaveEngine.MRTK.SDK.Features.UX.Components.States
{
    /// <summary>
    /// UI element state model.
    /// </summary>
    /// <typeparam name="T">Value type.</typeparam>
    public class State<T> : State
    {
        /// <summary>
        /// Gets or sets value.
        /// </summary>
        public T Value { get; set; }
    }
}
