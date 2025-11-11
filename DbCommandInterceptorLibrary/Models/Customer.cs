namespace DbCommandInterceptorLibrary.Models;
#nullable disable
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly JoinDate { get; set; }
}