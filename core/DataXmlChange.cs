using Data_XML_Change_Core.Extraction;
using Data_XML_Change_Core.Models;
using Data_XML_Change_Core.Retrieval;
using Data_XML_Change_Core.Storage;

namespace Data_XML_Change_Core;

internal class DataXmlChange(IXmlDataRetriever Retriever, IXmlExtractor Extractor, IResultStorer Storer) : IDataXmlChange
{
    public async Task ExecuteConversionAsync(CancellationToken cancellationToken)
    {
        var xmlData = await Retriever.RetrieveXmlDataAsync(cancellationToken)
            ?? throw new Exception("Can't retrieve any XML data.");

        var extractedData = Extractor.ExtractData(xmlData)
            ?? throw new Exception("Can't extract any information from XML data.");

        await Storer.StoreResultsAsync(extractedData, cancellationToken);
    }
}

internal record DataXmlChangeConfiguration(List<XmlQuery> Queries);