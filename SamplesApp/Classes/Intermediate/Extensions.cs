namespace SamplesApp.Classes.Intermediate;

public static class Extensions
{
    public static (string grade, string remarks) GetGradeWithRemarks(this int score)
        => score is < 0 or > 100
            ? throw new ArgumentOutOfRangeException(nameof(score), score, "Score must be between 0 and 100")
            : score switch
            {
                >= 90 => ("A", "Great job"),
                >= 80 => ("B", "Good"),
                >= 70 => ("C", "Okay"),
                >= 60 => ("D", "Better study"),
                _ => ("F", "You failed")
            };

    public static (string, string) GetGradeWithRemarksConventional(this int score)
    {
        if (score is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(score), score, "Score must be between 0 and 100");

        switch (score)
        {
            case >= 90:
                return ("A", "Great job");
            case >= 80:
                return ("B", "Good");
            case >= 70:
                return ("C", "Okay");
            case >= 60:
                return ("D", "Better study");
            default:
                return ("F", "You failed");
        }
    }
}