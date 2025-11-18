using BogusLibrary.Classes;
using BogusLibrary.Models;
using CommonHelpersLibrary;
using Spectre.Console;

namespace SamplesApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        IfGenderStatement();
        SpectreConsoleHelpers.ExitPrompt();
    }

    private static void DisplayHumanDetails()
    {
        SpectreConsoleHelpers.PrintPink();
        
        List<Human> humans = HumanGenerator.Create(20);
        foreach (var human in humans)
        {
            Console.WriteLine($"Name: {human.FirstName, -20} {human.LastName,-20}{human.Gender,-7}{human.BirthDay:d}  {human.SocialSecurityNumber}");
            Console.WriteLine($"\t{human.Address.Street}, {human.Address.City}, {human.Address.State} {human.Address.ZipCode}, {human.Address.Country}");
            SpectreConsoleHelpers.LineSeparator();
        }
    }

    private static void IfGenderStatement()
    {

        SpectreConsoleHelpers.PrintPink();
        
        List<Human> humans = HumanGenerator.Create(20);

        foreach (var human in humans)
        {
            
            if (human.Gender != Gender.Female) continue;
            
            if (string.Equals(human.FirstName, "bertha", StringComparison.OrdinalIgnoreCase))
            {
                AnsiConsole.MarkupLine($"[cyan]Found Bertha[/]: {human.FirstName} {human.LastName}");
            }
            else
            {
                AnsiConsole.MarkupLine($"[grey]Female Name:[/]: {human.FirstName} {human.LastName}");
            }
            
        }
    }

    private static void IfBirthYearStatement()
    {
        SpectreConsoleHelpers.PrintPink();
        
        List<Human> humans = HumanGenerator.Create(20);

        foreach (var human in humans)
        {
            if (human.BirthDay.HasValue)
            {
                var year = human.BirthDay.Value.Year;

                if (year >= 1950 && year <= 1980 )
                {
                    Console.WriteLine($"{human.FirstName,-15}{human.LastName,-15}{human.BirthDay, -12:MM/dd/yyyy}{human.BirthDay.GetAge()}");
                }
            }
        }
    }
}

