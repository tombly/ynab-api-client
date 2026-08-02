using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PostTransactionsWrapper
{
    [JsonPropertyName("transaction")]
    public NewTransaction? Transaction { get; init; }

    [JsonPropertyName("transactions")]
    public IReadOnlyList<NewTransaction>? Transactions { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}