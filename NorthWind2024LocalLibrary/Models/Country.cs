#nullable disable


namespace NorthWind2024LocalLibrary.Models;

public partial class Country
{
    public int CountryIdentifier { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}