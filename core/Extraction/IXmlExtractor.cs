using Data_XML_Change_Core.Models;

namespace Data_XML_Change_Core.Extraction;

/// <summary>
/// An object that is able to extract infromation executing some queries on XML data.
/// </summary>
public interface IXmlExtractor
{
    /// <summary>
    /// Performs a list of queries on XML data and returns their results.
    /// </summary>
    /// <param name="xmlData">XML data as a string.</param>
    /// <returns>The results of the queries configured.</returns>
    /// <exception cref="Exception"></exception>
    List<XmlQueryResult> ExtractData(string xmlData);
}