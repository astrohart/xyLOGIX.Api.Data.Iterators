using System;
using System.Collections.Generic;
using xyLOGIX.Api.Data.Iterators.Events;

namespace xyLOGIX.Api.Data.Iterators.Interfaces
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of an object that
    /// iterates over a data set whose total number of items is not known in
    /// advance. Each data item is referenced as an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">
    /// Name of a class that represents a single element of the collection.
    /// </typeparam>
    public interface IIterator<T> : IEnumerator<T> where T : class
    {
        /// <summary>
        /// Occurs when an exception is thrown during the iteration process.
        /// </summary>
        event IteratorErrorEventHandler IteratorError;

        /// <summary>
        /// Occurs when the end of the collection has been reached.
        /// </summary>
        event EventHandler LastItemReached;

        /// <summary>
        /// Occurs when no items have been found in the underlying collection.
        /// </summary>
        event EventHandler NoItemsFound;

        /// <summary>
        /// Gets the number of elements to be retrieved each time that we
        /// advance to another page.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Gets the entire collection and returns an enumerator to be used to
        /// iterate over it.
        /// </summary>
        /// <returns>
        /// Reference to an instance of a collection object that implements the
        /// <see cref="T:System.Collections.Generic.IEnumerable{T}"/> interface.
        /// This contains all the elements of the entire data set.
        /// </returns>
        /// <remarks>
        /// Implementations should generally call the <see
        /// cref="M:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.GetNext"/>
        /// and <see
        /// cref="M:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext"/>
        /// methods in order to obtain all the elements.
        /// </remarks>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Returns a reference to an instance of <typeparamref name="T"/> that
        /// is the current item in the data set that the iterator is now
        /// pointing to.
        /// </summary>
        /// <typeparam name="T">
        /// Name of the class that represents a single element of the data set.
        /// </typeparam>
        /// <returns>
        /// Reference to the instance of <typeparamref name="T"/> that
        /// represents the current element in the iteration, or <c>null</c> if
        /// the end of the collection has been passed.
        /// </returns>
        /// <remarks>
        /// This method returns a reference to the current element of the data
        /// set. When called, this method will automatically advance the
        /// current-item pointer to the next element in the list.
        /// <para/>
        /// NOTE: Even if <see cref="M:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext"/>
        /// returns <c>false</c>, this method will still return a non-
        /// <c>null</c> value.
        /// </remarks>
        T GetNext();

        /// <summary>
        /// Determines whether the collection has more items.
        /// </summary>
        /// <returns>
        /// <c>True</c> if the collection has more items; <c>false</c> otherwise.
        /// </returns>
        bool HasNext();
    }
}