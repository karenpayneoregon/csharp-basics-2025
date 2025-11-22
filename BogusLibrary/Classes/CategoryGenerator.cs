using Bogus;
using BogusLibrary.Models;
using static Bogus.Randomizer;

namespace BogusLibrary.Classes;

public class CategoryGenerator
{

    public static List<Categories> Create(int count, bool random = false)
    {
        if (count <= 0)
            return new List<Categories>();

        // deterministic output
        Seed = !random ? new Random(338) : null;
        
        var faker = new Faker<Categories>()
            .StrictMode(true)
            .RuleFor(c => c.CategoryId, f => f.IndexFaker + 1) // sequential IDs
            .RuleFor(c => c.CategoryName, f => f.Commerce.Categories(1).First())
            .RuleFor(c => c.Products, f => new HashSet<Products>()); // always empty

        return faker.Generate(count);
    }
}