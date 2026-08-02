using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PayeeLocation
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("payee_id")]
    public required Guid PayeeId { get; init; }

    [JsonPropertyName("latitude")]
    public required string Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public required string Longitude { get; init; }

    /// <summary>Whether or not the payee location has been deleted.  Deleted payee locations will only be included in delta requests.</summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}