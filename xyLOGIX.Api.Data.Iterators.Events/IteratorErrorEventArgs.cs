using System;
using xyLOGIX.Api.Data.Iterators.Exceptions;

namespace xyLOGIX.Api.Data.Iterators.Events
{
    /// <summary>
    /// Provides information for IteratorError event handlers.
    /// </summary>
    public class IteratorErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new instance of <see
        /// cref="T:xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs"/>
        /// and returns a reference to it.
        /// </summary>
        /// <param name="exception">
        /// (Required.) A <see
        /// cref="T:xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException"/>
        /// that provides more information about the error.
        /// </param>
        public IteratorErrorEventArgs(IteratorException exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets a reference to the <see
        /// cref="T:xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException"/>
        /// that provides more information about the error.
        /// </summary>
        public IteratorException Exception { get; set; }
    }
}