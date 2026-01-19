#nullable disable

namespace ChinookTreeViewSample.Models;

/// <summary>
/// Represents a row containing album and track information.
/// </summary>
/// <remarks>
/// This class is used to map data retrieved from the database, specifically
/// combining album details and associated track information into a single object.
/// </remarks>
public class AlbumTrackRow
{
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public string TrackName { get; set; }
}