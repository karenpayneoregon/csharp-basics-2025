using ChinookTreeViewSample.Classes;
using Spectre.Console;

namespace ChinookTreeViewSample;
internal partial class Program
{
    static void Main(string[] args)
    {
        var albums = DataOperations.Album();

        foreach (var album in albums)
        {
            var tree = new Tree($"[cyan bold]{album.Title.ConsoleEscape()}[/]");
            foreach (var track in album.Tracks.OrderBy(t => t.TrackName))
            {
                tree.AddNode($"[DarkSeaGreen]{track.TrackName.ConsoleEscape()}[/]");
            }

            AnsiConsole.Write(tree);
        }
        
        
        SpectreConsoleHelpers.ExitPrompt();
    }
}
