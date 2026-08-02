using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record SaveSubTransaction
{
    /// <summary>The subtransaction amount in milliunits format.</summary>
    [JsonPropertyName("amount")]
    public required long Amount { get; init; }

    /// <summary>The payee for the subtransaction.</summary>
    [JsonPropertyName("payee_id")]
    public Guid? PayeeId { get; init; }

    /// <summary>The payee name.  If a `payee_name` value is provided and `payee_id` has a null value, the `payee_name` value will be used to resolve the payee by either (1) a matching payee rename rule (only if import_id is also specified on parent transaction) or (2) a payee with the same name or (3) creation of a new payee.</summary>
    [JsonPropertyName("payee_name")]
    public string? PayeeName { get; init; }

    /// <summary>The category for the subtransaction.  Credit Card Payment categories are not permitted and will be ignored if supplied.</summary>
    [JsonPropertyName("category_id")]
    public Guid? CategoryId { get; init; }

    [JsonPropertyName("memo")]
    public string? Memo { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}