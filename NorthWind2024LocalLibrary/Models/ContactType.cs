#nullable disable
using NorthWind2024LocalLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthWind2024LocalLibrary.Models;

public partial class ContactType
{
    public int ContactTypeIdentifier { get; set; }

    [Display(Name = "Contact Title")]
    public string ContactTitle { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}