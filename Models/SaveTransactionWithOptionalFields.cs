using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;

namespace Ynab.Api.Client.Models;

public record SaveTransactionWithOptionalFields
{
    [JsonPropertyName("account_id")]
    public Guid? AccountId { get; init; }

    /// <summary>The transaction date in ISO format (e.g. 2016-12-01).  Future dates (scheduled transactions) are not permitted.  Split transaction dates cannot be changed and if a different date is supplied it will be ignored.</summary>
    [JsonPropertyName("date")]
    public DateOnly? Date { get; init; }

    /// <summary>The transaction amount in milliunits format.  Split transaction amounts cannot be changed and if a different amount is supplied it will be ignored.</summary>
    [JsonPropertyName("amount")]
    public long? Amount { get; init; }

    /// <summary>The payee for the transaction.  To create a transfer between two accounts, use the account transfer payee pointing to the target account.  Account transfer payees are specified as `transfer_payee_id` on the account resource.</summary>
    [JsonPropertyName("payee_id")]
    public Guid? PayeeId { get; init; }

    /// <summary>The payee name.  If a `payee_name` value is provided and `payee_id` has a null value, the `payee_name` value will be used to resolve the payee by either (1) a matching payee rename rule (only if `import_id` is also specified) or (2) a payee with the same name or (3) creation of a new payee.</summary>
    [JsonPropertyName("payee_name")]
    public string? PayeeName { get; init; }

    /// <summary>The category for the transaction.  To configure a split transaction, you can specify null for `category_id` and provide a `subtransactions` array as part of the transaction object.  If an existing transaction is a split, the `category_id` cannot be changed.  Credit Card Payment categories are not permitted and will be ignored if supplied.</summary>
    [JsonPropertyName("category_id")]
    public Guid? CategoryId { get; init; }

    [JsonPropertyName("memo")]
    public string? Memo { get; init; }

    [JsonPropertyName("cleared")]
    public TransactionClearedStatus? Cleared { get; init; }

    /// <summary>Whether or not the transaction is approved.  If not supplied, transaction will be unapproved by default.</summary>
    [JsonPropertyName("approved")]
    public bool? Approved { get; init; }

    [JsonPropertyName("flag_color")]
    public TransactionFlagColor? FlagColor { get; init; }

    /// <summary>An array of subtransactions to configure a transaction as a split. Updating `subtransactions` on an existing split transaction is not supported.</summary>
    [JsonPropertyName("subtransactions")]
    public IReadOnlyList<SaveSubTransaction>? Subtransactions { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}