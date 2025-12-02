using ByRefExamples.Classes.Configuration;
using System.ComponentModel;
using ByRefExamples.Classes;
using ByRefExamples.Models;
using Spectre.Console;
using static SpectreConsoleLibrary.SpectreConsoleHelpers;

namespace ByRefExamples;
internal partial class Program
{
    /// <summary>
    ///  - By value: You can modify the object’s contents but not which object the caller refers to.
    ///  - By ref: You can modify both the object’s contents and the caller’s reference itself.
    /// </summary>
    static void Main(string[] args)
    {

        // By value
        Person person = new() { Name = "John" };
        PersonOperations.ChangePerson(person);
        AnsiConsole.MarkupLine($"[yellow]By val[/] [cyan]{person.Name}[/]");  // Output: Alice

        Console.WriteLine();

        // By ref
        person = new() { Name = "John" };
        PersonOperations.ChangePersonByRef(ref person);
        AnsiConsole.MarkupLine($"[yellow]By ref[/] [cyan]{person.Name}[/]");  // Output: Bob
        ExitPrompt();
    }

    
}


