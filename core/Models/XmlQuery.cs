namespace Data_XML_Change_Core.Models;

/// <summary>
/// Query to extract one value from XML data.
/// </summary>
/// <param name="Id">Unique name to give to the query result.</param>
/// <param name="ElementType">The type of element that stores the value.</param>
/// <param name="FilterByName">Name of the element to search.</param>
/// <param name="FilterByValue">Optional value of the attribute to search.</param>
/// <param name="ValueLocation">Once the element is found, where to extract the value.</param>
/// <param name="ValueLocationName">Optional name of the attribute where to extract the value.</param>
public record XmlQuery(string Id, FilterElementType ElementType, string? FilterByName, string? FilterByValue, ValueLocation ValueLocation, string ValueLocationName);

/// <summary>
/// The type of element to query.
/// </summary>
public enum FilterElementType
{
    Tag,
    Attribute
}

/// <summary>
/// Where to retrieve the value once the query element is found.
/// </summary>
public enum ValueLocation
{
    /// <summary>
    /// The value is stored as text content of the element.
    /// </summary>
    Content,
    /// <summary>
    /// The value is stored as an attribute of the element.
    /// </summary>
    Attribute
}