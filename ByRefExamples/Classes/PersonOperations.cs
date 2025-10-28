using ByRefExamples.Models;

namespace ByRefExamples.Classes;
internal class PersonOperations
{
    public static void ChangePersonByRef(ref Person p)
    {
        p.Name = "Alice";                   // modifies existing object
        p = new Person { Name = "Bob" };    // replaces caller’s reference
    }
    public static void ChangePerson(Person p)
    {
        p.Name = "Alice";                   // modifies the same object
        p = new Person { Name = "Bob" };    // reassigns local copy only
    }
}
