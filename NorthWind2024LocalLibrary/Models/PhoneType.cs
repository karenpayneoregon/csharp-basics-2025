#nullable disable
using System;
using System.Collections.Generic;

namespace NorthWind2024LocalLibrary.Models;

public partial class PhoneType
{
    public int PhoneTypeIdenitfier { get; set; }

    public string PhoneTypeDescription { get; set; }

    public virtual ICollection<ContactDevice> ContactDevices { get; set; } = new List<ContactDevice>();
}