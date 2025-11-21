namespace SamplesApp.Classes.ReSharper;
public class DateTimeExtensions
{
    public static (DateOnly saturday, DateOnly sunday) GetWeekendDates(DateTime date, DayOfWeek startOfWeek = DayOfWeek.Sunday)
    {
        int diff = ((int)date.DayOfWeek - (int)startOfWeek + 7) % 7;
        var weekStart = date.AddDays(-diff);

        var saturday = weekStart.AddDays(6);  // 6 = Saturday offset when startOfWeek = Sunday
        var sunday = weekStart.AddDays(7);    // next day

        return (DateOnly.FromDateTime(saturday),
            DateOnly.FromDateTime(sunday));
    }

    public static (DateOnly saturday, DateOnly sunday) GetPreviousWeekendDates( DateTime date, DayOfWeek startOfWeek = DayOfWeek.Sunday)
        => GetWeekendDates(date.AddDays(-7), startOfWeek);

    public static (DateOnly saturday, DateOnly sunday) GetNextWeekendDates( DateTime date, DayOfWeek startOfWeek = DayOfWeek.Sunday)
        => GetWeekendDates(date.AddDays(7), startOfWeek);


}