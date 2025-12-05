using BogusLibrary.Classes;
using BogusLibrary.Models;
using System.Diagnostics;
using System.Text.Json;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        ImplicitOperator();
        GenerateAndProcessData();

        Console.ReadLine();
    }

    
    private static void GenerateAndProcessData()
    {
        var list = HumanGenerator.Create(3);
        var products = ProductGenerator.Create(12);
        var categories = CategoryGenerator.Create(3);
        var users = UserGenerator.Create(5);

        File.WriteAllText("humans.json", JsonGenerator.HumansAsJson(10));
        var humans = JsonSerializer.Deserialize<List<Human>>(File.ReadAllText("humans.json"));
    }

    /// <summary>
    /// Demonstrates the usage of the implicit operator to convert a collection of 
    /// <see cref="BogusLibrary.Models.Products"/> instances into a collection of 
    /// <see cref="BogusLibrary.Models.ProductItem"/> instances.
    /// </summary>
    /// <remarks>
    /// This method utilizes the implicit conversion defined in the <see cref="BogusLibrary.Models.ProductItem"/> class
    /// to seamlessly transform <see cref="BogusLibrary.Models.Products"/> objects into <see cref="BogusLibrary.Models.ProductItem"/> objects.
    /// The resulting collection is then processed further.
    /// </remarks>
    private static void ImplicitOperator()
    {

        List<ProductItem> products = ProductGenerator.Create(10)
            .Select<Products, ProductItem>(p => p)
            .ToList();

        Debugger.Break();
    }
    
    /// <summary>
    /// Checks the value of a nullable integer and prints its state to the console.
    /// </summary>
    /// <remarks>
    /// This method demonstrates three different ways to check and handle the value of a nullable integer:
    /// <list type="bullet">
    /// <item>Using the <see cref="Nullable{T}.HasValue"/> property.</item>
    /// <item>Using pattern matching with the <c>is</c> keyword.</item>
    /// <item>Using pattern matching with a property pattern.</item>
    /// </list>
    /// </remarks>
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
