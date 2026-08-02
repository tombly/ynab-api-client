using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record Payee
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>If a transfer payee, the `account_id` to which this payee transfers to</summary>
    [JsonPropertyName("transfer_account_id")]
    public string? TransferAccountId { get; init; }

    /// <summary>Whether or not the payee has been deleted.  Deleted payees will only be included in delta requests.</summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}