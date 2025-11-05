using EnumHasConversionDapper.Models;
using System.Reflection;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace EnumHasConversionDapper;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        var assembly = Assembly.GetEntryAssembly();
        var product = assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        Console.Title = product!;
        
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    /// <summary>
    /// Display all wines in list
    /// </summary>
    /// <param name="list">List of <see cref="Wine"/></param>
    /// <param name="description">Text to display</param>
    private static void Present(List<Wine> list, string description)
    {
        AnsiConsole.MarkupLine($"[cyan]{description}[/]");
        foreach (var wine in list)
        {
            AnsiConsole.MarkupLine($"    [white]{wine.Name,-30}[/] [yellow]{wine.WineType}[/]");
        }

        Console.WriteLine();
    }
}
