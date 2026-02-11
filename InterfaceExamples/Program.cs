using InterfaceExamples.Classes;
using InterfaceExamples.Interfaces;
using InterfaceExamples.Modals;
using Spectre.Console;
using SpectreConsoleLibrary;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static SpectreConsoleLibrary.SpectreConsoleHelpers;

namespace InterfaceExamples;
internal partial class Program
{

    static void Main(string[] args)
    {

        //Basics();
        //FilterByModal();
        //GroupByGender();



        ExitPrompt();
    }

    /// <summary>
    /// Demonstrates basic functionality by iterating through a list of objects
    /// implementing the <see cref="InterfaceExamples.Interfaces.IPerson"/> interface
    /// and displaying their details in the console.
    /// </summary>
    /// <remarks>
    /// This method differentiates between objects of type <see cref="InterfaceExamples.Modals.Person"/>
    /// and <see cref="InterfaceExamples.Modals.Client"/>, and outputs their respective
    /// first and last names using Spectre.Console for formatted console output.
    /// </remarks>
    private static void Basics()
    {

        PrintPink();

        var list = MockedData.ClientPersons;

        foreach (var item in list)
        {
            if (item is Person person)
            {
                AnsiConsole.MarkupLine($"[yellow]Person:[/] {person.FirstName, -10} {person.LastName, -10}{person.Gender}");
            }
            else if (item is Client client)
            {
                AnsiConsole.MarkupLine($"[green]Client:[/] {client.FirstName, -10} {client.LastName, -10} {client.Gender,-10} {client.Active}");
            }
        }
    }

    /// <summary>
    /// Filters and processes a collection of client and person objects.
    /// </summary>
    /// <remarks>
    /// This method utilizes two helper methods, <c>FilterClients</c> and <c>FilterPerson</c>, 
    /// to filter a collection of <see cref="IPerson"/> objects into clients and persons respectively.
    /// The filtered results are then processed further.
    /// </remarks>
    private static void FilterByModal()
    {
        var clients = FilterClients(MockedData.ClientPersons);
        var people = FilterPerson(MockedData.ClientPersons);

        Debugger.Break();

    }

    /// <summary>
    /// Groups a collection of people by their gender and displays the grouped data.
    /// </summary>
    /// <remarks>
    /// This method retrieves a list of people, groups them by their gender, 
    /// and prints the results to the console using Spectre.Console for formatting.
    /// </remarks>
    private static void GroupByGender()
    {
        PrintPink();
        
        var people = MockedData.ClientPersons;
        var groups = people.GroupBy(p => p.Gender);

        foreach (var group in groups)
        {
            AnsiConsole.MarkupLine($"\n[yellow]Gender:[/] {group.Key}");
            foreach (var person in group)
                Console.WriteLine($" - {person.FirstName} {person.LastName} ({person.GetType().Name})");
        }
    }

    /// <summary>
    /// Filters a collection of <see cref="IPerson"/> objects, returning only those that are of type <see cref="Person"/>.
    /// </summary>
    /// <param name="people">The collection of <see cref="IPerson"/> objects to filter.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the objects of type <see cref="Person"/>.</returns>
    private static IEnumerable<IPerson> FilterPerson(IEnumerable<IPerson> people) 
        => people.Where(p => p is Person);
    
    /// <summary>
    /// Filters a collection of <see cref="IPerson"/> objects to include only those that are of type <see cref="Client"/>.
    /// </summary>
    /// <param name="people">The collection of <see cref="IPerson"/> objects to filter.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the <see cref="Client"/> objects from the input collection.</returns>
    private static IEnumerable<IPerson> FilterClients(IEnumerable<IPerson> people) 
        => people.Where(p => p is Client);
    
  
}

