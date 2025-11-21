using System.Globalization;
using System.Text.RegularExpressions;

namespace SamplesApp.Classes.Advance;
internal class DateTimeExtractor
{

    public static List<DateTime> GetAllDateTimes(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return [];

        // Matches both "02/19/2019 3:48:21 PM" and "2/19/2019 1:05:53 PM"
        string pattern = @"\b\d{1,2}/\d{1,2}/\d{4}\s+\d{1,2}:\d{2}:\d{2}\s+(AM|PM)\b";

        var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
        var results = new List<DateTime>();

        foreach (Match match in matches)
        {
            if (DateTime.TryParseExact(match.Value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
            {
                results.Add(dt);
            }
            else if (DateTime.TryParse(match.Value, out dt))
            {
                // Fallback just in case
                results.Add(dt);
            }
        }

        return results;
        
    }
    
}
