using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;

namespace Ynab.Api.Client.Models;

public sealed record Account
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    public required AccountType Type { get; init; }

    /// <summary>Whether this account is on budget or not</summary>
    [JsonPropertyName("on_budget")]
    public required bool OnBudget { get; init; }

    /// <summary>Whether this account is closed or not</summary>
    [JsonPropertyName("closed")]
    public required bool Closed { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    /// <summary>The current balance of the account in milliunits format</summary>
    [JsonPropertyName("balance")]
    public required long Balance { get; init; }

    /// <summary>The current cleared balance of the account in milliunits format</summary>
    [JsonPropertyName("cleared_balance")]
    public required long ClearedBalance { get; init; }

    /// <summary>The current uncleared balance of the account in milliunits format</summary>
    [JsonPropertyName("uncleared_balance")]
    public required long UnclearedBalance { get; init; }

    /// <summary>The payee id which should be used when transferring to this account</summary>
    [JsonPropertyName("transfer_payee_id")]
    public Guid? TransferPayeeId { get; init; }

    /// <summary>Whether or not the account is linked to a financial institution for automatic transaction import.</summary>
    [JsonPropertyName("direct_import_linked")]
    public bool? DirectImportLinked { get; init; }

    /// <summary>If an account linked to a financial institution (direct_import_linked=true) and the linked connection is not in a healthy state, this will be true.</summary>
    [JsonPropertyName("direct_import_in_error")]
    public bool? DirectImportInError { get; init; }

    /// <summary>A date/time specifying when the account was last reconciled.</summary>
    [JsonPropertyName("last_reconciled_at")]
    public DateTimeOffset? LastReconciledAt { get; init; }

    /// <summary>This field is deprecated and will always be null.</summary>
    [JsonPropertyName("debt_original_balance")]
    public long? DebtOriginalBalance { get; init; }

    [JsonPropertyName("debt_interest_rates")]
    public LoanAccountPeriodicValue? DebtInterestRates { get; init; }

    [JsonPropertyName("debt_minimum_payments")]
    public LoanAccountPeriodicValue? DebtMinimumPayments { get; init; }

    [JsonPropertyName("debt_escrow_amounts")]
    public LoanAccountPeriodicValue? DebtEscrowAmounts { get; init; }

    /// <summary>Whether or not the account has been deleted.  Deleted accounts will only be included in delta requests.</summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    /// <summary>The current available balance of the account formatted in the plan's currency format</summary>
    [JsonPropertyName("balance_formatted")]
    public string? BalanceFormatted { get; init; }

    /// <summary>The current available balance of the account as a decimal currency amount</summary>
    [JsonPropertyName("balance_currency")]
    public double? BalanceCurrency { get; init; }

    /// <summary>The current cleared balance of the account formatted in the plan's currency format</summary>
    [JsonPropertyName("cleared_balance_formatted")]
    public string? ClearedBalanceFormatted { get; init; }

    /// <summary>The current cleared balance of the account as a decimal currency amount</summary>
    [JsonPropertyName("cleared_balance_currency")]
    public double? ClearedBalanceCurrency { get; init; }

    /// <summary>The current uncleared balance of the account formatted in the plan's currency format</summary>
    [JsonPropertyName("uncleared_balance_formatted")]
    public string? UnclearedBalanceFormatted { get; init; }

    /// <summary>The current uncleared balance of the account as a decimal currency amount</summary>
    [JsonPropertyName("uncleared_balance_currency")]
    public double? UnclearedBalanceCurrency { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}