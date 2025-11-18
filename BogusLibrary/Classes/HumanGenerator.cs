using Bogus;
using Bogus.DataSets;
using BogusLibrary.Models;
using static Bogus.Randomizer;

namespace BogusLibrary.Classes;

public class HumanGenerator
{
    /// <summary>
    /// Generates a list of <see cref="Human"/> objects with randomly populated data.
    /// </summary>
    /// <param name="count">
    /// The number of <see cref="Human"/> objects to generate.
    /// </param>
    /// <param name="random">
    /// A boolean value indicating whether to use a random seed for data generation.
    /// If <c>false</c>, a fixed seed is used to ensure deterministic results.
    /// </param>
    /// <returns>
    /// A list of <see cref="Human"/> objects populated with realistic, randomized data.
    /// </returns>
    /// <remarks>
    /// This method leverages the Bogus library to generate realistic data for <see cref="Human"/> objects.
    /// Each generated <see cref="Human"/> includes properties such as name, gender, birthdate, email, 
    /// social security number, and address.
    /// </remarks>
    public static List<Human> Create(int count, bool random = false)
    {
        if (!random)
        {
            Seed = new Random(338);
        }

        var id = 1;

        var faker = new Faker<Human>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.FirstName, (f, u) => f.Name.FirstName((Name.Gender?)u.Gender))
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDay, f => f.Person.DateOfBirth)
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
            .RuleFor(c => c.Gender, f => f.PickRandom<Gender>())
            .RuleFor(p => p.SocialSecurityNumber, f => f.Random.Replace("###-##-####").Replace("-",""))
            .RuleFor(p => p.Address, f => AddressGenerator.Create().FirstOrDefault());

        return faker.Generate(count);

    }
  
}

