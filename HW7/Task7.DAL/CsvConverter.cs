using System.Text;
using System.Text.RegularExpressions;

namespace Task7.DAL;

internal static class CsvConverter
{
    public static List<string> ConvertCsvRow(string row)
    {
        var result = new List<string>();
        bool isInsideQuotes = false;
        var currentField = new StringBuilder();

        foreach (var ch in row)
        {
            if (ch == '"' && !isInsideQuotes) //Enter to quotes
            {
                isInsideQuotes = true;
                continue;
            }
            else if (ch == '"' && isInsideQuotes) //Exit from quotes
            {

                isInsideQuotes = false;
                continue;
            }
            else if (ch == ',' && !isInsideQuotes) //Between data
            {
                result.Add(currentField.ToString().Trim());
                currentField.Clear();
            }
            else
            {
                currentField.Append(ch); // Add symbol
            }
        }

        if (currentField.Length > 0)
        {
            result.Add(currentField.ToString().Trim());
        }

        return result;
    }

    public static List<string> ConvertToListOfFormats(string line)
    {
        var result = line.Split(',').ToList();

        return result;
    }

    public static string ConvertIdentifier(string line)
    {
        if (line.Contains("isbn"))
        {
           var isbn = Regex.Replace(line, @"\D+", "");
           return isbn;
        }

        return line;
    }
}

