<a name='assembly'></a>
# xyLOGIX.Api.Data.Iterators.Interfaces

## Contents

- [IIterator\`1](#T-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator`1')
  - [PageSize](#P-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1-PageSize 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator`1.PageSize')
  - [GetAll()](#M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1-GetAll 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator`1.GetAll')
  - [GetNext()](#M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1-GetNext 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator`1.GetNext')
  - [HasNext()](#M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1-HasNext 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator`1.HasNext')
- [Resources](#T-xyLOGIX-Api-Data-Iterators-Interfaces-Properties-Resources 'xyLOGIX.Api.Data.Iterators.Interfaces.Properties.Resources')
  - [Culture](#P-xyLOGIX-Api-Data-Iterators-Interfaces-Properties-Resources-Culture 'xyLOGIX.Api.Data.Iterators.Interfaces.Properties.Resources.Culture')
  - [ResourceManager](#P-xyLOGIX-Api-Data-Iterators-Interfaces-Properties-Resources-ResourceManager 'xyLOGIX.Api.Data.Iterators.Interfaces.Properties.Resources.ResourceManager')

<a name='T-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1'></a>
## IIterator\`1 `type`

##### Namespace

xyLOGIX.Api.Data.Iterators.Interfaces

##### Summary

Defines the publicly-exposed methods and properties of an object that iterates over a data set whose total number of items is not known in advance. Each data item is referenced as an instance of `T`.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Name of a class that represents a single element of the collection. |

<a name='P-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1-PageSize'></a>
### PageSize `property`

##### Summary

Gets the number of elements to be retrieved each time that we advance to another page.

<a name='M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1-GetAll'></a>
### GetAll() `method`

##### Summary

Gets the entire collection and returns an enumerator to be used to iterate over it.

##### Returns

Reference to an instance of a collection object that implements the [IEnumerable{T}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{T}') interface. This contains all the elements of the entire data set.

##### Parameters

This method has no parameters.

##### Remarks

Implementations should generally call the [GetNext](#M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator-GetNext 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.GetNext') and [HasNext](#M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator-HasNext 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext') methods in order to obtain all the elements.

<a name='M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1-GetNext'></a>
### GetNext() `method`

##### Summary

Returns a reference to an instance of `T` that is the current item in the data set that the iterator is now pointing to.

##### Returns

Reference to the instance of `T` that represents the current element in the iteration, or `null` if the end of the collection has been passed.

##### Parameters

This method has no parameters.

##### Remarks

This method returns a reference to the current element of the data set. When called, this method will automatically advance the current-item pointer to the next element in the list.



NOTE: Even if [HasNext](#M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator-HasNext 'xyLOGIX.Api.Data.Iterators.Interfaces.IIterator.HasNext') returns `false`, this method will still return a non- `null` value.

<a name='M-xyLOGIX-Api-Data-Iterators-Interfaces-IIterator`1-HasNext'></a>
### HasNext() `method`

##### Summary

Determines whether the collection has more items.

##### Returns

`True` if the collection has more items; `false` otherwise.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Api-Data-Iterators-Interfaces-Properties-Resources'></a>
## Resources `type`

##### Namespace

xyLOGIX.Api.Data.Iterators.Interfaces.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-xyLOGIX-Api-Data-Iterators-Interfaces-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all resource lookups using this strongly typed resource class.

<a name='P-xyLOGIX-Api-Data-Iterators-Interfaces-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.
