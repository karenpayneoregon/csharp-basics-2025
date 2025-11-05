using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Models;
using Serilog;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Areas.Contacts.Pages
{
    public class ContactEditModel(Context context, IValidator<Contact> validator) : PageModel
    {
        public AlertModalViewModel Alert { get; set; } = new();

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
            catch (DbUpdateConcurrencyException ce)
            {
                if (!ContactExists(Contact.ContactId))
                {
                    Log.Error(ce, $"Error updating contact {Contact.ContactId}: {ce.Message}");
                    
                    DisplayConcurrencyAlert();

                    return NotFound();
                }
                else
                {
                    Log.Error(ce, $"Error updating contact {Contact.ContactId}: {ce.Message}");
                    
                    DisplayDoesNotExistsAlert();
                    
                    return RedirectToPage("./Index");
                }
            }

            return RedirectToPage("./Index");
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

        /// <summary>
        /// Displays a concurrency alert to the user when a concurrency conflict occurs during an update operation.
        /// </summary>
        /// <remarks>
        /// This method sets up an alert modal with a predefined title, message, button text, and CSS class
        /// to inform the user about the concurrency issue. It also updates the <see cref="ViewData"/> to ensure
        /// the alert modal is displayed on the page.
        /// </remarks>
        private void DisplayConcurrencyAlert()
        {
            Alert = new AlertModalViewModel
            {
                Title = "Concurrency Error",
                Message = "Another user has modified this record. Please refresh the page and try again.",
                ButtonText = "OK",
                CssClass = "btn-danger"
            };

            ViewData["ShowAlertModal"] = true;
            
        }

        /// <summary>
        /// Displays an alert modal indicating that the contact no longer exists.
        /// </summary>
        /// <remarks>
        /// This method updates the <see cref="Alert"/> property with details about the error
        /// and sets the <c>ViewData["ShowAlertModal"]</c> flag to <c>true</c> to trigger the display of the alert modal.
        /// </remarks>
        private void DisplayDoesNotExistsAlert()
        {
            Alert = new AlertModalViewModel
            {
                Title = "Error",
                Message = "Contact no longer exists.",
                ButtonText = "OK",
                CssClass = "btn-danger"
            };

            ViewData["ShowAlertModal"] = true;

        }

        private bool ContactExists(int id)
        {
            return context.Contacts.Any(e => e.ContactId == id);
        }
    }
}
