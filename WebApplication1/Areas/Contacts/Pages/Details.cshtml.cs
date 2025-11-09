using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Areas.Contacts.Pages;

public class DetailsModel(Context context, IOptions<JsonOptions> jsonOptions) : PageModel
{

    public Contact Contact { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) { return NotFound(); }

        var contact = await context.Contacts
            .Include(x => x.ContactTypeIdentifierNavigation)
            .Include(x => x.ContactDevices)
            .ThenInclude(x => x.PhoneTypeIdentifierNavigation)
            .FirstOrDefaultAsync(m => m.ContactId == id);

        if (contact is not null)
        {
            Contact = contact;

            var json = JsonSerializer.Serialize(Contact, JsonSerializerOptions());
            Console.WriteLine(json);
            
            return Page();
        }

        return NotFound();
    }

    private JsonSerializerOptions JsonSerializerOptions() => new(jsonOptions.Value.SerializerOptions) 
        { ReferenceHandler = ReferenceHandler.IgnoreCycles };
}