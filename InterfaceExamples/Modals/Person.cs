#nullable disable

using System.ComponentModel;
using InterfaceExamples.Interfaces;

namespace InterfaceExamples.Modals;

/// <summary>
/// Represents a person with basic identifying properties such as ID, first name, last name, and gender.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IPerson"/> interface and the <see cref="INotifyPropertyChanged"/> interface.
/// It provides a concrete representation of a person and supports property change notifications.
/// </remarks>
public partial class Person : IPerson, INotifyPropertyChanged
{
    public partial int Id { get; set; }
    public partial string FirstName { get; set; }
    public partial string LastName { get; set; }
    public partial Gender? Gender { get; set; }
}
