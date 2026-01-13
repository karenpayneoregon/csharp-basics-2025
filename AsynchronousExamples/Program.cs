using System.Globalization;
using AsynchronousExamples.Classes;
using AsynchronousExamples.Classes.Configuration;
using Serilog;
using Spectre.Console;
using System.Reflection;
using System.Runtime.Versioning;
#pragma warning disable CS8604 // Possible null reference argument.

namespace AsynchronousExamples;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Task.Delay(0);

        //await ProcessNumbersWithCancellationAsync();
        //await ProcessJsonFileAsync("data.json");
        
        Version? frameworkVersion = Assembly.GetEntryAssembly().GetTargetFrameworkVersion();
        if (frameworkVersion is not null)
        {
            Console.WriteLine(frameworkVersion);
        }else
        {
            Console.WriteLine("Could not determine the target framework version.");
        }

        SpectreConsoleHelpers.ExitPrompt();
    }

    /// <summary>
    /// Asynchronously processes a sequence of numbers with cancellation support. Default cancellation
    /// occurs after 2 seconds which will throw an <see cref="OperationCanceledException"/>.
    /// </summary>
    /// <param name="delayInSeconds">
    /// The duration in seconds after which the operation will be automatically canceled.
    /// </param>
    /// <remarks>
    /// This method retrieves numbers from <see cref="Samples.GetNumbersAsync"/> and writes them to the console.
    /// It demonstrates the use of asynchronous streams and cancellation tokens, automatically canceling the operation
    /// after the specified duration.
    /// </remarks>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    /// <exception cref="OperationCanceledException">
    /// Thrown when the operation is canceled.
    /// </exception>
    /// <exception cref="Exception">
    /// Thrown when an unexpected error occurs during the operation.
    /// </exception>
    private static async Task ProcessNumbersWithCancellationAsync(int delayInSeconds = 2)
    {
        SpectreConsoleHelpers.PrintCyan();
        
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(delayInSeconds));

        try
        {
            await foreach (var number in Samples.GetNumbersAsync(cts.Token))
            {
                Console.WriteLine(number);
            }
        }
        catch (OperationCanceledException operationCanceledException)
        {
            AnsiConsole.MarkupLine("[bold green]Enumeration cancelled cleanly.[/]");
            Log.Error(operationCanceledException, "Enumeration was canceled.");
        }
        catch (Exception exception)
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] {exception.Message}");
            Log.Error(exception, "An unexpected error occurred.");
        }
    }
    /// <summary>
    /// Asynchronously processes a JSON file containing user data and outputs the details of each user to the console.
    /// </summary>
    /// <param name="filePath">
    /// The path to the JSON file to be processed.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    /// <remarks>
    /// This method reads the JSON file, deserializes its content into a list of user objects, 
    /// and writes each user's details (ID, Name, and Active status) to the console.
    /// </remarks>
    /// <exception cref="System.IO.IOException">
    /// Thrown if an I/O error occurs while reading the file.
    /// </exception>
    /// <exception cref="System.Text.Json.JsonException">
    /// Thrown if the JSON content is invalid or cannot be deserialized.
    /// </exception>
    private static async Task ProcessJsonFileAsync(string filePath)
    {
        var users = await Samples.ReadJsonAsync(filePath);
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Active: {user.IsActive}");
        }
    }
}
