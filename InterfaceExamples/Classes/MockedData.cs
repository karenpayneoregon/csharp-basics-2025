using InterfaceExamples.Interfaces;
using InterfaceExamples.Modals;

namespace InterfaceExamples.Classes;
internal class MockedData
{
    /// <summary>
    /// Gets a static list of <see cref="IPerson"/> objects representing mocked client and person data.
    /// </summary>
    /// <remarks>
    /// The list includes instances of <see cref="Client"/> and <see cref="Person"/> with predefined properties.
    /// </remarks>
    internal static List<IPerson> ClientPersons
        =>
        [
            new Client { Id = 1, FirstName = "Alice", LastName = "Johnson", Gender = Gender.Female },
            new Client { Id = 2, FirstName = "Bob", LastName = "Smith", Gender = Gender.Male },
            new Person { Id = 3, FirstName = "Charlie", LastName = "Brown", Gender = Gender.Male },
            new Person { Id = 4, FirstName = "Diana", LastName = "Lopez", Gender = Gender.Female }
        ];
}
