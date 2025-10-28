

using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Models;

namespace NorthWind2024LocalLibrary.Classes;

/// <summary>
/// Provides utility methods for generating default selection options for dropdowns
/// in the application, including contacts, contact types, and countries.
/// </summary>
public class SelectOptions
{
    /// <summary>
    /// Retrieves default selections for contacts, contact types, and countries.
    /// </summary>
    /// <param name="context">
    /// The database context used to query the data.
    /// </param>
    /// <returns>
    /// A tuple containing three lists:
    /// <list type="bullet">
    /// <item>
    /// <description>A list of <see cref="Contact"/> objects, including a placeholder at the first position.</description>
    /// </item>
    /// <item>
    /// <description>A list of <see cref="ContactType"/> objects, including a placeholder at the first position.</description>
    /// </item>
    /// <item>
    /// <description>A list of <see cref="Country"/> objects, including a placeholder at the first position.</description>
    /// </item>
    /// </list>
    /// </returns>
    public static (List<Contact>, List<ContactType>, List<Country>) GetDefaultSelections(Context context)
    {
        // Pseudocode:
        // - Project Contacts to new Contact instances with only required fields populated (avoid anonymous types).
        // - Insert a placeholder Contact at index 0.
        // - Project ContactTypes to new ContactType instances; insert a placeholder at index 0.
        // - Project Countries to new Country instances; insert a placeholder at index 0.
        // - Return the tuple (contacts, contactTypes, countries).

        var contacts = context.Contacts
            .Select(c => new Contact
            {
                ContactId = c.ContactId,
                FullName = c.FullName ?? string.Empty
            })
            .ToList();

        contacts.Insert(0, new Contact
        {
            ContactId = -1,
            FullName = "Select contact..."
        });

        var contactTypes = context.ContactTypes
            .Select(ct => new ContactType
            {
                ContactTypeIdentifier = ct.ContactTypeIdentifier,
                ContactTitle = ct.ContactTitle ?? string.Empty
            })
            .ToList();

        contactTypes.Insert(0, new ContactType
        {
            ContactTypeIdentifier = -1,
            ContactTitle = "Select contact type..."
        });

        var countries = context.Countries
            .Select(cn => new Country
            {
                CountryIdentifier = cn.CountryIdentifier,
                Name = cn.Name ?? string.Empty
            })
            .ToList();

        countries.Insert(0, new Country
        {
            CountryIdentifier = -1,
            Name = "Select country..."
        });

        return (contacts, contactTypes, countries);
    }
}
