using Spectre.Console;
using SamplesApp.Classes.Extensions;
using SamplesApp.Classes.StatementsBasics;

namespace SamplesApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        BasicStatements.IfBirthYearStatementTeachVersion();

        int intValue = 12;
        Console.WriteLine(intValue.Clamp(1, 10));

        decimal decimalValue = 15.5m;
        Console.WriteLine(decimalValue.Clamp(1, 12));

        SpectreConsoleHelpers.ExitPrompt();
    }

}




