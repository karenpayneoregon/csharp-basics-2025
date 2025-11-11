using EnumHasConversion.Data;
using EnumHasConversion.Models;

namespace EnumHasConversion.Classes;

public class WineOperations
{

    public static async Task GetAllWines()
    {
        await using var context = new WineContext();

        var allWines = context.Wines.ToList();


        foreach (var wine in allWines)
        {
            AnsiConsole.MarkupLine($"[cyan]{wine.WineType,-8}[/]{wine.Name}");
        }
    }

}
