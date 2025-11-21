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


        //var line = "\\\\SomeServer\\HTTP\\FolderName\\data.txt 4 KB TXT " +
        //           "File 02/19/2019 3:48:21 PM " +
        //           "2/19/2019 1:05:53 PM 2/19/2019 1:05:53 PM 5";

        //var dates = DateTimeExtractor.GetAllDateTimes(line);

        //foreach (var d in dates)
        //{
        //    Console.WriteLine(d);
        //}
        
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

