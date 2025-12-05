namespace ExperimentsApp.Models;
public class Member
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public override string ToString() => Id.ToString();
}