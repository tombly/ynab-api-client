using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record ScheduledTransactionDetail : ScheduledTransactionSummary
{
    [JsonPropertyName("account_name")]
    public required string AccountName { get; init; }

    [JsonPropertyName("payee_name")]
    public string? PayeeName { get; init; }

    /// <summary>The name of the category.  If a split scheduled transaction, this will be 'Split'.</summary>
    [JsonPropertyName("category_name")]
    public string? CategoryName { get; init; }

    /// <summary>If a split scheduled transaction, the subtransactions.</summary>
    [JsonPropertyName("subtransactions")]
    public required IReadOnlyList<ScheduledSubTransaction> Subtransactions { get; init; }
}