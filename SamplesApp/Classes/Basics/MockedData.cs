using System.Text.Json;

namespace SamplesApp.Classes.Basics;
internal class MockedData
{

    public static decimal[] GetDecimals()
        =>
        [
            99.40m, 98.62m, 98.13m, 96.31m, 85.59m, 78.95m, 62.73m, 58.23m, 57.36m, 57.03m,
            50.41m, 49.46m, 35.86m, 30.07m, 29.84m, 27.56m, 25.73m, 17.10m, 13.95m, 10.32m
        ];

    public static void WriteDecimalsToJson(string filePath, decimal[] values)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(values, options);
        File.WriteAllText(filePath, json);
    }

    public static decimal[] ReadDecimalsFromJson(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("JSON file not found.", filePath);

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<decimal[]>(json)
               ?? throw new InvalidDataException("Failed to deserialize decimal array.");
    }

    public static JsonSerializerOptions JsonSerializerOptions 
        => new() { WriteIndented = true };
}



