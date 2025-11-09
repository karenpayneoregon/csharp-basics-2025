using CommonHelpersLibrary;
using Spectre.Console;

namespace SamplesApp.Classes.Intermediate;
internal class StringSamples
{
    /// <summary>
    /// Demonstrates the usage of the <see cref="CommonHelpersLibrary.StringExtensions.JoinWithLastSeparator{T}"/> 
    /// extension method by joining various collections into formatted strings and printing the results.
    /// </summary>
    /// <remarks>
    /// This method showcases how to use the <c>JoinWithLastSeparator</c> extension method with different 
    /// types of collections, including arrays and lists, and with various separator and token configurations.
    /// </remarks>
    public static void JoinExample()
    {
        var names = new[] { "Alice", "Bob", "Charlie", "Diana" };
        List<string>? names1 = null;
        var numbers = new List<int> { 1, 2, 3 };
        var single = new[] { "OnlyOne" };
        var empty = Array.Empty<string>();

        Console.WriteLine(names.JoinWithLastSeparator());
        
        if (names1 is not null)
        {
            Console.WriteLine(names1.JoinWithLastSeparator());
        }
        else
        {
            AnsiConsole.MarkupLine("[red bold]names1 is null.[/]");
        }
        
        Console.WriteLine(numbers.JoinWithLastSeparator(" | ", "or"));
        Console.WriteLine(single.JoinWithLastSeparator());
        Console.WriteLine($"[{empty.JoinWithLastSeparator()}]");
    }
}
