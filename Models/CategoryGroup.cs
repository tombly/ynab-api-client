using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public record CategoryGroup
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Whether or not the category group is hidden</summary>
    [JsonPropertyName("hidden")]
    public required bool Hidden { get; init; }

    /// <summary>Whether or not the category group is internal</summary>
    [JsonPropertyName("internal")]
    public required bool Internal { get; init; }

    /// <summary>Whether or not the category group has been deleted.  Deleted category groups will only be included in delta requests.</summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}