<a name='assembly'></a>
# xyLOGIX.Api.Data.Iterators

## Contents

- [IteratorBase\`1](#T-xyLOGIX-Api-Data-Iterators-IteratorBase`1 'xyLOGIX.Api.Data.Iterators.IteratorBase`1')
  - [#ctor(pageSize)](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-#ctor-System-Int32- 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.#ctor(System.Int32)')
  - [Current](#P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-Current 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.Current')
  - [ExcessItemCache](#P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-ExcessItemCache 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.ExcessItemCache')
  - [IsLastPage](#P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-IsLastPage 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.IsLastPage')
  - [PageSize](#P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-PageSize 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.PageSize')
  - [System#Collections#IEnumerator#Current](#P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-System#Collections#IEnumerator#Current 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.System#Collections#IEnumerator#Current')
  - [CacheExcess(excessItems)](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-CacheExcess-System-Collections-Generic-IEnumerable{`0}- 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.CacheExcess(System.Collections.Generic.IEnumerable{`0})')
  - [Dispose()](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-Dispose 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.Dispose')
  - [GetAll()](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-GetAll 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.GetAll')
  - [GetCurrentPage(pageSize)](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-GetCurrentPage-System-Int32- 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.GetCurrentPage(System.Int32)')
  - [GetNext()](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-GetNext 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.GetNext')
  - [HasNext()](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-HasNext 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.HasNext')
  - [MoveNext()](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-MoveNext 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.MoveNext')
  - [OnIteratorError(e)](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-OnIteratorError-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs- 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.OnIteratorError(xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs)')
  - [OnLastItemReached()](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-OnLastItemReached 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.OnLastItemReached')
  - [OnNoItemsFound()](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-OnNoItemsFound 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.OnNoItemsFound')
  - [Reset()](#M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-Reset 'xyLOGIX.Api.Data.Iterators.IteratorBase`1.Reset')
- [Resources](#T-xyLOGIX-Api-Data-Iterators-Properties-Resources 'xyLOGIX.Api.Data.Iterators.Properties.Resources')
  - [Culture](#P-xyLOGIX-Api-Data-Iterators-Properties-Resources-Culture 'xyLOGIX.Api.Data.Iterators.Properties.Resources.Culture')
  - [ResourceManager](#P-xyLOGIX-Api-Data-Iterators-Properties-Resources-ResourceManager 'xyLOGIX.Api.Data.Iterators.Properties.Resources.ResourceManager')

<a name='T-xyLOGIX-Api-Data-Iterators-IteratorBase`1'></a>
## IteratorBase\`1 `type`

##### Namespace

xyLOGIX.Api.Data.Iterators

##### Summary

Implements the [IIterator](#T-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator') interface for
all objects that provide differing behaviors of the iteration process.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-#ctor-System-Int32-'></a>
### #ctor(pageSize) `constructor`

##### Summary

Constructs a new instance of [IteratorBase](#T-xyLOGIX-Api-Data-Iterators-IteratorBase 'xyLOGIX.Api.Data.Iterators.IteratorBase') and returns a
reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pageSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) Integer value specifying the number of items to be
retrieved every time that the iterator is advanced. |

<a name='P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-Current'></a>
### Current `property`

##### Summary

Gets the element in the collection at the current position of the enumerator.

##### Returns

The element in the collection at the current position of the enumerator.

<a name='P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-ExcessItemCache'></a>
### ExcessItemCache `property`

##### Summary

Gets a reference to a cache of items obtained that are in excess of
what is requested, but which still need to be provided to users of
this object.

<a name='P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-IsLastPage'></a>
### IsLastPage `property`

##### Summary

Gets or sets a value indicating whether the last page of paginated
data has been read from the data source.

<a name='P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-PageSize'></a>
### PageSize `property`

##### Summary

Gets the number of elements to be retrieved each time that we
advance to another page.

<a name='P-xyLOGIX-Api-Data-Iterators-IteratorBase`1-System#Collections#IEnumerator#Current'></a>
### System#Collections#IEnumerator#Current `property`

##### Summary

Gets the element in the collection at the current position of the enumerator.

##### Returns

The element in the collection at the current position of the enumerator.

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-CacheExcess-System-Collections-Generic-IEnumerable{`0}-'></a>
### CacheExcess(excessItems) `method`

##### Summary

Caches excess items in a collection retrieved from the data source
that we are iterating over.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| excessItems | [System.Collections.Generic.IEnumerable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{`0}') | Collection of references to instances of `T`
that need to be cached. |

##### Remarks

When overriding this method, implementers must start by calling the
base class.

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-Dispose'></a>
### Dispose() `method`

##### Summary

Performs application-defined tasks associated with freeing,
releasing, or resetting unmanaged resources.

##### Parameters

This method has no parameters.

##### Remarks

For the task of consuming a paged API result to minimize network
traffic, this method is meaningless.

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-GetAll'></a>
### GetAll() `method`

##### Summary

Gets the entire collection and returns an enumerator to be used to
iterate over it.

##### Returns

Reference to an instance of a collection object that implements the
[IEnumerable{T}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{T}') interface.
This contains all the elements of the entire data set.

##### Parameters

This method has no parameters.

##### Remarks

Implementations should generally call the [GetNext](#M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator-GetNext 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.GetNext')
and [HasNext](#M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator-HasNext 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext')
methods in order to obtain all the elements.



This method raises the [](#E-xyLOGIX-Api-Data-Iterators-IteratorBase-IterationError 'xyLOGIX.Api.Data.Iterators.IteratorBase.IterationError')
event if an exception gets raised during the iteration process. In
this case, this method then returns the empty enumerable.

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-GetCurrentPage-System-Int32-'></a>
### GetCurrentPage(pageSize) `method`

##### Summary

Retrieves the current page of results from the REST API.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pageSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) Integer specifying the number of elements to be retrieved. |

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-GetNext'></a>
### GetNext() `method`

##### Summary

Returns a reference to an instance of `T` that
is the current item in the data set that the iterator is now
pointing to.

##### Returns

Reference to the instance of `T` that
represents the current element in the iteration, or `null` if
the end of the collection has been passed.

##### Parameters

This method has no parameters.

##### Remarks

This method returns a reference to the current element of the data
set. When called, this method will automatically advance the
current-item pointer to the next element in the list.



NOTE: Even if [HasNext](#M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator-HasNext 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext')
returns `false`, this method will still return a non-
`null` value.

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-HasNext'></a>
### HasNext() `method`

##### Summary

Determines whether the collection has more items.

##### Returns

`True` if the collection has more items; `false` otherwise.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-MoveNext'></a>
### MoveNext() `method`

##### Summary

Advances the enumerator to the next element of the collection.

##### Returns

`true` if the enumerator was successfully advanced
to the next element; `false` if the enumerator has
passed the end of the collection.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | The collection was modified after the enumerator was created. |

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-OnIteratorError-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs-'></a>
### OnIteratorError(e) `method`

##### Summary

Raises the [](#E-xyLOGIX-Api-Data-Iterators-IteratorBase-IteratorError 'xyLOGIX.Api.Data.Iterators.IteratorBase.IteratorError') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs](#T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs') | A [IteratorErrorEventArgs](#T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs')
that contains the event data. |

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-OnLastItemReached'></a>
### OnLastItemReached() `method`

##### Summary

Raises the [](#E-xyLOGIX-Api-Data-Iterators-IteratorBase-LastItemReached 'xyLOGIX.Api.Data.Iterators.IteratorBase.LastItemReached') event.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-OnNoItemsFound'></a>
### OnNoItemsFound() `method`

##### Summary

Raises the [](#E-xyLOGIX-Api-Data-Iterators-IteratorBase-NoItemsFound 'xyLOGIX.Api.Data.Iterators.IteratorBase.NoItemsFound') event.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Api-Data-Iterators-IteratorBase`1-Reset'></a>
### Reset() `method`

##### Summary

Sets the enumerator to its initial position, which is before the
first element in the collection.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | The collection was modified after the enumerator was created. |

<a name='T-xyLOGIX-Api-Data-Iterators-Properties-Resources'></a>
## Resources `type`

##### Namespace

xyLOGIX.Api.Data.Iterators.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-xyLOGIX-Api-Data-Iterators-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-xyLOGIX-Api-Data-Iterators-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.
