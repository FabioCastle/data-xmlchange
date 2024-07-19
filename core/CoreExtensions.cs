using Data_XML_Change_Core.Extraction;
using Data_XML_Change_Core.Extraction.TailRecursive;
using Data_XML_Change_Core.Retrieval;
using Data_XML_Change_Core.Retrieval.Http;
using Data_XML_Change_Core.Storage;
using Data_XML_Change_Core.Storage.TextualFile;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data_XML_Change_Core;

public static class CoreExtensions
{
    /// <summary>
    /// Adds all the classes required to use Data XML-Change.
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static IServiceCollection AddDataXmlChange(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IXmlDataRetriever, HttpDataRetriever>((_) =>
        {
            var dataRetrievalSection = configuration.GetSection("DataXmlChange:DataRetrieval");
            var dataRetrievalConfiguration = dataRetrievalSection.Get<HttpDataConfiguration>()
                ?? throw new Exception($"Can't read {nameof(HttpDataConfiguration)} from configuration. Key = DataXmlChange:DataRetrieval.");

            return new HttpDataRetriever(dataRetrievalConfiguration);
        });

        services.AddSingleton<IXmlExtractor, TailRecursiveDataExtractor>((_) =>
        {
            var dataExtractionSection = configuration.GetSection("DataXmlChange:DataExtraction");
            var dataExtractionConfiguration = dataExtractionSection.Get<TailRecursiveQueryConfiguration>()
                ?? throw new Exception($"Can't read {nameof(TailRecursiveQueryConfiguration)} from configuration. Key = DataXmlChange:DataExtraction.");

            return new TailRecursiveDataExtractor(dataExtractionConfiguration);
        });

        services.AddSingleton<IResultStorer, TextFileStorer>((_) =>
        {
            var dataStorageSection = configuration.GetSection("DataXmlChange:DataStorage");
            var dataStorageConfiguration = dataStorageSection.Get<TextFileConfiguration>()
                ?? throw new Exception($"Can't read {nameof(TextFileConfiguration)} from configuration. Key = DataXmlChange:DataStorage.");

            return new TextFileStorer(dataStorageConfiguration);
        });

        services.AddSingleton<IDataXmlChange, DataXmlChange>();

        return services;
    }
}