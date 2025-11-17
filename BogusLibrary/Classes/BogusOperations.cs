using Bogus;
using Bogus.DataSets;
using BogusLibrary.Models;
using static Bogus.Randomizer;

namespace BogusLibrary.Classes;

public class BogusOperations
{
    public static List<Human> GenerateHumans(int count, bool random = false)
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
            .RuleFor(p => p.Address, f => AddressGenerator.Create(1).FirstOrDefault());


        return faker.Generate(count);

    }

  
}

