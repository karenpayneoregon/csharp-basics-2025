using Bogus;
using BogusLibrary.Models;
using static Bogus.Randomizer;

namespace BogusLibrary.Classes;

/// <summary>
/// Provides functionality for generating a list of <see cref="User"/> objects with realistic, randomized data.
/// </summary>
/// <remarks>
/// This class utilizes the Bogus library to create <see cref="User"/> objects with properties such as ID, name, and password.
/// It supports both deterministic and non-deterministic data generation based on the provided seed configuration.
/// </remarks>
public static class UserGenerator
{
    /// <summary>
    /// Generates a list of <see cref="User"/> objects with realistic, randomized data.
    /// </summary>
    /// <param name="count">
    /// The number of <see cref="User"/> objects to generate.
    /// </param>
    /// <param name="random">
    /// A boolean value indicating whether to use a random seed for data generation.
    /// If <c>false</c>, a fixed seed is used to ensure deterministic results.
    /// </param>
    /// <returns>
    /// A list of <see cref="User"/> objects populated with realistic, randomized data.
    /// </returns>
    /// <remarks>
    /// This method leverages the Bogus library to generate realistic data for <see cref="User"/> objects.
    /// Each generated <see cref="User"/> includes properties such as ID, name, and password.
    /// </remarks>
    public static List<User> Create(int count, bool random = false)
    {
        if (count <= 0)
            return new List<User>();

        Seed = !random ? new Random(338) : null;

        var faker = new Faker<User>()
            .StrictMode(true)
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Password, f => f.Internet.Password());

        return faker.Generate(count);
    }
}