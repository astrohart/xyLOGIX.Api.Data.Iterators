using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Model;
using PostSharp.Patterns.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using xyLOGIX.Api.Data.Iterators.Events;
using xyLOGIX.Api.Data.Iterators.Exceptions;
using xyLOGIX.Api.Data.Iterators.Interfaces;
using xyLOGIX.Collections.Synchronized;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Api.Data.Iterators
{
    /// <summary>
    /// Implements the
    /// <see cref="T:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator" /> interface for
    /// all objects that provide differing behaviors of the iteration process.
    /// </summary>
    /// <typeparam name="T">
    /// Name of the type that represents a POCO that should be
    /// returned, that is initialized with the values for each element in the
    /// collection.
    /// </typeparam>
    public abstract class IteratorBase<T> : IIterator<T> where T : class
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Api.Data.Iterators.IteratorBase" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static IteratorBase() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Api.Data.Iterators.IteratorBase" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="pageSize">
        /// (Optional.) Integer value specifying the number of
        /// items to be retrieved every time that the iterator is advanced.
        /// </param>
        [Log(AttributeExclude = true)]
        protected IteratorBase(int pageSize = 1)
        {
            IsLastPage = false;
            PageSize = pageSize;
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the
        /// enumerator.
        /// </summary>
        /// <returns>
        /// The element in the collection at the current position of the
        /// enumerator.
        /// </returns>
        public T Current
            => GetNext();

        /// <summary>
        /// Gets the element in the collection at the current position of the
        /// enumerator.
        /// </summary>
        /// <returns>
        /// The element in the collection at the current position of the
        /// enumerator.
        /// </returns>
        object IEnumerator.Current
            => Current;

        /// <summary>
        /// Gets or sets a reference to an instance of an object that represents the
        /// current page of data.
        /// </summary>
        protected abstract dynamic CurrentPage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets a reference to a cache of items obtained that are in excess of
        /// what is requested, but which still need to be provided to users of this object.
        /// </summary>
        [Child]
        protected AdvisableStack<T> ExcessItemCache { [DebuggerStepThrough] get; } =
            new AdvisableStack<T>();

        /// <summary>
        /// Gets or sets a <see cref="T:System.String" /> or other key that is
        /// used to look up order account history items and/or transactions for a specific
        /// asset, wallet, or account history.
        /// </summary>
        /// <remarks>
        /// This property is of <c>dynamic</c> type since the type of filter data
        /// is platform-specific.
        /// </remarks>
        public dynamic Filter { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets a value indicating whether the last page of paginated
        /// data has been read from the data source.
        /// </summary>
        protected bool IsLastPage { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets the number of elements to be retrieved each time that we advance
        /// to another page.
        /// </summary>
        public int PageSize { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary> Occurs when an exception is thrown during the iteration process. </summary>
        public event IteratorErrorEventHandler IteratorError;

        /// <summary> Occurs when the end of the collection has been reached. </summary>
        public event EventHandler LastItemReached;

        /// <summary> Occurs when no items have been found in the underlying collection. </summary>
        public event EventHandler NoItemsFound;

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        /// <remarks>
        /// For the task of consuming a paged API result to minimize network
        /// traffic, this method is meaningless.
        /// </remarks>
        public void Dispose() { }

        /// <summary>
        /// Gets the entire collection and returns an enumerator to be used to
        /// iterate over it.
        /// </summary>
        /// <returns>
        /// Reference to an instance of a collection object that implements the
        /// <see cref="T:System.Collections.Generic.IEnumerable{T}" /> interface. This
        /// contains all the elements of the entire data set.
        /// </returns>
        /// <remarks>
        /// Implementations should generally call the
        /// <see cref="M:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.GetNext" /> and
        /// <see cref="M:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext" />
        /// methods in order to obtain all the elements.
        /// <para />
        /// This method raises the
        /// <see cref="E:xyLOGIX.Api.Data.Iterators.IteratorBase.IterationError" /> event
        /// if an exception gets raised during the iteration process. In this case, this
        /// method then returns the empty enumerable.
        /// </remarks>
        public IEnumerable<T> GetAll()
        {
            var result = new AdvisableCollection<T>();

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
                OnIteratorError(
                    new IteratorErrorEventArgs(
                        new IteratorException(
                            "A problem was occurred during the iteration operation.",
                            ex
                        )
                    )
                );

                // in the event an exception occurred, just return the empty list
                result = new AdvisableCollection<T>();
            }

            return result;
        }

        /// <summary>
        /// Returns a reference to an instance of <typeparamref name="T" /> that
        /// is the current item in the data set that the iterator is now pointing to.
        /// </summary>
        /// <returns>
        /// Reference to the instance of <typeparamref name="T" /> that
        /// represents the current element in the iteration, or <c>null</c> if the end of
        /// the collection has been passed.
        /// </returns>
        /// <remarks>
        /// This method returns a reference to the current element of the data
        /// set. When called, this method will automatically advance the current-item
        /// pointer to the next element in the list.
        /// <para />
        /// NOTE: Even if
        /// <see cref="M:xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext" />
        /// returns <c>false</c>, this method will still return a non- <c>null</c> value.
        /// </remarks>
        public abstract T GetNext();

        /// <summary> Determines whether the collection has more items. </summary>
        /// <returns> <c>True</c> if the collection has more items; <c>false</c> otherwise. </returns>
        public abstract bool HasNext();

        /// <summary> Advances the enumerator to the next element of the collection. </summary>
        /// <returns>
        /// <see langword="true" /> if the enumerator was successfully advanced
        /// to the next element; <see langword="false" /> if the enumerator has passed the
        /// end of the collection.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">
        /// The collection was
        /// modified after the enumerator was created.
        /// </exception>
        public bool MoveNext()
            => HasNext();

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the
        /// first element in the collection.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">
        /// The collection was
        /// modified after the enumerator was created.
        /// </exception>
        public abstract void Reset();

        /// <summary>
        /// Caches excess items in a collection retrieved from the data source
        /// that we are iterating over.
        /// </summary>
        /// <param name="excessItems">
        /// Collection of references to instances of
        /// <typeparamref name="T" /> that need to be cached.
        /// </param>
        /// <remarks>
        /// When overriding this method, implementers must start by calling the
        /// base class.
        /// </remarks>
        [EntryPoint]
        protected virtual void CacheExcess(ICollection<T> excessItems)
        {
            try
            {
                var excessItemArray =
                    excessItems as T[] ?? excessItems.ToArray();
                if (excessItemArray.Length == 0) // nothing to do
                    return;

                // If we are here, then there are excess items, over and above the
                // single "current item" that this iterator step through. In that
                // event, push all the excess items on to the Excess Item Cache stack.
                //
                // MOTE: We do not want to double-insert items, as that would consume
                // lots of additional memory.  Instead, we will only push an item into
                // the excess item cache if it does not already exist on the stack.

                // If the set of items to be added is itself identical to the
                // entire stack, then do nothing.  Let's not even waste the cycles
                // iterating over the input list, is this is the case.

                if (excessItemArray.SequenceEqual(ExcessItemCache)) return;

                foreach (var item in excessItemArray)
                    if (!ExcessItemCache.Contains(item))
                        ExcessItemCache.Push(item);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }

        /// <summary> Retrieves the current page of results from the REST API. </summary>
        /// <param name="pageSize">
        /// (Optional.) Integer specifying the number of elements
        /// to be retrieved.
        /// </param>
        [EntryPoint]
        protected abstract void GetCurrentPage(int pageSize = 1);

        /// <summary>
        /// Determines whether the
        /// <see
        ///     cref="P:PortfolioGPT.Providers.Assets.Iterators.IteratorBase`1.CurrentPage" />
        /// has a next page or not.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if a next page exists;
        /// <see langword="false" /> otherwise.
        /// </returns>
        /// <remarks>
        /// This method accounts for <see langword="null" /> references and the
        /// <see
        ///     cref="P:PortfolioGPT.Providers.Assets.Iterators.IteratorBase`1.CurrentPage" />
        /// property not having the correct type, or pointing to an empty page.
        /// </remarks>
        [EntryPoint]
        protected abstract bool HasNextPage();

        /// <summary>
        /// Determines whether the current page of data is empty.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the current page of data is empty;
        /// <see langword="false" /> otherwise.
        /// </returns>
        [EntryPoint]
        protected abstract bool IsCurrentPageEmpty();

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.Api.Data.Iterators.IteratorBase.IteratorError" /> event.
        /// </summary>
        /// <param name="e">
        /// A
        /// <see cref="T:xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs" /> that
        /// contains the event data.
        /// </param>
        [Yielder]
        protected virtual void OnIteratorError(IteratorErrorEventArgs e)
            => IteratorError?.Invoke(this, e);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.Api.Data.Iterators.IteratorBase.LastItemReached" /> event.
        /// </summary>
        [Yielder]
        protected virtual void OnLastItemReached()
            => LastItemReached?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.Api.Data.Iterators.IteratorBase.NoItemsFound" /> event.
        /// </summary>
        [Yielder]
        protected virtual void OnNoItemsFound()
            => NoItemsFound?.Invoke(this, EventArgs.Empty);
    }
}