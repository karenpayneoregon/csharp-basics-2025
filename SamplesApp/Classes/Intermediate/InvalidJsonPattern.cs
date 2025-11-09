namespace SamplesApp.Classes.Intermediate;

/// <summary>
/// Invalid JSON pattern (JSON001)
/// https://learn.microsoft.com/en-us/visualstudio/ide/reference/json001?toc=%2Fdotnet%2Fnavigate%2Ftools-diagnostics%2Ftoc.json&bc=%2Fdotnet%2Fbreadcrumb%2Ftoc.json&view=vs-2022
/// </summary>
internal class InvalidJsonPattern
{
    /// <summary>
    /// Demonstrates the usage of multi-line raw string literals to define JSON strings
    /// and outputs them to the console.
    /// This example highlights the use of the raw string literal syntax introduced in C# 11,
    /// which allows for easier definition of multi-line strings without the need for escape characters.
    /// It includes two JSON string examples: one with a standard raw string literal and another
    /// with an embedded comment indicating the JSON language type.
    /// The method then outputs these JSON strings to the console for verification and demonstration purposes.
    /// </summary>
    public static void Example1()
    {
        //lang=json
        const string json = 
            """
            {
               "pie": true, 
               "cherry": [1, 2, 3]
            }
            """;


        const string json1 = """
                /*lang=json*/
                {
                   "pie": true, 
                   "cherry": [1, 2, 3]
                }
                """;

        Console.WriteLine(json);
        Console.WriteLine(json1);
    }
    
    /// <summary>
    /// Demonstrates the usage of multi-line raw string literals with embedded comments
    /// to define JSON strings and outputs them to the console.
    /// This example showcases the use of the raw string literal syntax introduced in C# 11,
    /// including the application of JSON language type comments for strict validation.
    /// It includes two JSON string examples: one with a standard raw string literal and another
    /// with an embedded comment specifying strict JSON validation.
    /// The method then outputs these JSON strings to the console for verification and demonstration purposes.
    /// </summary>
    public static void Example2()
    {
        // Fixed code
        // lang=json,strict
        var json1 = 
            """
            { 
                "pie": true, 
                "cherry": [1, 2, 3] }
            """;

        // Fixed code
        var json2 = /*lang=json,strict*/ 
            """
            { 
                "pie": true, 
                "cherry": [1, 2, 3] }
            """;

        Console.WriteLine(json1);
        Console.WriteLine(json2);
    }
}
