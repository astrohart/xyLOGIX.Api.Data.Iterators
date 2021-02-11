using System;
using xyLOGIX.Data.Iterators.Exceptions;

namespace xyLOGIX.Data.Iterators.Events
{
   /// <summary>
   /// Defines the data that is passed by all events of type
   /// <see cref="T:xyLOGIX.Data.Iterators.Events.IterationErrorEventHandler" />.
   /// </summary>
   public class IterationErrorEventArgs : EventArgs
   {
      /// <summary>
      /// Creates a new instance of
      /// <see
      ///    cref="T:xyLOGIX.Data.Iterators.Events.IterationErrorEventArgs" />
      /// and
      /// returns a reference to it.
      /// </summary>
      /// <param name="exception">
      /// (Required.) A <see cref="T:xyLOGIX.Data.Iterators.Exceptions.IteratorException" /> that describes the error.
      /// </param>
      /// <exception cref="T:System.ArgumentNullException">
      /// Thrown if the required parameter, <paramref name="exception" />, is
      /// <c>null</c> .
      /// </exception>
      public IterationErrorEventArgs(IteratorException exception)
      {
         Exception = exception ??
                     throw new ArgumentNullException(nameof(exception));
      }

      /// <summary>
      /// Gets a reference to a <see cref="T:xyLOGIX.Data.Iterators.Exceptions.IteratorException" /> that contains
      /// the error information.
      /// </summary>
      public IteratorException Exception { get; }
   }
}