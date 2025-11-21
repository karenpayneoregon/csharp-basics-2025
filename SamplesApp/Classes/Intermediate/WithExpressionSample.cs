using Bogus;
using static Bogus.Randomizer;

namespace SamplesApp.Classes.Intermediate;
internal class WithExpressionSample
{
    /// <summary>
    /// Demonstrates the use of the `with` expression to create new instances of the <see cref="Product"/> record 
    /// with modified properties based on an existing instance.
    /// </summary>
    /// <remarks>
    /// This method initializes a list of products and a dictionary of fruits. It creates a base product instance 
    /// and then iterates through the dictionary to add new products to the list by modifying the base product's 
    /// properties using the `with` expression.
    /// 
    /// Additionally, it performs a join operation between the products and categories, displaying the results 
    /// in a formatted output.
    /// </remarks>
    public static void ProductsExample1()
    {
        // Generates sample products and categories
        var (products, categories) = MockedData.GetProductsAndCategories();

        Dictionary<int, string> fruits = new()
        {
            [2] = "Golf",
            [3] = "Formula 1 racing",
            [4] = "Soccer"
        };

        Product apples = new(1, "Football", 2);
        products.Add(apples);

        foreach (var fruit in fruits)
        {
            products.Add(apples with { Id = fruit.Key, Name = fruit.Value });
        }
        
        var joined =
            products.Join(
                categories,
                p => p.CategoryId,
                c => c.Id,
                (p, c) => new
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    CategoryName = c.Name
                });

        foreach (var item in joined)
        {
            Console.WriteLine($"{item.ProductId, -3}: {item.ProductName, -20}{item.CategoryName}");
        }

    }
}
public record Product(int Id, string Name, int CategoryId)
{
    
    public int Id { get; set; } = Id;
    public string Name { get; set; } = Name;
    public int CategoryId { get; set; } = CategoryId;
}

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

public class MockedData
{
    public static (List<Product> products, List<Category> categories) GetProductsAndCategories()
    {
        
        Seed = new Random(334);
        
        var categoryFaker = new Faker<Category>()
            .RuleFor(c => c.Id, f => f.IndexFaker + 1)
            .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);

        var categories = categoryFaker.Generate(3);
        
        return ([], categories);
    }
}
