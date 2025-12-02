using SamplesApp.Classes.Extensions;
using SamplesApp.Classes.StatementsBasics;
using Spectre.Console;

namespace SamplesApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        BasicStatements.IfBirthYearStatementTeachVersion();

        Console.WriteLine();
        
        int intValue = 12;
        AnsiConsole.MarkupLine($":diamond_with_a_dot:     int clamp {intValue.Clamp(1, 10)}");

        decimal decimalValue = 15.5m;
        AnsiConsole.MarkupLine($":diamond_with_a_dot: decimal clamp {decimalValue.Clamp(1, 12)}");

        SpectreConsoleHelpers.ExitPrompt();
    }

}




