namespace Data_XML_Change_Core.Storage.TextualFile;

/// <summary>
/// Configuration of the <see cref="TextFileStorer"/> class.
/// </summary>
public class TextFileConfiguration
{
    /// <summary>
    /// Full path of the output file to be written.
    /// </summary>
    public string OutputFile { get; set; } = "";
    /// <summary>
    /// Lines to be written in the output file.
    /// </summary>
    public List<TextLineConfiguration> Lines { get; set; } = [];
}

/// <summary>
/// Configuration of a line to be written in the output text file.
/// </summary>
public record TextLineConfiguration
{
    /// <summary>
    /// Format string with optional placeholders. E.g. "String {0} - {1}".
    /// </summary>
    public string FormatString { get; set; } = "";
    /// <summary>
    /// IDs of the results to be put in the formatted string.
    /// </summary>
    public List<string> ResultIds { get; set; } = [];
}