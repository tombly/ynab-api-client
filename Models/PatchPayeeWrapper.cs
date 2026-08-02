using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PatchPayeeWrapper
{
    [JsonPropertyName("payee")]
    public required SavePayee Payee { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}