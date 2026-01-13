

namespace SamplesApp.Models;
public class ElementContainer<T>
{
    public required T Value { get; set; }
    public Index StartIndex { get; set; }
    public Index EndIndex { get; set; }
    public int MonthIndex { get; set; }
    public string?[] ItemArray =>
    [
        Value.ToString(),
        MonthIndex.ToString(),
        StartIndex.ToString(),
        EndIndex.ToString()
    ];
}