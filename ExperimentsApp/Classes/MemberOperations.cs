using ExperimentsApp.Models;
using System.Diagnostics;

namespace ExperimentsApp.Classes;

public class MemberOperations
{
    /// <summary>
    /// Retrieves a list of members with predefined attributes.
    /// </summary>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="Member"/> objects, 
    /// each representing a member with properties such as Id, Active status, Name, and Surname.
    /// </returns>
    public static IEnumerable<Member> MembersList() =>
        new List<Member>()
        {
            new() { Id = 1, Active = true,  Name = "Mary", Surname = "Adams" },
            new() { Id = 2, Active = false, Name = "Sue", Surname = "Williams" },
            new() { Id = 3, Active = true,  Name = "Jake", Surname = "Burns" },
            new() { Id = 4, Active = true,  Name = "Jake", Surname = "Burns" },
            new() { Id = 5, Active = true,  Name = "Clair", Surname = "Smith" },
            new() { Id = 6, Active = true,  Name = "Mary", Surname = "Adams" },
        };

    /// <summary>
    /// Groups active members by their name and surname.
    /// For converting to strong type
    /// </summary>
    /// <param name="list">The list of members to group.</param>
    public static void GroupedMembers(IEnumerable<Member> list)
    {
        var grouped = list
            .Where(member => member.Active)
            .GroupBy(member => (member.Name, member.Surname))
            .Select(item => new { item.Key, Members = item.ToList() })
            .ToList();
        
        
        foreach (var group in grouped)
        {
            Debug.WriteLine($"Group: {group.Key.Name} {group.Key.Surname}");
            foreach (var member in group.Members)
            {
                Debug.WriteLine($"  - ID: {member.Id}, Active: {member.Active}");
            }
        }
        
    }
}