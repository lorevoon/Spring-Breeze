using System;
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// Disposable that calls events at the start and end of its lifetime.
    /// </summary>
    public class EventStartEndDisposable : IDisposable
    {
        private readonly Action end;

        /// <summary>
        /// Calls two action at the start and the end of its lifetime
        /// </summary>
        /// <param name="start">Action to call when instanced</param>
        /// <param name="end">Action to call when disposed</param>
        public EventStartEndDisposable(System.Action start, System.Action end)
        {
            start?.Invoke();
            this.end = end;
        }

        public void Dispose()
        {
            end?.Invoke();
        }
    }
}
