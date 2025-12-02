using System.Security.Cryptography;
using System.Text;

namespace ExperimentsApp.Classes;

/// <summary>
/// Provides utility methods for hashing and validating strings using the SHA-256 algorithm.
/// </summary>
public static class HashUtility
{
    /// <summary>
    /// Computes the SHA-256 hash of the specified input string.
    /// </summary>
    /// <param name="input">
    /// The input string to hash. Must not be <c>null</c>.
    /// </param>
    /// <returns>
    /// A byte array containing the SHA-256 hash of the input string.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="input"/> is <c>null</c>.
    /// </exception>
    public static byte[] HashString(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        // Compute and return the SHA-256 hash of the UTF-8 bytes of the input string.
        return SHA256.HashData(Encoding.UTF8.GetBytes(input));
    }

    /// <summary>
    /// Validates whether the SHA-256 hash of the specified input string matches the expected hash.
    /// </summary>
    /// <param name="input">
    /// The input string to validate. Must not be <c>null</c>.
    /// </param>
    /// <param name="expectedHash">
    /// The expected SHA-256 hash to compare against. Must not be <c>null</c>.
    /// </param>
    /// <returns>
    /// <c>true</c> if the computed hash of the input string matches the <paramref name="expectedHash"/>; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="expectedHash"/> is <c>null</c>.
    /// </exception>
    public static bool ValidateString(string input, byte[] expectedHash)
    {
        ArgumentNullException.ThrowIfNull(expectedHash);

        byte[] newHash = HashString(input);

        // Constant-time comparison to avoid timing attacks
        return CryptographicOperations.FixedTimeEquals(newHash, expectedHash);
    }
}
