using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;

namespace Ynab.Api.Client.Models;

public record ScheduledTransactionSummary
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>The first date for which the Scheduled Transaction was scheduled.</summary>
    [JsonPropertyName("date_first")]
    public required DateOnly DateFirst { get; init; }

    /// <summary>The next date for which the Scheduled Transaction is scheduled.</summary>
    [JsonPropertyName("date_next")]
    public required DateOnly DateNext { get; init; }

    [JsonPropertyName("frequency")]
    public required ScheduledTransactionFrequency Frequency { get; init; }

    /// <summary>The scheduled transaction amount in milliunits format</summary>
    [JsonPropertyName("amount")]
    public required long Amount { get; init; }

    [JsonPropertyName("memo")]
    public string? Memo { get; init; }

    [JsonPropertyName("flag_color")]
    public TransactionFlagColor? FlagColor { get; init; }

    [JsonPropertyName("flag_name")]
    public string? FlagName { get; init; }

    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    [JsonPropertyName("payee_id")]
    public Guid? PayeeId { get; init; }

    [JsonPropertyName("category_id")]
    public Guid? CategoryId { get; init; }

    /// <summary>If a transfer, the account_id which the scheduled transaction transfers to</summary>
    [JsonPropertyName("transfer_account_id")]
    public Guid? TransferAccountId { get; init; }

    /// <summary>Whether or not the scheduled transaction has been deleted.  Deleted scheduled transactions will only be included in delta requests.</summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    /// <summary>The scheduled transaction amount formatted in the plan's currency format</summary>
    [JsonPropertyName("amount_formatted")]
    public string? AmountFormatted { get; init; }

    /// <summary>The scheduled transaction amount as a decimal currency amount</summary>
    [JsonPropertyName("amount_currency")]
    public double? AmountCurrency { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}