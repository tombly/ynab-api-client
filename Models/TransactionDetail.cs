using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record TransactionDetail : TransactionSummary
{
    [JsonPropertyName("account_name")]
    public required string AccountName { get; init; }

    [JsonPropertyName("payee_name")]
    public string? PayeeName { get; init; }

    /// <summary>The name of the category.  If a split transaction, this will be 'Split'.</summary>
    [JsonPropertyName("category_name")]
    public string? CategoryName { get; init; }

    /// <summary>If a split transaction, the subtransactions.</summary>
    [JsonPropertyName("subtransactions")]
    public required IReadOnlyList<SubTransaction> Subtransactions { get; init; }
}