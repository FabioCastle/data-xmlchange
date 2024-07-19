namespace Data_XML_Change_Core.Models;

/// <summary>
/// Result of a query performed on XML data.
/// </summary>
/// <param name="Id">Identifies the query result.</param>
/// <param name="Result">Data retrieved.</param>
public record XmlQueryResult(string Id, string Result);