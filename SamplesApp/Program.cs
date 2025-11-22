using Spectre.Console;
using SamplesApp.Classes.Extensions;

namespace SamplesApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        int intValue = 12;
        Console.WriteLine(intValue.Clamp(1, 10));

        decimal decimalValue = 15.5m;
        Console.WriteLine(decimalValue.Clamp(1, 12));


        int? someValue = null;
        Console.WriteLine(someValue is not null ?
            "Has value" : 
            "Has no value");

        SpectreConsoleHelpers.ExitPrompt();
    }

}




