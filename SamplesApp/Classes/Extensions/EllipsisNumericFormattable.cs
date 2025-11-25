namespace SamplesApp.Classes.Extensions;

/// <summary>
/// Represents a numeric value that supports custom formatting with ellipsis padding.
/// </summary>
/// <typeparam name="T">
/// The numeric type of the value. Must be a struct that implements <see cref="System.IFormattable"/>.
/// </typeparam>
public readonly struct EllipsisNumericFormattable<T> : IFormattable where T : struct, IFormattable
{
    private readonly T _value;
    private readonly int _width;
    private readonly char _paddingChar;

    /// <summary>
    /// Initializes a new instance of the <see cref="EllipsisNumericFormattable{T}"/> struct.
    /// </summary>
    /// <param name="value">
    /// The numeric value to be formatted. Must be of type <typeparamref name="T"/>, which is a struct implementing <see cref="System.IFormattable"/>.
    /// </param>
    /// <param name="width">
    /// The total width of the formatted string, including any ellipsis padding.
    /// </param>
    /// <param name="paddingChar">
    /// The character to use for padding when applying ellipsis.
    /// </param>
    public EllipsisNumericFormattable(T value, int width, char paddingChar)
    {
        _value = value;
        _width = width;
        _paddingChar = paddingChar;
    }

    /// <summary>
    /// Converts the numeric value to its string representation using the specified format and format provider,
    /// and applies ellipsis padding to the result.
    /// </summary>
    /// <param name="format">
    /// A standard or custom numeric format string that determines the format of the numeric value.
    /// </param>
    /// <param name="formatProvider">
    /// An object that provides culture-specific formatting information.
    /// </param>
    /// <returns>
    /// A string representation of the numeric value formatted according to the specified format and format provider,
    /// with ellipsis padding applied.
    /// </returns>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        // Apply numeric formatting first (e.g., format “C”)
        string formatted = _value.ToString(format, formatProvider) ?? "";

        // Then apply Ellipsis padding
        return formatted.Ellipsis(_width, _paddingChar);
    }

    public override string ToString()
        => ToString(null, null);
}