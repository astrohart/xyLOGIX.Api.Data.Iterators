using System;
using System.Collections.Generic;
using System.Linq;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Data.Iterators.Interfaces
{
   /// <summary>
   /// Implements the
   /// <see
   ///    cref="T:xyLOGIX.Data.Iterators.Interfaces.IIterator" />
   /// interface for all
   /// objects that provide differing behaviors of the iteration process.
   /// </summary>
   /// <typeparam name="T">
   /// </typeparam>
   public abstract class IteratorBase<T> : IIterator<T> where T : class
   {
      /// <summary>
      /// Occurs when the end of the collection has been reached.
      /// </summary>
      public abstract event EventHandler LastItemReached;

      /// <summary>
      /// Occurs when no items have been found in the underlying collection.
      /// </summary>
      public abstract event EventHandler NoItemsFound;

      /// <summary>
      /// Gets the entire collection and returns an enumerator to be used to
      /// iterate over it.
      /// </summary>
      /// <returns>
      /// Reference to an instance of a collection object that implements the
      /// <see cref="T:System.Collections.Generic.IEnumerable{T}" /> interface.
      /// This contains all the elements of the entire data set.
      /// </returns>
      /// <remarks>
      /// Implementations should generally call the
      /// <see
      ///    cref="M:xyLOGIX.Data.Iterators.Interfaces.IIterator.GetNext" />
      /// and
      /// <see cref="M:xyLOGIX.Data.Iterators.Interfaces.IIterator.HasNext" />
      /// methods in order to obtain all the elements.
      /// </remarks>
      public IEnumerable<T> GetAll()
      {
         IEnumerable<T> result;
         
         try
         {
            var items = new List<T>();

            while (HasNext()) 
               items.Add(GetNext());

            result = items;
         }
         catch (Exception ex)
         {
            // dump all the exception info to the log
            DebugUtils.LogException(ex);

            result = Enumerable.Empty<T>();
         }

         return result;
      }

      /// <summary>
      /// Returns a reference to an instance of <typeparamref name="T" /> that is
      /// the current item in the data set that the iterator is now pointing to.
      /// </summary>
      /// <typeparam name="T">
      /// Name of the class that represents a single element of the data set.
      /// </typeparam>
      /// <returns>
      /// Reference to the instance of <typeparamref name="T" /> that represents
      /// the current element in the iteration, or <c>null</c> if the end of the
      /// collection has been passed.
      /// </returns>
      /// <remarks>
      /// This method returns a reference to the current element of the data
      /// set. When called, this method will automatically advance the
      /// current-item pointer to the next element in the list.
      /// <para />
      /// NOTE: Even if
      /// <see cref="M:xyLOGIX.Data.Iterators.Interfaces.IIterator.HasNext" />
      /// returns <c>false</c>, this method will still return a non- <c>null</c> value.
      /// </remarks>
      public abstract T GetNext();

      /// <summary>
      /// Determines whether the collection has more items.
      /// </summary>
      /// <returns>
      /// <c>True</c> if the collection has more items; <c>false</c> otherwise.
      /// </returns>
      public abstract bool HasNext();
   }
}