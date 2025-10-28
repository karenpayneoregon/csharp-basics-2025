namespace InterfaceExamples.Extensions;
public static partial class Extensions
{

    public static partial string? CapitalizeFirstLetter(this string? input)
    => string.IsNullOrWhiteSpace(input) ?
        input : char.ToUpper(input[0]) + input.AsSpan(1).ToString();

    public static partial bool IsInteger(this string sender)
    {
        foreach (var c in sender)
            if (c is < '0' or > '9') return false;

        return true;
    }

    public static partial bool IsNotInteger(this string sender)
        => sender.IsInteger() == false;

}
