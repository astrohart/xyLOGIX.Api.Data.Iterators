<a name='assembly'></a>
# xyLOGIX.Api.Data.Iterators.Events

## Contents

- [IteratorErrorEventArgs](#T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs')
  - [#ctor()](#M-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs-#ctor 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs.#ctor')
  - [#ctor(exception)](#M-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs-#ctor-xyLOGIX-Api-Data-Iterators-Exceptions-IteratorException- 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs.#ctor(xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException)')
  - [Exception](#P-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs-Exception 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs.Exception')
  - [#cctor()](#M-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs-#cctor 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs.#cctor')
- [IteratorErrorEventHandler](#T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventHandler 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventHandler')
- [Resources](#T-xyLOGIX-Api-Data-Iterators-Events-Properties-Resources 'xyLOGIX.Api.Data.Iterators.Events.Properties.Resources')
  - [Culture](#P-xyLOGIX-Api-Data-Iterators-Events-Properties-Resources-Culture 'xyLOGIX.Api.Data.Iterators.Events.Properties.Resources.Culture')
  - [ResourceManager](#P-xyLOGIX-Api-Data-Iterators-Events-Properties-Resources-ResourceManager 'xyLOGIX.Api.Data.Iterators.Events.Properties.Resources.ResourceManager')

<a name='T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs'></a>
## IteratorErrorEventArgs `type`

##### Namespace

xyLOGIX.Api.Data.Iterators.Events

##### Summary

Provides information for IteratorError event handlers.

<a name='M-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of
[IteratorErrorEventArgs](#T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs') and
returns a reference to it.

##### Parameters

This constructor has no parameters.

<a name='M-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs-#ctor-xyLOGIX-Api-Data-Iterators-Exceptions-IteratorException-'></a>
### #ctor(exception) `constructor`

##### Summary

Constructs a new instance of
[IteratorErrorEventArgs](#T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs') and
returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException](#T-xyLOGIX-Api-Data-Iterators-Exceptions-IteratorException 'xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException') | (Required.) A
[IteratorException](#T-xyLOGIX-Api-Data-Iterators-Exceptions-IteratorException 'xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException') that
provides more information about the error. |

<a name='P-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs-Exception'></a>
### Exception `property`

##### Summary

Gets a reference to the
[IteratorException](#T-xyLOGIX-Api-Data-Iterators-Exceptions-IteratorException 'xyLOGIX.Api.Data.Iterators.Exceptions.IteratorException') that
provides more information about the error.

<a name='M-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the
[IteratorErrorEventArgs](#T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventArgs 'xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs')
class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventHandler'></a>
## IteratorErrorEventHandler `type`

##### Namespace

xyLOGIX.Api.Data.Iterators.Events

##### Summary

Represents a handler for a IteratorError event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventHandler](#T-T-xyLOGIX-Api-Data-Iterators-Events-IteratorErrorEventHandler 'T:xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventHandler') | Reference to the instance of the object that raised the
event. |

##### Remarks

This delegate merely specifies the signature of all methods that
handle the IteratorError event.

<a name='T-xyLOGIX-Api-Data-Iterators-Events-Properties-Resources'></a>
## Resources `type`

##### Namespace

xyLOGIX.Api.Data.Iterators.Events.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-xyLOGIX-Api-Data-Iterators-Events-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all resource lookups using this strongly typed resource class.

<a name='P-xyLOGIX-Api-Data-Iterators-Events-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.
