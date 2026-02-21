using System.Text.Json.Serialization;

namespace ReleaseServiceApp.Models;

public sealed class ReleasesIndexRoot
{
    [JsonPropertyName("releases-index")]
    public List<ReleaseIndexItem>? ReleasesIndex { get; set; }
}

public sealed class ReleaseIndexItem
{
    [JsonPropertyName("channel-version")]
    public string? ChannelVersion { get; set; }

    [JsonPropertyName("latest-release")]
    public string? LatestRelease { get; set; }

    [JsonPropertyName("latest-release-date")]
    public DateTime? LatestReleaseDate { get; set; }

    [JsonPropertyName("security")]
    public bool Security { get; set; }

    [JsonPropertyName("latest-runtime")]
    public string? LatestRuntime { get; set; }

    [JsonPropertyName("latest-sdk")]
    public string? LatestSdk { get; set; }

    [JsonPropertyName("product")]
    public string? Product { get; set; }

    [JsonPropertyName("support-phase")]
    public string? SupportPhase { get; set; }

    [JsonPropertyName("eol-date")]
    public DateTime? EndOfLifeDate { get; set; }

    [JsonPropertyName("release-type")]
    public string? ReleaseType { get; set; }

    [JsonPropertyName("releases.json")]
    public string? ReleasesJsonUrl { get; set; }
}