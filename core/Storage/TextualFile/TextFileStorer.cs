using System.Text;
using Data_XML_Change_Core.Models;

namespace Data_XML_Change_Core.Storage.TextualFile;

/// <summary>
/// Stores the results in a textual file with configurable output format.
/// </summary>
internal class TextFileStorer(TextFileConfiguration Configuration) : IResultStorer
{
    public async Task StoreResultsAsync(List<XmlQueryResult> results, CancellationToken cancellationToken)
    {
        var builder = new StringBuilder();

        foreach (var line in Configuration.Lines)
        {
            var values = line.ResultIds
                .Distinct()
                .Select(n => results.FirstOrDefault(r => r.Id == n))
                .Select(r => r == null ? "" : r.Result)
                .ToArray();

            var newLine = string.Format(line.FormatString, values);
            builder.AppendLine(newLine);
        }

        var outputFolder = Path.GetDirectoryName(Path.GetFullPath(Configuration.OutputFile));
        if (outputFolder != null && !Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        await File.WriteAllTextAsync(Configuration.OutputFile, builder.ToString(), cancellationToken);
    }
}