namespace Data_XML_Change_Core;

/// <summary>
/// An object able to perform the Data XML-Change pipeline.
/// </summary>
public interface IDataXmlChange
{
    /// <summary>
    /// Executes the data conversion pipeline.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to stop the async execution.</param>
    Task ExecuteConversionAsync(CancellationToken cancellationToken);
}