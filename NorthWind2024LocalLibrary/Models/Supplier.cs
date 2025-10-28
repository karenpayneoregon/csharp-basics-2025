﻿#nullable disable
using System;
using System.Collections.Generic;

namespace NorthWind2024LocalLibrary.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string CompanyName { get; set; }

    public string ContactName { get; set; }

    public string ContactTitle { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string Region { get; set; }

    public int RegionId { get; set; }

    public string PostalCode { get; set; }

    public int? CountryIdentifier { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public string HomePage { get; set; }

    public virtual Country CountryIdentifierNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual SupplierRegion RegionNavigation { get; set; }
}