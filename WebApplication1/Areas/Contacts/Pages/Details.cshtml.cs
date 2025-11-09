using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

namespace WebApplication1.Areas.Contacts.Pages;

public class DetailsModel(Context context, IOptions<JsonOptions> jsonOptions) : PageModel
{
    public Contact Contact { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contact = await context.Contacts
            .Include(x => x.ContactTypeIdentifierNavigation)
            .FirstOrDefaultAsync(m => m.ContactId == id);

        if (contact is not null)
        {
            Contact = contact;

            var opts = JsonSerializerOptions();
            
            var json = JsonSerializer.Serialize(Contact, opts);
            Console.WriteLine(json);
            return Page();
        }

        return NotFound();
    }

    private static JsonSerializerOptions JsonSerializerOptions() =>
        new(jsonOptions.Value.SerializerOptions) { ReferenceHandler = ReferenceHandler.IgnoreCycles };

    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
}