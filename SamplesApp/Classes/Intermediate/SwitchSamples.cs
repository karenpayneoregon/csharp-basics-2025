using System.Text.Json;

namespace SamplesApp.Classes.Intermediate;
internal class SwitchSamples
{
    public static void GradesTuple()
    {
        int[] scores = [95, 82, 70, 65, 40, 100];

        foreach (var score in scores)
        {
            try
            {
                var (grade, remarks) = score.GetGradeWithRemarks();
                Console.WriteLine($"Score: {score}, Grade: {grade}, Remarks: {remarks}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error processing score {score}: {ex.Message}");
            }
        }
    }

    public static void Greeting()
    {
        Console.WriteLine(TimeOfDay());
    }

    public static void GroupBook()
    {
        var books = JsonSerializer.Deserialize<List<Book>>(Books);
        
        if (books is null) return;
        
        Dictionary<string, IGrouping<string, Book>> results = books
            .GroupBy(book => book.Price switch
            {
                <= 10 => "Cheap",
                > 10 and <= 20 => "Medium",
                _ => "Expensive"
            })
            .ToDictionary(gb => gb.Key, g => g);
        
        foreach ((string pricingCategory, IGrouping<string, Book> bookGrouping) in results)
        {
            Console.WriteLine(pricingCategory);
            foreach (var book in bookGrouping)
            {
                Console.WriteLine($"\t{book.Title,-25}{book.Price:C2}");
            }
        }
    }

    public static string TimeOfDay() => DateTime.Now.Hour switch
    {
        <= 12 => "Good Morning",
        <= 16 => "Good Afternoon",
        <= 20 => "Good Evening",
        _ => "Good Night"
    };

    public static string TimeOfDayConventional()
    {
        switch (DateTime.Now.Hour)
        {
            case <= 12:
                return "Good Morning";
            case <= 16:
                return "Good Afternoon";
            case <= 20:
                return "Good Evening";
            default:
                return "Good Night";
        }
    }

    public static string Books =>
        /*lang=json,strict */
        """
        [
          {
            "Id": 1,
            "Title": "Learn EF Core",
            "Price": 19
          },
          {
            "Id": 2,
            "Title": "C# Basics",
            "Price": 18
          },
          {
            "Id": 3,
            "Title": "ASP.NET Core advance",
            "Price": 30
          },
          {
            "Id": 4,
            "Title": "VB.NET To C#",
            "Price": 9
          },
          {
            "Id": 5,
            "Title": "Basic Azure",
            "Price": 59
          }
        ]
        """;
}

public  class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public decimal? Price { get; set; }
}