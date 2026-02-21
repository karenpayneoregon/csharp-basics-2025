using ReleaseServiceApp.Classes;
using ReleaseServiceApp.Classes.Core;
using Spectre.Console;

namespace ReleaseServiceApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        var releases = await DotNetReleaseService.GetReleaseIndexAsync();

        SpectreConsoleHelpers.InfoPill(Justify.Left, $"Found {releases.Count} releases.");
        Console.WriteLine();
        
        var table = new Table().Title("[bold blue] .NET Release Information [/]");
        table.AddColumn(new TableColumn("[bold yellow]Channel[/]"));
        table.AddColumn(new TableColumn("[bold yellow]Latest[/]"));
        table.AddColumn(new TableColumn("[bold yellow]Support[/]"));

        foreach (var item in releases)
        {
            table.AddRow(
                item.ChannelVersion ?? "", 
                item.LatestRelease ?? "", 
                Colorize(item.SupportPhase ?? "Unknown"));
        }

        AnsiConsole.Write(table);
        Console.WriteLine();
        
        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }
    
    private static string Colorize(string input)
    {
        return input switch
        {
            { } s when s.Contains("active", StringComparison.OrdinalIgnoreCase) => "[green]Active[/]",
            { } s when s.Contains("eol", StringComparison.OrdinalIgnoreCase) => "[red]eol[/]",
            { } s when s.Contains("preview", StringComparison.OrdinalIgnoreCase) => "[yellow]preview[/]",
            _ => input,
        };
    }
}
