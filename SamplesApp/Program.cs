using BogusLibrary.Classes;
using BogusLibrary.Models;
using CommonHelpersLibrary;
using SamplesApp.Classes.Advance;
using SamplesApp.Classes.StatementsBasics;
using Spectre.Console;

namespace SamplesApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        BasicStatements.IfBirthYearStatementBasic();
        SpectreConsoleHelpers.ExitPrompt();
    }

    private static void YieldSamples()
    {
        foreach (int number in BasicStatements.GetNumbersUpToTenYieldBasic(20))
        {
            Console.WriteLine(number);
        }

        foreach (var human in BasicStatements.GetFirstMale())
        {
            Console.WriteLine($"Name: {human.FirstName} {human.LastName}");
        }
    }
}

