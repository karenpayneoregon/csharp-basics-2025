using System.Numerics;

namespace SamplesApp.Classes.Extensions;
public static class GenericExtensions
{
    /// <summary>Determines if a value represents an even integral value.</summary>
    public static bool IsEven<T>(this T sender) where T : INumber<T>
        => T.IsEvenInteger(sender);

    /// <summary>Determines if a value represents an odd integral value.</summary>
    public static bool IsOdd<T>(this T sender) where T : INumber<T>
        => T.IsOddInteger(sender);

    public static T Max<T>(this T sender, T other) where T : INumber<T>
        => T.Max(sender, other);

    /// <summary>
    /// Clamps a value to a specified range defined by a minimum and maximum value.
    /// </summary>
    /// <typeparam name="T">
    /// The numeric type of the value, minimum, and maximum. Must implement <see cref="System.Numerics.INumber{T}"/>.
    /// </typeparam>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The inclusive minimum value of the range.</param>
    /// <param name="max">The inclusive maximum value of the range.</param>
    /// <returns>
    /// The clamped value, which will be equal to <paramref name="min"/> if <paramref name="value"/> is less than <paramref name="min"/>, 
    /// or <paramref name="max"/> if <paramref name="value"/> is greater than <paramref name="max"/>. 
    /// Otherwise, it will return <paramref name="value"/>.
    /// </returns>
    public static T Clamp<T>(this T value, T min, T max) where T : INumber<T>
        => T.Clamp(value, min, max);
    
    /// <summary>
    /// Add ellipsis-es to the end of type and convert to a string
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="sender">Type of <see cref="T"/></param>
    /// <param name="width">Width to pad</param>
    /// <param name="paddingChar">Character to pad with, defaults to a period</param>
    /// <returns>Padded string</returns>
    public static string Ellipsis<T>(this T sender, int width, char paddingChar = '.') where T : INumber<T>
        => sender.ToString().Ellipsis(width, paddingChar);

    /// <summary>
    /// Truncates or pads the string representation of the value to fit within the specified width, 
    /// using the specified padding character if necessary.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value, which must be a non-nullable value type.
    /// </typeparam>
    /// <param name="sender">
    /// The value to be converted to a string and processed.
    /// </param>
    /// <param name="width">
    /// The desired width of the resulting string.
    /// </param>
    /// <param name="paddingChar">
    /// The character to use for padding if the string representation of the value is shorter than the specified width.
    /// Defaults to '.' if not specified.
    /// </param>
    /// <returns>
    /// A string that represents the value, truncated or padded to the specified width.
    /// </returns>
    public static string Ellipsis<T>(this T? sender, int width, char paddingChar = '.') where T : struct
        => sender is not null ? 
            sender.ToString().Ellipsis(width, paddingChar) : 
            "".Ellipsis(width, paddingChar);

    public static IFormattable EllipsisFormattable<T>(this T sender, int width, char paddingChar = '.')
        where T : struct, IFormattable
        => new EllipsisNumericFormattable<T>(sender, width, paddingChar);

}