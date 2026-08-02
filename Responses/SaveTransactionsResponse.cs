using System.Text.Json.Serialization;
using Ynab.Api.Client.Models;

namespace Ynab.Api.Client.Responses;

public sealed record SaveTransactionsResponse
{
    /// <summary>The transaction ids that were saved</summary>
    [JsonPropertyName("transaction_ids")]
    public required IReadOnlyList<string> TransactionIds { get; init; }

    [JsonPropertyName("transaction")]
    public TransactionDetail? Transaction { get; init; }

    /// <summary>If multiple transactions were specified, the transactions that were saved</summary>
    [JsonPropertyName("transactions")]
    public IReadOnlyList<TransactionDetail>? Transactions { get; init; }

    /// <summary>If multiple transactions were specified, a list of import_ids that were not created because of an existing `import_id` found on the same account</summary>
    [JsonPropertyName("duplicate_import_ids")]
    public IReadOnlyList<string>? DuplicateImportIds { get; init; }

    /// <summary>The knowledge of the server</summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}