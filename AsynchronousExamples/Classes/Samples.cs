using AsynchronousExamples.Models;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace AsynchronousExamples.Classes;
internal class Samples
{

    /// <summary>
    /// Asynchronously generates a sequence of integers from 1 to 10, with a delay between each number.
    /// </summary>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// An <see cref="IAsyncEnumerable{T}"/> that produces integers from 1 to 10, one at a time.
    /// </returns>
    /// <exception cref="OperationCanceledException">
    /// Thrown if the operation is canceled via the provided <paramref name="cancellationToken"/>.
    /// </exception>
    public static async IAsyncEnumerable<int> GetNumbersAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        for (var index = 1; index <= 10; index++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(500, cancellationToken);
            yield return index;
        }
    }

    /// <summary>
    /// Asynchronously reads a JSON file from the specified file path and deserializes its content into a list of user objects.
    /// </summary>
    /// <param name="filePath">
    /// The path to the JSON file to be read.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a list of <see cref="User"/> objects deserialized from the JSON file.
    /// </returns>
    /// <exception cref="System.IO.IOException">
    /// Thrown if an I/O error occurs while reading the file.
    /// </exception>
    /// <exception cref="System.Text.Json.JsonException">
    /// Thrown if the JSON content is invalid or cannot be deserialized into a list of <see cref="User"/> objects.
    /// </exception>
    public static async Task<List<User>> ReadJsonAsync(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<User>>(json)!;
    }

}