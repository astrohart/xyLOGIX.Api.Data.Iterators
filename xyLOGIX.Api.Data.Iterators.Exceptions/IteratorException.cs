using System;

namespace xyLOGIX.Api.Data.Iterators.Exceptions
{
   /// <summary>
   /// Represents an exception thrown by an iterator object.
   /// </summary>
   public class IteratorException : Exception
   {
      /// <summary>
      /// Constructs a new instance of
      /// <see
      ///    cref="T:xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException" />
      /// and
      /// returns a reference to it.
      /// </summary>
      /// <param name="message">
      /// The error message that explains the reason for the exception.
      /// </param>
      /// <param name="innerException">
      /// The exception that is the cause of the current exception, or a null
      /// reference ( <see langword="Nothing" /> in Visual Basic) if no inner
      /// exception is specified.
      /// </param>
      public IteratorException(string message, Exception innerException) : base(
         message, innerException
      ) { }

      /// <summary>
      /// Constructs a new instance of
      /// <see
      ///    cref="T:xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException" />
      /// and
      /// returns a reference to it.
      /// </summary>
      /// <param name="message">
      /// The error message that explains the reason for the exception.
      /// </param>
      public IteratorException(string message) : base(message) { }
   }
}