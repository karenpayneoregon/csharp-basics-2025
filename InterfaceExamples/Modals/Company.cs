#pragma warning disable CS8618
namespace InterfaceExamples.Modals;

/// <summary>
/// Represents a company entity with properties for identification and name.
/// </summary>
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}