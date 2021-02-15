using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using xyLOGIX.Api.Data.Iterators.Events;
using xyLOGIX.Api.Data.Iterators.Exceptions;
using xyLOGIX.Api.Data.Iterators.Interfaces;

namespace xyLOGIX.Api.Data.Iterators
{
    /// <summary>
    /// Implements the
    /// <see
    ///     cref="T:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator" />
    /// interface for
    /// all objects that provide differing behaviors of the iteration process.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public abstract class IteratorBase<T> : IIterator<T> where T : class
    {
        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:xyLOGIX.Api.Data.Iterators.IteratorBase" />
        /// and returns a
        /// reference to it.
        /// </summary>
        protected IteratorBase()
        {
            IsLastPage = false;
        }

        /// <summary>
        /// Gets a reference to a cache of items obtained that are in excess of
        /// what is requested, but which still need to be provided to users of
        /// this object.
        /// </summary>
        protected Stack<T> ExcessItemCache { get; } = new Stack<T>();

        /// <summary>
        /// Gets or sets a value indicating whether the last page of paginated
        /// data has been read from the data source.
        /// </summary>
        protected bool IsLastPage { get; set; }

        /// <summary>
        /// Occurs when an exception is thrown during the iteration process.
        /// </summary>
        public event IterationErrorEventHandler IterationError;

        /// <summary>
        /// Occurs when the end of the collection has been reached.
        /// </summary>
        public event EventHandler LastItemReached;

        /// <summary>
        /// Occurs when no items have been found in the underlying collection.
        /// </summary>
        public event EventHandler NoItemsFound;

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <returns>
        /// The element in the collection at the current position of the enumerator.
        /// </returns>
        public T Current
            => GetNext();

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <returns>
        /// The element in the collection at the current position of the enumerator.
        /// </returns>
        object IEnumerator.Current
            => Current;

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() { }

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
        ///     cref="M:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.GetNext" />
        /// and
        /// <see
        ///     cref="M:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext" />
        /// methods in order to obtain all the elements.
        /// <para />
        /// This method raises the
        /// <see
        ///     cref="E:xyLOGIX.Api.Data.Iterators.IteratorBase.IterationError" />
        /// event if an exception gets raised during the iteration process. In
        /// this case, this method then returns the empty enumerable.
        /// </remarks>
        public IEnumerable<T> GetAll()
        {
            var result = new List<T>();

            IsLastPage = false;

            try
            {
                var current = default(T);

                do
                {
                    current = GetNext();
                    if (current == null) break;
                    result.Add(current);
                } while (current != null && HasNext());
            }
            catch (Exception ex)
            {
                OnIterationError(
                    new IterationErrorEventArgs(
                        new IteratorException(
                            "A problem was occurred during the iteration operation.",
                            ex
                        )
                    )
                );

                // in the event an exception occurred, just return the empty list
                result = new List<T>();
            }

            return result;
        }

        /// <summary>
        /// Returns a reference to an instance of <typeparamref name="T" /> that
        /// is the current item in the data set that the iterator is now
        /// pointing to.
        /// </summary>
        /// <typeparam name="T">
        /// Name of the class that represents a single element of the data set.
        /// </typeparam>
        /// <returns>
        /// Reference to the instance of <typeparamref name="T" /> that
        /// represents the current element in the iteration, or <c>null</c> if
        /// the end of the collection has been passed.
        /// </returns>
        /// <remarks>
        /// This method returns a reference to the current element of the data
        /// set. When called, this method will automatically advance the
        /// current-item pointer to the next element in the list.
        /// <para />
        /// NOTE: Even if
        /// <see cref="M:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext" />
        /// returns <c>false</c>, this method will still return a non-
        /// <c>null</c> value.
        /// </remarks>
        public abstract T GetNext();

        /// <summary>
        /// Determines whether the collection has more items.
        /// </summary>
        /// <returns>
        /// <c>True</c> if the collection has more items; <c>false</c> otherwise.
        /// </returns>
        public abstract bool HasNext();

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the enumerator was successfully advanced
        /// to the next element; <see langword="false" /> if the enumerator has
        /// passed the end of the collection.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">
        /// The collection was modified after the enumerator was created.
        /// </exception>
        public bool MoveNext()
            => HasNext();

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the
        /// first element in the collection.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">
        /// The collection was modified after the enumerator was created.
        /// </exception>
        public void Reset()
            => throw new NotImplementedException();

        /// <summary>
        /// Caches excess items in a collection retrieved from the data source
        /// that we are iterating over.
        /// </summary>
        /// <param name="excessItems">
        /// Collection of references to instances of <typeparamref name="T" />
        /// that need to be cached.
        /// </param>
        /// <remarks>
        /// When overriding this method, implementers must start by calling the
        /// base class.
        /// </remarks>
        protected virtual void CacheExcess(IEnumerable<T> excessItems)
        {
            var excessItemArray = excessItems as T[] ?? excessItems.ToArray();
            if (!excessItemArray.Any()) // nothing to do
                return;

            // If we are here, then there are excess items, over and above the
            // single "current item" that this iterator step through. In that
            // event, push all the excess items on to the Excess Item Cache stack.

            foreach (var item in excessItemArray)
                ExcessItemCache.Push(item);
        }

        /// <summary>
        /// Raises the
        /// <see
        ///     cref="E:xyLOGIX.Api.Data.Iterators.IteratorBase.IterationError" />
        /// event.
        /// </summary>
        /// <param name="e">
        /// A
        /// <see
        ///     cref="T:xyLOGIX.Api.Data.Iterators.Events.IterationErrorEventArgs" />
        /// that contains the event data.
        /// </param>
        protected virtual void OnIterationError(IterationErrorEventArgs e)
            => IterationError?.Invoke(this, e);

        /// <summary>
        /// Raises the
        /// <see
        ///     cref="E:xyLOGIX.Api.Data.Iterators.IteratorBase.LastItemReached" />
        /// event.
        /// </summary>
        protected virtual void OnLastItemReached()
            => LastItemReached?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the
        /// <see
        ///     cref="E:xyLOGIX.Api.Data.Iterators.IteratorBase.NoItemsFound" />
        /// event.
        /// </summary>
        protected virtual void OnNoItemsFound()
            => NoItemsFound?.Invoke(this, EventArgs.Empty);
    }
}