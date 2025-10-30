using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication1.Classes;


/// <summary>
/// Provides extension methods for various utility operations.
/// </summary>
public static partial class ValidatorExtensions
{

    /// <summary>
    /// Adds the validation errors from a <see cref="ValidationResult"/> to the specified <see cref="ModelStateDictionary"/>.
    /// </summary>
    /// <param name="result">The <see cref="ValidationResult"/> containing validation errors.</param>
    /// <param name="modelState">The <see cref="ModelStateDictionary"/> to which the validation errors will be added.</param>
    /// <param name="prefix">
    /// An optional prefix to prepend to the property names of the validation errors. 
    /// If the prefix is not provided, the property names will be used as-is.
    /// </param>
    /// <remarks>
    /// This method iterates through the validation errors in the <paramref name="result"/> and adds them to the 
    /// <paramref name="modelState"/>. If a prefix is specified, it is prepended to the property names of the errors.
    /// </remarks>
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState, string prefix)
    {
        
        if (result.IsValid) return;
        
        foreach (var error in result.Errors)
        {
            var key = string.IsNullOrEmpty(prefix)
                ? error.PropertyName
                : string.IsNullOrEmpty(error.PropertyName)
                    ? prefix
                    : $"{prefix}.{error.PropertyName}";
            
            modelState.AddModelError(key, error.ErrorMessage);
        }
    }
    
}

