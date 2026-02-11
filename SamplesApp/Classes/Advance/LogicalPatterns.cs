namespace SamplesApp.Classes.Advance;
public static class LogicalPatterns
{
    public static string ClassifyTemperature(this double temp) => temp switch
    {
        < 0 => "Bitterly cold",
        >= 0 and < 20 => "Chilly",
        >= 20 and < 30 => "Comfortably warm",
        >= 30 and not 100 => "Uncomfortably hot",
        100 => "At the boiling point",
        _ => "Dangerously extreme"
    };
}
