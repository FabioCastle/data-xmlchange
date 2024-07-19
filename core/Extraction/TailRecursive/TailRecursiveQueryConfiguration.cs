using Data_XML_Change_Core.Models;

namespace Data_XML_Change_Core.Extraction.TailRecursive;

/// <summary>
/// Configuration of the <see cref="TailRecursiveDataExtractor"/> to extract data. 
/// </summary>
/// <param name="Queries">List of queries to be performed to extract data.</param>
public record TailRecursiveQueryConfiguration(List<XmlQuery> Queries);