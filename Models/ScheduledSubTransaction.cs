using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record ScheduledSubTransaction
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("scheduled_transaction_id")]
    public required Guid ScheduledTransactionId { get; init; }

    /// <summary>The scheduled subtransaction amount in milliunits format</summary>
    [JsonPropertyName("amount")]
    public required long Amount { get; init; }

    [JsonPropertyName("memo")]
    public string? Memo { get; init; }

    [JsonPropertyName("payee_id")]
    public Guid? PayeeId { get; init; }

    [JsonPropertyName("payee_name")]
    public string? PayeeName { get; init; }

    [JsonPropertyName("category_id")]
    public Guid? CategoryId { get; init; }

    [JsonPropertyName("category_name")]
    public string? CategoryName { get; init; }

    /// <summary>If a transfer, the account_id which the scheduled subtransaction transfers to</summary>
    [JsonPropertyName("transfer_account_id")]
    public Guid? TransferAccountId { get; init; }

    /// <summary>Whether or not the scheduled subtransaction has been deleted. Deleted scheduled subtransactions will only be included in delta requests.</summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    /// <summary>The scheduled subtransaction amount formatted in the plan's currency format</summary>
    [JsonPropertyName("amount_formatted")]
    public string? AmountFormatted { get; init; }

    /// <summary>The scheduled subtransaction amount as a decimal currency amount</summary>
    [JsonPropertyName("amount_currency")]
    public double? AmountCurrency { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}