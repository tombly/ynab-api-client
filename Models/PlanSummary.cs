using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public record PlanSummary
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>The last time any changes were made to the plan from either a web or mobile client</summary>
    [JsonPropertyName("last_modified_on")]
    public DateTimeOffset? LastModifiedOn { get; init; }

    /// <summary>The earliest plan month</summary>
    [JsonPropertyName("first_month")]
    public DateOnly? FirstMonth { get; init; }

    /// <summary>The latest plan month</summary>
    [JsonPropertyName("last_month")]
    public DateOnly? LastMonth { get; init; }

    [JsonPropertyName("date_format")]
    public DateFormat? DateFormat { get; init; }

    [JsonPropertyName("currency_format")]
    public CurrencyFormat? CurrencyFormat { get; init; }

    /// <summary>The plan accounts (only included if `include_accounts=true` specified as query parameter)</summary>
    [JsonPropertyName("accounts")]
    public IReadOnlyList<Account>? Accounts { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}