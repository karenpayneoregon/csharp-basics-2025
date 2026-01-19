#nullable disable
namespace ChinookTreeViewSample.Models;
/// <summary>
/// Represents an album with its associated tracks.
/// </summary>
/// <remarks>
/// This class is used to encapsulate album details, including its unique identifier,
/// title, and a collection of tracks associated with the album.
/// </remarks>
public class AlbumDto
{
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public List<TrackDto> Tracks { get; set; } = [];
}