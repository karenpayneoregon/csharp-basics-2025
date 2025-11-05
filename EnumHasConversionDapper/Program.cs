using EnumHasConversionDapper.Classes;
using SpectreConsoleLibrary;


namespace EnumHasConversionDapper;

internal partial class Program
{
    static void Main(string[] args)
    {
        WineOperations operations = new();
        var wines = operations.AllWines();
        Present(wines, "All wines ORDER BY Name, WineType");

        SpectreConsoleHelpers.ExitPrompt();
    }
}

