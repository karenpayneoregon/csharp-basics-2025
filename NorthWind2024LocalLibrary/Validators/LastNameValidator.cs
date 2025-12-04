using FluentValidation;
using NorthWind2024LocalLibrary.Models;

namespace NorthWind2024LocalLibrary.Validators;

/// <summary>
/// Provides validation rules for the <see cref="Contact.LastName"/> property of the <see cref="Contact"/> model.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="Contact.LastName"/> property is not empty and does not exceed 50 characters.
/// </remarks>
public class LastNameValidator : AbstractValidator<Contact>
{
    public LastNameValidator()
    {
        RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .MaximumLength(50)
            .WithMessage("Last name must not exceed 50 characters.");
    }
}