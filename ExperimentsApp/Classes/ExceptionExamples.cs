using System.Diagnostics;
using ExperimentsApp.Classes.Presentation;
using System.Runtime.ExceptionServices;
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

namespace ExperimentsApp.Classes;

/// <summary>
/// Provides examples of exception handling and safe division methods.
/// </summary>
/// <remarks>
/// This class demonstrates two approaches to handling division operations:
/// 1. A method that throws a <see cref="DivideByZeroException"/> when dividing by zero.
/// 2. A method that uses a tuple to indicate success or failure without throwing exceptions.
///
/// For more information, refer to:
/// - <see href="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/exception-handling">
///   Exception Handling (C# Programming)</see>
/// - <see href="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/">
///   Microsoft Exceptions and Exception Handling</see>
/// </remarks>
internal class ExceptionExamples
{

    /// <summary>
    /// Demonstrates the usage of safe division methods and exception handling.
    /// </summary>
    /// <param name="control">
    /// The control used as the owner for displaying informational dialogs.
    /// </param>
    /// <remarks>
    /// This method showcases two approaches to division:
    /// 1. <see cref="SafeDivisionThatThrows"/>: Throws a <see cref="DivideByZeroException"/> when dividing by zero.
    /// 2. <see cref="SafeDivision"/>: Returns a tuple indicating success or failure without throwing exceptions.
    /// Informational dialogs are displayed to indicate the results of these operations.
    /// </remarks>
    public static void ExampleUsage(Control control)
    {
        try
        {
            double result1 = SafeDivisionThatThrows(10, 0);
        }
        catch (DivideByZeroException)
        {
            Dialogs.Information(control, "Caught DivideByZeroException from SafeDivision1");
        }

        var (ok, result2) = SafeDivision(10, 0);
        if (ok)
        {
            Dialogs.Information(control, "SafeDivision succeeded");
        }
        else
        {
            Dialogs.Information(control, "SafeDivision failed");
        }

        var (ok1, result3) = SafeDivision(10, 5);
        if (ok1)
        {
            Dialogs.Information(control, "SafeDivision succeeded");
        }
        else
        {
            Dialogs.Information(control, "SafeDivision failed");
        }
    }

    /// <summary>
    /// Performs division of two numbers and throws an exception if the divisor is zero.
    /// </summary>
    /// <param name="x">The numerator of the division.</param>
    /// <param name="y">The denominator of the division.</param>
    /// <returns>The result of dividing <paramref name="x"/> by <paramref name="y"/>.</returns>
    /// <exception cref="DivideByZeroException">
    /// Thrown when <paramref name="y"/> is zero.
    /// </exception>
    /// <remarks>
    /// This method is intended to demonstrate exception handling by explicitly throwing a 
    /// <see cref="DivideByZeroException"/> when an invalid division operation is attempted.
    /// </remarks>
    public static double SafeDivisionThatThrows(double x, double y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException();
        }

        return x / y;
    }

    /// <summary>
    /// Performs a safe division operation and returns the result as a tuple.
    /// </summary>
    /// <param name="x">The dividend in the division operation.</param>
    /// <param name="y">The divisor in the division operation.</param>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item>
    /// <description><c>ok</c>: A <see cref="bool"/> indicating whether the division was successful.</description>
    /// </item>
    /// <item>
    /// <description>The result of the division as a <see cref="double"/> if successful, or <c>0</c> if the division failed.</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// This method avoids throwing exceptions for division by zero. Instead, it returns a tuple where:
    /// - <c>ok</c> is <c>false</c> if <paramref name="y"/> is <c>0</c>, and <c>true</c> otherwise.
    /// - The second value is the result of the division if <c>ok</c> is <c>true</c>, or <c>0</c> if <c>ok</c> is <c>false</c>.
    /// </remarks>
    public static (bool ok, double) SafeDivision(double x, double y)
    {
        
        return y == 0 ? 
            (false, 0) : 
            (true, x / y);
        
    }

    /// <summary>
    /// Demonstrates the use of <see cref="ExceptionDispatchInfo"/> to handle exceptions while preserving the original stack trace.
    /// </summary>
    /// <remarks>
    /// This method attempts to read all lines from a file using the <c>ReadAllLines</c> method. 
    /// If an exception occurs during the operation, it captures the exception using <see cref="ExceptionDispatchInfo"/> 
    /// and rethrows it while maintaining the original stack trace.
    /// </remarks>
    /// <exception cref="Exception">
    /// Any exception that occurs during the file reading operation is captured and rethrown.
    /// </exception>
    public static void ExceptionDispatchInfoExample()
    {
        var (lines, exceptionDispatchInfo) = ReadAllLines();
        
        if (exceptionDispatchInfo is not null)
        {
            // perhaps log the exception here first
            exceptionDispatchInfo?.Throw();
        }
        foreach (var line in lines)
        {
            Debug.WriteLine(line);
        }
    }
    
    /// <summary>
    /// Attempts to read all lines from a file and captures any exception that occurs during the operation.
    /// </summary>
    /// <returns>
    /// A tuple containing the following:
    /// <list type="bullet">
    /// <item>
    /// <description>An array of strings representing the lines read from the file, or <c>null</c> if an exception occurred.</description>
    /// </item>
    /// <item>
    /// <description>An <see cref="ExceptionDispatchInfo"/> object containing the captured exception, or <c>null</c> if no exception occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// This method demonstrates the use of <see cref="ExceptionDispatchInfo"/> to capture and rethrow exceptions while preserving the original stack trace.
    /// </remarks>
    private static (string[] lines, ExceptionDispatchInfo exceptionDispatchInfo) ReadAllLines()
    {
        string[]? lines = null;
        ExceptionDispatchInfo exceptionDispatchInfo = null!;
        
        try
        {
            lines = File.ReadAllLines("NonExistingFile.txt");
        }
        catch (Exception localException)
        {
            exceptionDispatchInfo = ExceptionDispatchInfo.Capture(localException);
        }
        
        return (lines, exceptionDispatchInfo)!;
        
    }
}
