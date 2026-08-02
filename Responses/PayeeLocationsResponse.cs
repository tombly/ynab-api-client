using System.Text.Json.Serialization;
using Ynab.Api.Client.Models;

namespace Ynab.Api.Client.Responses;

public sealed record PayeeLocationsResponse
{
    [JsonPropertyName("payee_locations")]
    public required IReadOnlyList<PayeeLocation> PayeeLocations { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}