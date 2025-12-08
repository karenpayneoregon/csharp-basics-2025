namespace ExperimentsApp.Models;

/// <summary>
/// Represents a grouping of members by a specific key, which includes a name and surname.
/// </summary>
/// <param name="Key">
/// The grouping key, consisting of a tuple with the name and surname of the members.
/// </param>
/// <param name="Members">
/// A list of <see cref="Member"/> objects that belong to the group identified by the key.
/// </param>
public record GroupedMembers((string Name, string Surname) Key, List<Member> Members);