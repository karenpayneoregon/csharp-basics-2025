using FluentValidation;
using NorthWind2024LocalLibrary.Models;

namespace NorthWind2024LocalLibrary.Validators;

/// <summary>
/// Provides validation rules for the <see cref="Contact.ContactTypeIdentifier"/> property of the <see cref="Contact"/> model.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="Contact.ContactTypeIdentifier"/> property is not null and has a value greater than zero.
/// </remarks>
public class ContactTypeIdentifierValidator : AbstractValidator<Contact>
{
    public ContactTypeIdentifierValidator()
    {
        RuleFor(c => c.ContactTypeIdentifier)
            .NotNull()
            .WithMessage("Contact type is required.")
            .GreaterThan(0)
            .WithMessage("Contact type identifier must be greater than zero.");
    }
}