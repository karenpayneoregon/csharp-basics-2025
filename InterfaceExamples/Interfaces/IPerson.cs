using InterfaceExamples.Modals;

namespace InterfaceExamples.Interfaces;

/// <summary>
/// Represents a person with basic identifying properties such as ID, first name, last name, and gender.
/// </summary>
/// <remarks>
/// This interface is implemented by classes such as <see cref="Modals.Person"/> and 
/// <see cref="Modals.Client"/> to provide a unified representation of a person.
/// </remarks>
public interface IPerson
{
    int Id { get; set; }
    string? FirstName { get; set; }
    string? LastName { get; set; }
    Gender? Gender { get; set; }
}