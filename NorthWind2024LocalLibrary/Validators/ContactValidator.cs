using FluentValidation;
using NorthWind2024LocalLibrary.Models;

namespace NorthWind2024LocalLibrary.Validators;
public class ContactValidator : AbstractValidator<Contact>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor defines validation rules for the <see cref="Contact"/> model.
    /// It includes specific rule sets for different contexts, such as "EditPage" and "CreatePage".
    /// The rules ensure that properties like <see cref="Contact.FirstName"/>, <see cref="Contact.LastName"/>, 
    /// and <see cref="Contact.ContactTypeIdentifier"/> meet the required criteria.
    /// </remarks>
    public ContactValidator()
    {
        
        RuleSet("EditPage", () =>
        {
            Include(new FirstNameValidator());
            Include(new LastNameValidator());
        });

        RuleSet("CreatePage", () =>
        {
            Include(new FirstNameValidator());
            Include(new LastNameValidator());

            RuleFor(c => c.ContactTypeIdentifier)
                .NotNull()
                .WithMessage("Contact type is required.")
                .GreaterThan(0)
                .WithMessage("Contact type identifier must be greater than zero.");


            RuleFor(c => c.ContactTypeIdentifierNavigation)
                .NotNull()
                .WithMessage("A valid contact type must be associated.");
        });

    }
}

