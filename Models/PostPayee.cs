using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PostPayee
{
    /// <summary>The name of the payee.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}
