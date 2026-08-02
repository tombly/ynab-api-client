using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PatchTransactionsWrapper
{
    [JsonPropertyName("transactions")]
    public required IReadOnlyList<SaveTransactionWithIdOrImportId> Transactions { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}