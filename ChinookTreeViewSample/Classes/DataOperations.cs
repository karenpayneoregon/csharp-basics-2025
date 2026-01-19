using ChinookTreeViewSample.Models;
using ConsoleConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace ChinookTreeViewSample.Classes;
/// <summary>
/// Performs data operations.
/// </summary>
internal class DataOperations
{

    /// <summary>
    /// Retrieves a list of albums and their associated tracks for a specific artist.
    /// </summary>
    /// <remarks>
    /// This method queries the database to fetch albums and their tracks for the artist
    /// with a predefined ID (currently set to 22). The data is grouped by album and 
    /// transformed into a list of <see cref="AlbumDto"/> objects, each containing album details
    /// and a list of associated tracks.
    /// </remarks>
    /// <returns>
    /// A list of <see cref="AlbumDto"/> objects, where each object represents an album
    /// and its associated tracks.
    /// </returns>
    public static List<AlbumDto> Album()
    {
        const string sql = """
                           SELECT Artist.ArtistId,
                                  Artist.[Name],
                                  Title,
                                  Track.[Name] AS TrackName,
                                  Album.AlbumId
                           FROM dbo.Artist
                               INNER JOIN dbo.Album
                                   ON Artist.ArtistId = Album.ArtistId
                               INNER JOIN dbo.Track
                                   ON Album.AlbumId = Track.AlbumId
                           WHERE (Artist.ArtistId = 22);
                           """;

        using IDbConnection connection = new SqlConnection(AppConnections.Instance.MainConnection);
        
        var rows = connection.Query<AlbumTrackRow>(
            sql,
            new { ArtistId = 22 }
        );

        return rows
            .GroupBy(r => r.AlbumId)
            .Select(g => new AlbumDto
            {
                AlbumId = g.Key,
                Title = g.First().Title,
                Tracks = g
                    .Select(x => new TrackDto
                    {
                        TrackName = x.TrackName
                    })
                    .ToList()
            }).ToList();
    }
}
