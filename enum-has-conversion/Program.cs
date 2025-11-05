using EnumHasConversion.Classes;
using PayneServiceLibrary;
using SpectreConsoleLibrary;

namespace EnumHasConversion;

internal partial class Program
{

    private static async Task Main()
    {
        await MainConfiguration.Setup();
        await WineOperations.GetAllWines();

        SpectreConsoleHelpers.ExitPrompt();

    }
}