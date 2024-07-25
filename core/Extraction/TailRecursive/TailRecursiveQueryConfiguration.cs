using Data_XML_Change_Core.Models;

namespace Data_XML_Change_Core.Extraction.TailRecursive;

/// <summary>
/// Configuration of the <see cref="TailRecursiveDataExtractor"/> to extract data. 
/// </summary>
internal class TailRecursiveQueryConfiguration
{
    /// <summary>
    /// List of queries to be performed to extract data.
    /// </summary>
    public List<XmlQuery> Queries { get; set; } = [];
}