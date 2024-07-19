namespace Data_XML_Change_Core.Retrieval.Http;

/// <summary>
/// Retrieves XML data via HTTP protocol.
/// </summary>
internal class HttpDataRetriever(HttpDataConfiguration Configuration) : IXmlDataRetriever
{
    public async Task<string> RetrieveXmlDataAsync(CancellationToken cancellationToken)
    {
        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, Configuration.Url);

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}