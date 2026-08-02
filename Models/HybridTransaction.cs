using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;

namespace Ynab.Api.Client.Models;

public sealed record HybridTransaction : TransactionSummary
{
    /// <summary>Whether the hybrid transaction represents a regular transaction or a subtransaction</summary>
    [JsonPropertyName("type")]
    public required HybridTransactionType Type { get; init; }

    /// <summary>For subtransaction types, this is the id of the parent transaction.  For transaction types, this id will be always be null.</summary>
    [JsonPropertyName("parent_transaction_id")]
    public string? ParentTransactionId { get; init; }

    [JsonPropertyName("account_name")]
    public required string AccountName { get; init; }

    [JsonPropertyName("payee_name")]
    public string? PayeeName { get; init; }

    /// <summary>The name of the category.  If a split transaction, this will be 'Split'.</summary>
    [JsonPropertyName("category_name")]
    public string? CategoryName { get; init; }
}