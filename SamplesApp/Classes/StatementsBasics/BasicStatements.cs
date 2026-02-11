using BogusLibrary.Classes;
using BogusLibrary.Models;
using Spectre.Console;
using CommonHelpersLibrary;

namespace SamplesApp.Classes.StatementsBasics;
internal class BasicStatements
{
    public static void DisplayHumanDetails()
    {
        
        SpectreConsoleHelpers.PrintPink();

        List<Human> humans = HumanGenerator.Create(20);
        foreach (var human in humans)
        {
            Console.WriteLine($"Name: {human.FirstName,-20} {human.LastName,-20}{human.Gender,-7}{human.BirthDay:d}  {human.SocialSecurityNumber}");
            Console.WriteLine($"\t{human.Address.Street}, {human.Address.City}, {human.Address.State} {human.Address.ZipCode}, {human.Address.Country}");
            SpectreConsoleHelpers.LineSeparator();
        }
    }


    /// <summary>
    /// Generates a sequence of integers starting at 0 and continuing up to the
    /// specified <paramref name="max"/> value, but never returning values greater
    /// than 10. If <paramref name="max"/> exceeds 10, iteration stops early.
    /// </summary>
    /// <param name="max">
    /// The upper bound to iterate to. The method will stop at 10 even if this
    /// value is larger.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{Int32}"/> containing numbers from 0 up to either
    /// <paramref name="max"/> or 10, whichever comes first.
    /// </returns>
    /// <remarks>
    /// <para>
    /// This method uses <c>yield return</c> to produce values lazily. As soon as the
    /// internal counter passes 10, the method issues <c>yield break</c> and iteration
    /// ends.
    /// </para>
    /// <para>Example usage:</para>
    /// <code>
    /// foreach (var number in GetNumbersUpToTenYieldBasic(25))
    /// {
    ///     Console.WriteLine(number);
    /// }
    ///
    /// // Output:
    /// // 0
    /// // 1
    /// // 2
    /// // ...
    /// // 10
    /// </code>
    /// </remarks>
    public static IEnumerable<int> GetNumbersUpToTenYieldBasic(int max)
    {

        SpectreConsoleHelpers.PrintPink();

        for (int index = 0; index <= max; index++)
        {
            if (index > 10)
            {
                yield break; // Stop iteration if index exceeds 10
            }
            
            yield return index;
            
        }
    }

    public static IEnumerable<Human> GetFirstMale()
    {
        SpectreConsoleHelpers.PrintPink();

        List<Human> humans = HumanGenerator.Create(20);

        for (int index = 0; index < humans.Count; index++)
        {
            if (humans[index].Gender is not Gender.Male)
            {
                yield break;
            }
            
            yield return humans[index];
            
        }
        
    }

    /// <summary>
    /// ✔️ Demonstrates a basic conditional statement to process a list of humans,
    /// filtering by gender and performing specific actions based on the first name.
    /// </summary>
    /// <remarks>
    /// This method generates a list of humans, filters for females, and checks
    /// if their first name matches "Bertha" (case-insensitive). If a match is found,
    /// it prints a specific message; otherwise, it prints a generic message for females.
    /// </remarks>
    public static void IfGenderStatementBasic()
    {

        SpectreConsoleHelpers.PrintPink();

        List<Human> humans = HumanGenerator.Create(20);

        foreach (var human in humans)
        {

            // Skip if not female
            if (human.Gender is not Gender.Female) continue;

            if (string.Equals(human.FirstName, "bertha", StringComparison.OrdinalIgnoreCase))
            {
                AnsiConsole.MarkupLine($"[cyan]Found Bertha[/]: {human.FirstName} {human.LastName}");
            }
            else
            {
                AnsiConsole.MarkupLine($"[grey]Female Name:[/]: {human.FirstName} {human.LastName}");
            }

        }
    }

    /// <summary>
    /// Processes a list of <see cref="Human"/> objects, filtering and displaying information 
    /// about females based on specific conditions.
    /// </summary>
    /// <remarks>
    /// This method generates a list of humans using <see cref="HumanGenerator.Create(int,bool)"/>, 
    /// filters the list to include only females, and displays formatted messages in the console 
    /// using <see cref="SpectreConsoleHelpers.PrintPink"/> and <see cref="AnsiConsole.MarkupLine(string)"/>.
    /// </remarks>
    public static void IfGenderStatementMedium()
    {
        SpectreConsoleHelpers.PrintPink();

        List<Human> humans = HumanGenerator.Create(20);

        foreach (var human in humans)
        {

            // Skip if not female
            if (human.Gender is not Gender.Female) continue;

            var message = human switch
            {
                { Gender: Gender.Female, FirstName: var firstName }
                    when firstName.Equals("bertha", StringComparison.OrdinalIgnoreCase)
                    => $"[cyan]Found Bertha[/]: {human.FirstName} {human.LastName}",
                { Gender: Gender.Female } => $"[grey]Female Name:[/]: {human.FirstName} {human.LastName}",

                _ => string.Empty
            };

            if (!string.IsNullOrWhiteSpace(message)) AnsiConsole.MarkupLine(message);
        }
    }

    /// <summary>
    /// Processes a list of humans, identifying specific individuals or groups based on their gender and name.
    /// </summary>
    /// <remarks>
    /// This method generates a list of humans and uses pattern matching to:
    /// - Identify a specific female named "Bertha" (case-insensitive).
    /// - Display messages for other females.
    /// The results are printed to the console using Spectre.Console.
    /// </remarks>
    public static void IfGenderStatementAdvance()
    {
        SpectreConsoleHelpers.PrintPink();

        List<Human> humans = HumanGenerator.Create(20);

        foreach (var human in humans)
        {
            var message = human switch
            {
                // Skip if not female check, no continue needed
                { Gender: Gender.Female, FirstName: var firstName }
                    when firstName.Equals("bertha", StringComparison.OrdinalIgnoreCase)
                    => $"[cyan]Found Bertha[/]: {human.FirstName} {human.LastName}",

                { Gender: Gender.Female }
                    => $"[grey]Female Name:[/]: {human.FirstName} {human.LastName}",

                _ => null
            };

            if (message is not null)
                AnsiConsole.MarkupLine(message);
        }
    }

    /*
     * This method demonstrates a compact approach to processing a list of humans but can be harder to read, maintain and debug.
     */
    public static void IfGenderStatementCompact() =>
        HumanGenerator
            .Create(20)
            .Select(human => human switch
            {
                { Gender: Gender.Female, FirstName: var firstName }
                    when firstName.Equals("bertha", StringComparison.OrdinalIgnoreCase)
                    => $"[cyan]Found Bertha[/]: {human.FirstName} {human.LastName}",

                { Gender: Gender.Female }
                    => $"[grey]Female Name:[/]: {human.FirstName} {human.LastName}",

                _ => null
            })
            .Where(msg => msg is not null)
            .ToList()
            .ForEach(msg => AnsiConsole.MarkupLine(msg!));


    public static void IfBirthYearStatementTeachVersion()
    {
        SpectreConsoleHelpers.PrintPink();

        List<Human> humans = HumanGenerator.Create(20);

        foreach (var h in humans)
        {
            if (h.BirthDay.HasValue)
            {
                var year = h.BirthDay.Value.Year;

                if (year is >= 1950 and <= 1980)
                {
                    Console.WriteLine($"{h.FirstName,-15}{h.LastName,-15}{h.BirthDay,-12:MM/dd/yyyy}{h.BirthDay.GetAge()}");
                }
            }
        }
    }

    /// <summary>
    /// Filters and displays details of humans born between the years 1950 and 1980.
    /// </summary>
    /// <remarks>
    /// This method generates a list of humans and iterates through them to check if their 
    /// <see cref="Human.BirthDay"/> property has a value. If the birth year falls within the range 
    /// of 1950 to 1980, their details are printed to the console.
    /// </remarks>
    public static void IfBirthYearStatementBasic()
    {
        SpectreConsoleHelpers.PrintPink();

        List<Human> humans = HumanGenerator.Create(20);

        foreach (var h in humans)
        {
            if (h.BirthDay.HasValue)
            {
                var year = h.BirthDay.Value.Year;

                if (year is >= 1950 and <= 1980)
                {
                    Console.WriteLine($"{h.FirstName,-15}{h.LastName,-15}{h.BirthDay,-12:MM/dd/yyyy}{h.BirthDay.GetAge()}");
                }
            }
        }
    }

    public static void IfBirthYearStatementAdvanced()
    {
        SpectreConsoleHelpers.PrintPink();

        List<Human> humans = HumanGenerator.Create(20);

        foreach ((int Index, Human h) in humans.Index())
        {
            if (h.BirthDay is { Year: >= 1950 and <= 1980 })
            {
                Console.WriteLine($"{h.FirstName,-15}{h.LastName,-15}{h.BirthDay,-12:MM/dd/yyyy}{h.BirthDay.GetAge()}");
            }
        }
    }
}
