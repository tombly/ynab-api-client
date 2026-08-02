using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;

namespace Ynab.Api.Client.Models;

public sealed record SaveScheduledTransaction
{
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>The scheduled transaction date in ISO format (e.g. 2016-12-01).  This should be a future date no more than 5 years into the future.</summary>
    [JsonPropertyName("date")]
    public required DateOnly Date { get; init; }

    /// <summary>The scheduled transaction amount in milliunits format.</summary>
    [JsonPropertyName("amount")]
    public long? Amount { get; init; }

    /// <summary>The payee for the scheduled transaction.  To create a transfer between two accounts, use the account transfer payee pointing to the target account.  Account transfer payees are specified as `transfer_payee_id` on the account resource.</summary>
    [JsonPropertyName("payee_id")]
    public Guid? PayeeId { get; init; }

    /// <summary>The payee name for the the scheduled transaction.  If a `payee_name` value is provided and `payee_id` has a null value, the `payee_name` value will be used to resolve the payee by either (1) a payee with the same name or (2) creation of a new payee.</summary>
    [JsonPropertyName("payee_name")]
    public string? PayeeName { get; init; }

    /// <summary>The category for the scheduled transaction. Credit Card Payment categories are not permitted. Creating a split scheduled transaction is not currently supported.</summary>
    [JsonPropertyName("category_id")]
    public Guid? CategoryId { get; init; }

    [JsonPropertyName("memo")]
    public string? Memo { get; init; }

    [JsonPropertyName("flag_color")]
    public TransactionFlagColor? FlagColor { get; init; }

    [JsonPropertyName("frequency")]
    public ScheduledTransactionFrequency? Frequency { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}