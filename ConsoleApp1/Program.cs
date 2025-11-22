using BogusLibrary.Classes;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        var list = HumanGenerator.Create(3);
        var products = ProductGenerator.Create(12);
        var categories = CategoryGenerator.Create(3);
        var users = UserGenerator.Create(5);
        Console.ReadLine();
    }

    private static void CheckNullableIntValue()
    {
        int? maybe = 12;

        if (maybe.HasValue)
        {
            Console.WriteLine($"The nullable int 'maybe' has the value {maybe.Value}");
        }
        else
        {
            Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
        }

        {
            if (maybe is int number)
            {
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            }
            else
            {
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }
        }

        {
            if (maybe is { } number)
            {
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            }
            else
            {
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }
        }
    }
}
