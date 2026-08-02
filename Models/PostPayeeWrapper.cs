using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PostPayeeWrapper
{
    [JsonPropertyName("payee")]
    public required PostPayee Payee { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}
