using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamplesApp.Models;

// ReSharper disable UseStringInterpolation
// ReSharper disable UseIndexFromEndExpression

namespace SamplesApp.Classes.Basics;
internal static class StringSamples
{
    public static void BasicStringOperations()
    {
        // String declaration and initialization
        string greeting = "Hello";
        string name = "World";

        // String concatenation
        string message = greeting + ", " + name + "!";
        Console.WriteLine($"Concatenated string: {message}"); // Output: Hello, World!

        // String interpolation (more readable)
        string interpolatedMessage = $"{greeting}, {name}!";
        Console.WriteLine($"Interpolated string: {interpolatedMessage}"); // Output: Hello, World!

        // Finding a substring
        int indexOfWorld = message.IndexOf("World", StringComparison.Ordinal);
        Console.WriteLine($"Index of 'World': {indexOfWorld}"); // Output: 7

        // Checking if a string contains a substring
        bool containsWorld = message.Contains("World");
        Console.WriteLine($"Does message contain 'World'? {containsWorld}"); // Output: True

    }

    public static void StringContains()
    {
        string source = "The quick brown fox";
        string target = "FOX";

        bool contains = source.Contains(target);

        if (contains)
        {
            Console.WriteLine($"Does source contain '{target}'? {contains}");
        }
        else
        {
            Console.WriteLine($"Source does not contain '{target}'? {contains}");
        }
    }
    public static void StringContainsCaseInsensitive()
    {
        string source = "The quick brown fox";
        string target = "FOX";

        bool contains = source.Contains(target, StringComparison.OrdinalIgnoreCase);

        if (contains)
        {
            Console.WriteLine($"Does source contain '{target}'? {contains}");
        }
        else
        {
            Console.WriteLine($"Source does not contain '{target}'? {contains}");
        }
    }

    private static void FormatPriceAndQuantity()
    {
        // String formatting
        double price = 19.99;
        int quantity = 3;

        {
            string formattedString = string.Format("The total cost is {0:C} for {1} items.", price, quantity);
            Console.WriteLine(formattedString); // Output: The total cost is $19.99 for 3 items. (culture-dependent)
        }
        
        string formattedPrice = $"The total cost is {price:C} for {quantity} items.";
        Console.WriteLine(formattedPrice); // Output: The total cost is $19.99 for 3 items. (culture-dependent)

        // Another way to format using string interpolation
        string interpolatedFormat = $"The total cost is {price:C} for {quantity} items.";
        Console.WriteLine(interpolatedFormat); // Output: The total cost is $19.99 for 3 items. (culture-dependent)
    }

    public static void CompareStrings()
    {

        string str1 = "Hello World";
        string str2 = "hello world";

        bool areEqual = string.Equals(str1, str2);

        if (areEqual)
        {
            Console.WriteLine("Are equal (not case sensitive)");
        }
        else
        {
            Console.WriteLine("Not equal  (not case sensitive)");
        }
    }

    public static void CompareStringsCaseInsensitive()
    {

        string str1 = "Hello World";
        string str2 = "hello world";

        bool areEqual = string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);

        if (areEqual)
        {
            Console.WriteLine("Are equal (case sensitive)");
        }
        else
        {
            Console.WriteLine("Not equal  (case sensitive)");
        }
    }

    public static void CompareStringsBoth()
    {

        {
            string str1 = "Hello World";
            string str2 = "hello world";

            bool areEqual = string.Equals(str1, str2);

            if (areEqual)
            {
                Console.WriteLine("Are equal (not case sensitive)");
            }
            else
            {
                Console.WriteLine("Not equal  (not case sensitive)");
            }
        }
        
        
        
        {
            string str1 = "Hello World";
            string str2 = "hello world";

            bool areEqual = string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);

            if (areEqual)
            {
                Console.WriteLine("Are equal (case sensitive)");
            }
            else
            {
                Console.WriteLine("Not equal  (case sensitive)");
            }
        }
    }



    /// <summary>
    /// Demonstrates immutable nature of strings.
    /// </summary>
    public static void StringImmutability()
    {
        string original = "Immutable";
        string modified = original; // Both variables now point to the same string object in memory

        Console.WriteLine($"Original: {original}, Modified: {modified}");

        // Attempt to "modify" the string
        // This does NOT change the original string.
        // Instead, a new string object is created and 'modified' now points to it.
        modified = modified + " Example";

        Console.WriteLine($"After modification attempt:");
        Console.WriteLine($"Original: {original}"); // Still points to "Immutable"
        Console.WriteLine($"Modified: {modified}"); // Points to "Immutable Example"

        // You can verify they are different objects in memory
        Console.WriteLine(
            $"Are original and modified pointing to the same object? {object.ReferenceEquals(original, modified)}"); // Output: False
    }

    /// <summary>
    /// Demonstrates using StringBuilder for efficient string manipulation.
    /// </summary>
    public static void StringBuilderDemo()
    {
        // StringBuilder is mutable, making it more efficient for repeated modifications
        StringBuilder sb = new StringBuilder();

        // Appending strings
        sb.Append("This is the first part.");
        sb.Append(" "); // Append a space
        sb.Append("And this is the second part.");

        // Inserting strings at a specific position
        sb.Insert(10, " and "); // Insert " and " at index 10

        // Replacing parts of the string
        sb.Replace("first part", "initial segment");

        // Removing characters
        sb.Remove(0, 5); // Remove the first 5 characters ("This ")

        // Converting back to a string
        string finalString = sb.ToString();
        Console.WriteLine($"StringBuilder result: {finalString}");
        // Output: StringBuilder result: and initial segment. And this is the second part.
    }

    /// <summary>
    /// Demonstrates the usage of ranges and indices in strings.
    /// </summary>
    /// <remarks>
    /// This method showcases various operations with ranges and indices, including:
    /// <list type="bullet">
    /// <item>Extracting the first letter of a string using ranges and indices.</item>
    /// <item>Handling empty strings and checking for the first character.</item>
    /// <item>Extracting the last letter of a string using the ^ operator and conventional methods.</item>
    /// </list>
    /// </remarks>
    public static void Ranges()
    {
        string firstName = "karen";

        firstName = firstName.CapitalizeFirstLetter();
        
        // get first letter, 0 is optional in this case the recommended way is [0]
        Console.WriteLine(firstName[0..1]); 
        Console.WriteLine(firstName[0]);

        {
            firstName = "";
            var first = firstName.FirstOrDefault();
            if (!char.IsWhiteSpace(first) && first != '\0')
            {
                Console.WriteLine($"First letter is: {first}");
            }
            else
            {
                Console.WriteLine("String is empty");
            }

            firstName = "Karen";
        }

        Console.WriteLine();

        // get last letter using ^ operator which counts from end of string
        // Readability high
        Console.WriteLine(firstName[^1]);
        // conventional way to get last letter
        // Readability Medium
        Console.WriteLine(firstName[firstName.Length - 1]);
        Console.WriteLine(firstName.LastOrDefault());
    }

    /// <summary>
    /// Capitalizes the first letter of the specified string.
    /// </summary>
    /// <param name="sender">The string to capitalize. If the string is <c>null</c> or empty, it is returned unchanged.</param>
    /// <returns>
    /// A new string with the first letter converted to uppercase, followed by the remaining characters unchanged.
    /// If the input string is <c>null</c> or empty, the original string is returned.
    /// </returns>
    public static string CapitalizeFirstLetter(this string sender)
        => string.IsNullOrEmpty(sender) ? sender : $"{char.ToUpper(sender[0])}{sender[1..]}";

    /// <summary>
    /// Trim last character from a string 
    /// </summary>
    /// <param name="sender">string to work on</param>
    /// <returns>Original string if null otherwise original string minus the last character</returns>
    public static string TrimLastCharacter(this string sender) 
        => string.IsNullOrWhiteSpace(sender) ? sender : sender[..^1];

    public static string TrimLastCharacterConventional(this string sender, char trimChar)
        => string.IsNullOrWhiteSpace(sender) ? sender : sender.TrimEnd(trimChar);

    public static char GetFirst(this string sender) => sender[0];
    public static char GetLast(this string sender) => sender[^1];
    
    public static T GetLast<T>(this T[] sender) => sender[^1];
    public static T GetLast<T>(this List<T> sender) => sender[^1];

    public static List<string> MonthNames() =>
        DateTimeFormatInfo.CurrentInfo!.MonthNames[..^1].ToList();

    public static List<ElementContainer<T>> RangeDetails<T>(List<T> list) =>
        list.Select((element, index) => new ElementContainer<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(Enumerable.Range(0, list.Count).Reverse().ToList()[index], true),
            MonthIndex = index + 1
        }).ToList();
    
    
}

