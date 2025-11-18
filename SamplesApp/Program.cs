using BogusLibrary.Classes;
using BogusLibrary.Models;
using CommonHelpersLibrary;
using SamplesApp.Classes.StatementsBasics;
using Spectre.Console;

namespace SamplesApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        BasicStatements.IfBirthYearStatementBasic();

        foreach (int number in BasicStatements.GetNumbersUpToTenYieldBasic(20))
        {
            Console.WriteLine(number);
        }
        
        SpectreConsoleHelpers.ExitPrompt();
    }


}

