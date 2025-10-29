using FluentValidation;
using NorthWind2024LocalLibrary.Models;

namespace NorthWind2024LocalLibrary.Validators;
public class ContactValidator : AbstractValidator<Contact>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This validator is responsible for validating the properties of the <see cref="Contact"/> model.
    /// It ensures that required fields such as <see cref="Contact.FirstName"/>, <see cref="Contact.LastName"/>, 
    /// and <see cref="Contact.ContactTypeIdentifier"/> are properly validated with specific rules.
    /// </remarks>
    public ContactValidator()
    {

        // FirstName
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .MaximumLength(50)
            .WithMessage("First name must not exceed 50 characters.");

        // LastName
        RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .MaximumLength(50)
            .WithMessage("Last name must not exceed 50 characters.");

        // ContactTypeIdentifier
        RuleFor(c => c.ContactTypeIdentifier)
            .NotNull()
            .WithMessage("Contact type is required.")
            .GreaterThan(0)
            .WithMessage("Contact type identifier must be greater than zero.");

        // ContactType navigation (optional check)
        RuleFor(c => c.ContactTypeIdentifierNavigation)
            .NotNull()
            .WithMessage("A valid contact type must be associated.");
    }
}