using FluentValidation;
using NorthWind2024LocalLibrary.Models;

namespace NorthWind2024LocalLibrary.Validators;
/// <summary>
/// Provides validation rules for the <see cref="Contact.FirstName"/> property of the <see cref="Contact"/> model.
/// </summary>
/// <remarks>
/// This validator ensures that the <see cref="Contact.FirstName"/> property is not empty and does not exceed 50 characters.
/// </remarks>
public class FirstNameValidator : AbstractValidator<Contact>
{
    public FirstNameValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .MaximumLength(50)
            .WithMessage("First name must not exceed 50 characters.");
    }
}
