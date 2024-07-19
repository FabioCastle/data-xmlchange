using System.Xml.Linq;
using Data_XML_Change_Core.Models;

namespace Data_XML_Change_Core.Extraction.TailRecursive;

/// <summary>
/// Extracts data from XML file performing some queries with a breadth-first search approach using tail recursion.
/// </summary>
internal class TailRecursiveDataExtractor(TailRecursiveQueryConfiguration Configuration) : IXmlExtractor
{
    public List<XmlQueryResult> ExtractData(string xmlData)
    {
        XDocument xmlDocument = XDocument.Parse(xmlData);
        var rootElement = xmlDocument.Root;

        return TailRecursiveNodeSearch(Configuration.Queries, [rootElement]);
    }

    private static List<XmlQueryResult> TailRecursiveNodeSearch(List<XmlQuery> queries, List<XElement> nodes, List<XmlQueryResult>? result = null)
    {
        if (nodes == null || nodes.Count == 0)
            return result ?? [];

        result ??= [];

        if (result.Count >= queries.Count)
            return result;

        var currentNode = nodes.First();

        nodes = nodes.Skip(1).ToList();
        if (currentNode.HasElements)
        {
            nodes.AddRange(currentNode.Elements().ToList());
        }
        else
        {
            foreach (var query in queries)
            {
                var queryResult = PerformQueryOnXmlNode(query, currentNode);
                if (queryResult != null)
                    result.Add(queryResult);
            }
        }

        return TailRecursiveNodeSearch(queries, nodes, result);
    }

    private static XmlQueryResult? PerformQueryOnXmlNode(XmlQuery query, XElement node)
    {
        if (query.ElementType == FilterElementType.Tag)
        {
            if (node.Name.LocalName == query.FilterByName)
            {
                return ReadValueFromXmlNode(query, node);
            }
        }
        else if (query.ElementType == FilterElementType.Attribute)
        {
            var attribute = node.Attribute(query.FilterByName ?? "");
            if (attribute != null && attribute.Value == query.FilterByValue)
            {
                return ReadValueFromXmlNode(query, node);
            }
        }

        return null;
    }

    private static XmlQueryResult? ReadValueFromXmlNode(XmlQuery query, XElement node)
    {
        if (query.ValueLocation == ValueLocation.Attribute)
        {
            var valueAttribute = node.Attribute(query.ValueLocationName);
            if (valueAttribute != null)
            {
                return new XmlQueryResult(query.Id, valueAttribute.Value);
            }
        }
        else if (query.ValueLocation == ValueLocation.Content)
        {
            return new XmlQueryResult(query.Id, node.Value);
        }

        return null;
    }
}