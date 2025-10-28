#nullable disable

using System.ComponentModel.DataAnnotations;

namespace NorthWind2024LocalLibrary.Models;

public partial class Contact
{
    /// <summary>
    /// Id
    /// </summary>
    public int ContactId { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    /// <summary>
    /// Contact Type Identifier
    /// </summary>
    public int? ContactTypeIdentifier { get; set; }

    /// <summary>
    /// Full name
    /// </summary>
    public string FullName { get; set; }

    public virtual ICollection<ContactDevice> ContactDevices { get; set; } = new List<ContactDevice>();

    public virtual ContactType ContactTypeIdentifierNavigation { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}