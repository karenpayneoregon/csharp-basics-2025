using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Models;
using WebApplication1.Classes;

namespace WebApplication1.Areas.Contacts.Pages
{
    public class ContactEditModel(Context context, IValidator<Contact> validator) : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            PopulateDropdownViewData(context);
            
            var contact =  await context.Contacts.FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }
            Contact = contact;
           //ViewData["ContactTypeIdentifier"] = new SelectList(context.ContactTypes, "ContactTypeIdentifier", "ContactTypeIdentifier");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var result = await validator.ValidateAsync(Contact);
            if (!result.IsValid)
            {
                
                PopulateDropdownViewData(context);
                result.AddToModelState(ModelState, nameof(Contact));
                
                return Page();
            }

            context.Attach(Contact).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(Contact.ContactId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContactExists(int id)
        {
            return context.Contacts.Any(e => e.ContactId == id);
        }

        /// <summary>
        /// Populates dropdown lists in the ViewData with data retrieved from the provided database dbContext.
        /// </summary>
        /// <param name="dbContext">
        /// The database dbContext used to fetch data for populating the dropdown lists.
        /// </param>
        /// <remarks>
        /// This method retrieves data for contacts, contact types, and countries from the database.
        /// It adds placeholder entries to each list to assist user selection.
        /// The populated dropdown lists are stored in the <see cref="PageModel.ViewData"/> dictionary
        /// using the keys "ContactId", "ContactTypeIdentifier", and "CountryIdentifier".
        /// </remarks>
        private void PopulateDropdownViewData(Context dbContext)
        {

            var (_, contactTypes, _) = SelectOptions.GetDefaultSelections(dbContext);

            ViewData["ContactTypeIdentifier"] = new SelectList(contactTypes, nameof(ContactType.ContactTypeIdentifier), nameof(ContactType.ContactTitle));
        }
    }
}
