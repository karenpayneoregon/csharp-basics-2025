namespace MenuSampleApp.Models;

public class MenuItem
{

    public int Id { get; set; }
    public required string Text { get; set; }
    public Action Action;
    public override string ToString() => Text;
}