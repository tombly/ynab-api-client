using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record SavePayee
{
    /// <summary>The name of the payee. The name must be a maximum of 500 characters.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}