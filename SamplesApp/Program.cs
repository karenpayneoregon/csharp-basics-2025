using SamplesApp.Classes.Extensions;
using SamplesApp.Classes.StatementsBasics;
using Spectre.Console;
using System.Globalization;

namespace SamplesApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        //BasicStatements.IfBirthYearStatementTeachVersion();
        //ClampedValues();
        //IsEvenDemo();



        SpectreConsoleHelpers.ExitPrompt();
    }

    private static void IsEvenDemo()
    {
        var months = DateTimeFormatInfo.CurrentInfo.MonthNames[..^1].ToList();

        AnsiConsole.MarkupLine("[cyan]Cyan[/] are even");
        
        int count = 0;
        foreach (var (index, monthName) in months.Index())
        {

            if (index % 2 == 0)
            {
                AnsiConsole.MarkupLine($"[cyan]{index + 1,-4}{monthName}[/]");
                count += index;
            }
            else
            {
                Console.WriteLine($"{index + 1,-4}{monthName}");
            }

        }

        Console.WriteLine($"Count of even months: {count}");
    }

    private static void ClampedValues()
    {
        int intValue = 12;
        AnsiConsole.MarkupLine($":diamond_with_a_dot:     int clamp {intValue.Clamp(1, 10)}");

        decimal decimalValue = 15.5m;
        AnsiConsole.MarkupLine($":diamond_with_a_dot: decimal clamp {decimalValue.Clamp(1, 12)}");
    }
}




