using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record User
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}