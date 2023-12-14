using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using xyLOGIX.Api.Data.Iterators.Exceptions;

namespace xyLOGIX.Api.Data.Iterators.Events
{
    /// <summary> Provides information for IteratorError event handlers. </summary>
    [ExplicitlySynchronized]
    public class IteratorErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the
        /// <see cref="T:xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static IteratorErrorEventArgs() { }

        /// <summary>
        /// Creates a new instance of
        /// <see cref="T:xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs" /> and
        /// returns a reference to it.
        /// </summary>
        [Log(AttributeExclude = true)]
        public IteratorErrorEventArgs() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs" /> and
        /// returns a reference to it.
        /// </summary>
        /// <param name="exception">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException" /> that
        /// provides more information about the error.
        /// </param>
        [Log(AttributeExclude = true)]
        public IteratorErrorEventArgs(IteratorException exception)
            => Exception = exception;

        /// <summary>
        /// Gets a reference to the
        /// <see cref="T:xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException" /> that
        /// provides more information about the error.
        /// </summary>
        public IteratorException Exception { get; set; }
    }
}