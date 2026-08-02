using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PutTransactionWrapper
{
    [JsonPropertyName("transaction")]
    public required ExistingTransaction Transaction { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}