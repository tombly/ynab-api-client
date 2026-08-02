using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record MoneyMovement
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>The month of the money movement in ISO format (e.g. 2024-01-01)</summary>
    [JsonPropertyName("month")]
    public DateOnly? Month { get; init; }

    /// <summary>The date/time the money movement was processed on the server in ISO format (e.g. 2024-01-01T12:00:00Z)</summary>
    [JsonPropertyName("moved_at")]
    public DateTimeOffset? MovedAt { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    /// <summary>The id of the money movement group this movement belongs to</summary>
    [JsonPropertyName("money_movement_group_id")]
    public Guid? MoneyMovementGroupId { get; init; }

    /// <summary>The id of the user who performed the money movement</summary>
    [JsonPropertyName("performed_by_user_id")]
    public Guid? PerformedByUserId { get; init; }

    /// <summary>The id of the category the money was moved from</summary>
    [JsonPropertyName("from_category_id")]
    public Guid? FromCategoryId { get; init; }

    /// <summary>The id of the category the money was moved to</summary>
    [JsonPropertyName("to_category_id")]
    public Guid? ToCategoryId { get; init; }

    /// <summary>The amount of the money movement in milliunits format</summary>
    [JsonPropertyName("amount")]
    public required long Amount { get; init; }

    /// <summary>The money movement amount formatted in the plan's currency format</summary>
    [JsonPropertyName("amount_formatted")]
    public string? AmountFormatted { get; init; }

    /// <summary>The money movement amount as a decimal currency amount</summary>
    [JsonPropertyName("amount_currency")]
    public double? AmountCurrency { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}
