#nullable disable
using System.ComponentModel;
using InterfaceExamples.Interfaces;

namespace InterfaceExamples.Modals;

/// <summary>
/// Represents a client entity with properties such as ID, first name, last name, and gender.
/// </summary>
/// <remarks>
/// This class implements the <see cref="INotifyPropertyChanged"/> interface to support property change notifications
/// and the <see cref="IPerson"/> interface to provide a unified representation of a person.
/// </remarks>
public partial class Client : INotifyPropertyChanged, IPerson
{
    public partial int Id { get; set; }

    public partial string FirstName { get; set; }
    public partial string LastName { get; set; }
    public partial Gender? Gender { get; set; }
}

