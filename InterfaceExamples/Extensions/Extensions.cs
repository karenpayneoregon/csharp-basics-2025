#nullable disable
namespace InterfaceExamples.Extensions;

/// <summary>
/// Provides extension methods for string manipulation and validation.
/// </summary>
public static partial class Extensions
{
    
    /// <summary>
    /// Capitalizes the first letter of the given string.
    /// </summary>
    /// <param name="input">The string to capitalize.</param>
    /// <returns>A new string with the first letter capitalized. If the input is null or empty, the original string is returned.</returns>
    public static partial string CapitalizeFirstLetter(this string? input);
    /// <summary>
    /// Determines whether the specified string consists only of numeric characters.
    /// </summary>
    /// <param name="sender">The string to evaluate.</param>
    /// <returns>
    /// <c>true</c> if the string consists only of numeric characters; otherwise, <c>false</c>.
    /// </returns>
    public static partial bool IsInteger(this string sender);
    public static partial bool IsNotInteger(this string sender);
}
