namespace Data_XML_Change_Core.Storage.TextualFile;

/// <summary>
/// Configuration of the <see cref="TextFileStorer"/> class.
/// </summary>
/// <param name="OutputFile">Full path of the output file to be written.</param>
/// <param name="Lines">Lines to be written in the output file.</param>
public record TextFileConfiguration(string OutputFile, List<TextLineConfiguration> Lines);

/// <summary>
/// Configuration of a line to be written in the output text file.
/// </summary>
/// <param name="FormatString">Format string with optional placeholders. E.g. "String {0} - {1}".</param>
/// <param name="ResultIds">IDs of the results to be put in the formatted string.</param>
public record TextLineConfiguration(string FormatString, List<string> ResultIds);