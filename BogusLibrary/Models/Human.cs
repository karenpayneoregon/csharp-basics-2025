using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BogusLibrary.Models;

public class Human : INotifyPropertyChanged
{
    private int _id;
    public int Id { get => _id; set => SetField(ref _id, value); }

    private string _firstName;
    public string FirstName { get => _firstName; set => SetField(ref _firstName, value); }

    private string _lastName;
    public string LastName { get => _lastName; set => SetField(ref _lastName, value); }
    
    private DateTime? _birthDay;
    public DateTime? BirthDay { get => _birthDay; set => SetField(ref _birthDay, value); }
    
    private DateOnly _birthDate;
    public DateOnly BirthDate { get => _birthDate; set => SetField(ref _birthDate, value); }

    private string _email;
    public string Email { get => _email; set => SetField(ref _email, value); }
    
    private Gender? _gender;
    public Gender? Gender { get => _gender; set => SetField(ref _gender, value); }
    
    private string _socialSecurityNumber;
    public string SocialSecurityNumber { get => _socialSecurityNumber; set => SetField(ref _socialSecurityNumber, value); }
    
    private Address _address;
    public Address Address { get => _address; set => SetField(ref _address, value); }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Updates the specified field with a new value and raises the <see cref="PropertyChanged"/> event
    /// if the value has changed.
    /// </summary>
    /// <typeparam name="T">The type of the field being updated.</typeparam>
    /// <param name="field">A reference to the field to be updated.</param>
    /// <param name="value">The new value to assign to the field.</param>
    /// <param name="propertyName">
    /// The name of the property that corresponds to the field. This parameter is optional and is
    /// automatically provided by the compiler if not explicitly specified.
    /// </param>
    /// <returns>
    /// <c>true</c> if the field was updated and the <see cref="PropertyChanged"/> event was raised;
    /// otherwise, <c>false</c>.
    /// </returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}