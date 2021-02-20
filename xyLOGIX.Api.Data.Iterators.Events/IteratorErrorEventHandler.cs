namespace xyLOGIX.Api.Data.Iterators.Events
{
    /// <summary>
    /// Represents a handler for a IteratorError event.
    /// </summary>
    /// <param name="sender">
    /// Reference to the instance of the object that raised the event.
    /// </param>
    /// <param name="e">
    /// A <see
    /// cref="T:xyLOGIX.Api.Data.Iterators.Events.IteratorErrorEventArgs"/> that
    /// contains the event data.
    /// </param>
    /// <remarks>
    /// This delegate merely specifies the signature of all methods that handle
    /// the IteratorError event.
    /// </remarks>
    public delegate void IteratorErrorEventHandler(object sender, IteratorErrorEventArgs e);
}