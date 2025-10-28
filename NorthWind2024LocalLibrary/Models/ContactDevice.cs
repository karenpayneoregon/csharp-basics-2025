#nullable disable
using NorthWind2024LocalLibrary.Models;

namespace NorthWind2024LocalLibrary.Models;

public partial class ContactDevice
{
    public int ContactDeviceId { get; set; }

    public int? ContactId { get; set; }

    public int? PhoneTypeIdentifier { get; set; }

    public string PhoneNumber { get; set; }

    public virtual Contact Contact { get; set; }

    public virtual PhoneType PhoneTypeIdentifierNavigation { get; set; }
}