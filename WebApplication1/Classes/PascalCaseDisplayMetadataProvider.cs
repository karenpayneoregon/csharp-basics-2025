using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Text.RegularExpressions;

namespace WebApplication1.Classes;

/// <summary>
/// Provides a custom implementation of <see cref="IDisplayMetadataProvider"/> 
/// to format property names in PascalCase into a more readable format by inserting spaces.
/// </summary>
/// <remarks>
/// This class is designed to enhance the display metadata for properties in an ASP.NET Core MVC application.
/// It modifies the display name of properties by splitting PascalCase names into separate words, 
/// unless a display name is already explicitly provided.
/// </remarks>
public sealed partial class PascalCaseDisplayMetadataProvider : IDisplayMetadataProvider
{
    public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        // Only touch property names, and only when no Display/DisplayName is already supplied.
        if (context.Key.MetadataKind != ModelMetadataKind.Property)
            return;

        var existing = context.DisplayMetadata.DisplayName?.Invoke();
        if (!string.IsNullOrEmpty(existing))
            return;

        context.DisplayMetadata.DisplayName = () => SplitPascalCase(context.Key.Name ?? string.Empty);
    }

    private static string SplitPascalCase(string sender)
    {
        if (string.IsNullOrWhiteSpace(sender)) return sender;

        // Insert a space before capital letters that either:
        //  - follow a lowercase/number, or
        //  - start an Upper-lower sequence (handles “UnitPrice”, “IDNumber”, etc.)
        return SplitPascalCaseRegex().Replace(sender, " $1");
    }

    [GeneratedRegex("(?<=.)([A-Z](?=[a-z])|(?<=[a-z0-9])[A-Z])")]
    private static partial Regex SplitPascalCaseRegex();
}
    