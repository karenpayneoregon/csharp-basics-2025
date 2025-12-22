using System.Diagnostics.CodeAnalysis;

namespace SamplesApp.Models;

/// <summary>
/// Represents an individual with personal details.
/// </summary>
/// <param name="FirstName">The given name of the individual.</param>
/// <param name="LastName">The family name of the individual.</param>
/// <param name="BirthDate">The date of birth of the individual.</param>
/// <remarks>
/// For more details, visit: https://gist.github.com/karenpayneoregon/b67cac5cbbd9ce899d322e097098c8e7s
/// </remarks>
/// <example>
/// <code>
/// var person = new Person("John", "Doe", new DateOnly(1985, 10, 25));
/// </code>
/// </example>
[method: SetsRequiredMembers]
public record Person(string FirstName, string LastName, DateOnly BirthDate)
{
    public int Id { get; set; }
    public required string FirstName { get; set; } = FirstName;
    public required string LastName { get; set; } = LastName;
    public required DateOnly BirthDate { get; set; } = BirthDate;
}
