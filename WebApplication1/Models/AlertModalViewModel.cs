namespace WebApplication1.Models;

public class AlertModalViewModel
{
    public string Title { get; set; } = "Notice";
    public string Message { get; set; } = "An unexpected error occurred.";
    public string ButtonText { get; set; } = "OK";

    // Optional: add a Bootstrap color or icon for flexibility
    public string CssClass { get; set; } = "btn-primary";
}