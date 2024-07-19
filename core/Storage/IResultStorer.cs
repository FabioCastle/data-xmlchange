using Data_XML_Change_Core.Models;

namespace Data_XML_Change_Core.Storage;

/// <summary>
/// Object able to store the results.
/// </summary>
public interface IResultStorer
{
    /// <summary>
    /// Stores the results of the data extraction phase.
    /// </summary>
    /// <param name="results">Results of the data extraction phase.</param>
    /// <exception cref="Exception"></exception>
    Task StoreResultsAsync(List<XmlQueryResult> results, CancellationToken cancellationToken);
}