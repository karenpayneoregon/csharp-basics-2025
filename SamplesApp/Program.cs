using BogusLibrary.Classes;
using BogusLibrary.Models;

namespace SamplesApp;
internal partial class Program
{
    static void Main(string[] args)
    {

        SpectreConsoleHelpers.ExitPrompt();
    }

    private static void DisplayHumanDetails()
    {
        List<Human> humans = BogusOperations.GenerateHumans(2);
        foreach (var human in humans)
        {
            Console.WriteLine($"Name: {human.FirstName, -20} {human.LastName,-20}{human.Gender,-7}{human.BirthDay:d}  {human.SocialSecurityNumber}");
            Console.WriteLine($"\t{human.Address.Street}, {human.Address.City}, {human.Address.State} {human.Address.ZipCode}, {human.Address.Country}");
            SpectreConsoleHelpers.LineSeparator();
        }
    }
}

