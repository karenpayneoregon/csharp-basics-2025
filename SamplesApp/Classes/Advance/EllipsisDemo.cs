using SamplesApp.Classes.Extensions;
using Spectre.Console;

namespace SamplesApp.Classes.Advance;
internal class EllipsisDemo
{
    public EllipsisDemo()
    {
        var products = MockedData.CreateProducts();
        foreach (var p in products)
        {
            if (p.Price < 50)
            {
                AnsiConsole.MarkupLine($"[green]{p.Name.Ellipsis(15)}[/][yellow]{p.Price.EllipsisFormattable(15):C}on sale[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[green]{p.Name.Ellipsis(15)}[/][cyan]{p.Price.EllipsisFormattable(15):C}not on sale[/]");

            }
        }
    }
}

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
}

public class MockedData
{
    public static List<Product> CreateProducts()
        =>
        [
            new Product { Id = 1, Name = "Laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Keyboard", Price = 49.50m },
            new Product { Id = 3, Name = "Mouse", Price = 29.99m },
            new Product { Id = 4, Name = "Monitor", Price = 199.00m },
            new Product { Id = 5, Name = "Headphones", Price = 89.75m }
        ];

}

