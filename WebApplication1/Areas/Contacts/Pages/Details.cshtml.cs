using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Models;

namespace WebApplication1.Areas.Contacts.Pages;

/// <summary>
/// Represents the model for the details page in the Contacts area of the application.
/// </summary>
/// <remarks>
/// This class is responsible for handling the retrieval and display of detailed information
/// about a specific contact. It interacts with the database context to fetch the required data
/// and provides it to the Razor page for rendering.
/// </remarks>
public class DetailsModel(Context context) : PageModel
{

    public Contact Contact { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) { return NotFound(); }

        var contact = await context.Contacts
            .Include(x => x.ContactTypeIdentifierNavigation)
            .FirstOrDefaultAsync(m => m.ContactId == id);

        if (contact is not null)
        {
            Contact = contact;
            return Page();
        }

        return NotFound();
    }

}