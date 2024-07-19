namespace Data_XML_Change_Core.Retrieval;

/// <summary>
/// An object that is able to retrieve XML data from an external source.
/// </summary>
public interface IXmlDataRetriever
{
    /// <summary>
    /// Retrieves XML data in string format.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to stop the async execution.</param>
    /// <returns>A string containing XML data.</returns>
    /// <exception cref="Exception"></exception>
    Task<string> RetrieveXmlDataAsync(CancellationToken cancellationToken);
}