using EntityFrameworkLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Models;

namespace WebApplication1.Areas.Contacts.Pages;

/// <summary>
/// Represents the model for the Contact List page.
/// </summary>
/// <remarks>
/// This class is responsible for handling the data and operations required to display a list of contacts.
/// It interacts with the database context to retrieve contact information, including related entities such as
/// contact type details.
/// </remarks>
public class ContactListModel(Context context) : PageModel
{

    public IList<Contact> Contact { get;set; } = null!;

    public async Task OnGetAsync()
    {
        Contact = await context.Contacts
            .TagWithDebugInfo("Fetching all contacts") // in EntityFrameworkLibrary.csproj
            .Include(c => c.ContactTypeIdentifierNavigation)
            .OrderBy(c => c.LastName)
            .ToListAsync();
    }
}
