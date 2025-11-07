using CommonHelpersLibrary;

namespace SamplesApp.Classes;
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
        var numbers = new List<int> { 1, 2, 3 };
        var single = new[] { "OnlyOne" };
        var empty = Array.Empty<string>();

        Console.WriteLine(names.JoinWithLastSeparator());
        Console.WriteLine(numbers.JoinWithLastSeparator(" | ", "or"));
        Console.WriteLine(single.JoinWithLastSeparator());
        Console.WriteLine($"[{empty.JoinWithLastSeparator()}]");
    }
}
