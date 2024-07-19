namespace Data_XML_Change_Core.Retrieval.Http;

/// <summary>
/// Configuration data for <see cref="HttpDataRetriever"/> class.
/// </summary>
/// <param name="Url">The URL to call to retrieve XML data.</param>
internal record HttpDataConfiguration(string Url);