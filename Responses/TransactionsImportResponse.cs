using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Responses;

public sealed record TransactionsImportResponse
{
    /// <summary>The list of transaction ids that were imported.</summary>
    [JsonPropertyName("transaction_ids")]
    public required IReadOnlyList<string> TransactionIds { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}