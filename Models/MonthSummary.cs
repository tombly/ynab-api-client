using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public record MonthSummary
{
    [JsonPropertyName("month")]
    public required DateOnly Month { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    /// <summary>The total amount of transactions categorized to 'Inflow: Ready to Assign' in the month</summary>
    [JsonPropertyName("income")]
    public required long Income { get; init; }

    /// <summary>The total amount budgeted in the month</summary>
    [JsonPropertyName("budgeted")]
    public required long Budgeted { get; init; }

    /// <summary>The total amount of transactions in the month, excluding those categorized to 'Inflow: Ready to Assign'</summary>
    [JsonPropertyName("activity")]
    public required long Activity { get; init; }

    /// <summary>The available amount for 'Ready to Assign'</summary>
    [JsonPropertyName("to_be_budgeted")]
    public required long ToBeBudgeted { get; init; }

    /// <summary>The Age of Money as of the month</summary>
    [JsonPropertyName("age_of_money")]
    public int? AgeOfMoney { get; init; }

    /// <summary>Whether or not the month has been deleted.  Deleted months will only be included in delta requests.</summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    /// <summary>The total income formatted in the plan's currency format</summary>
    [JsonPropertyName("income_formatted")]
    public string? IncomeFormatted { get; init; }

    /// <summary>The total income as a decimal currency amount</summary>
    [JsonPropertyName("income_currency")]
    public double? IncomeCurrency { get; init; }

    /// <summary>The total amount assigned formatted in the plan's currency format</summary>
    [JsonPropertyName("budgeted_formatted")]
    public string? BudgetedFormatted { get; init; }

    /// <summary>The total amount assigned as a decimal currency amount</summary>
    [JsonPropertyName("budgeted_currency")]
    public double? BudgetedCurrency { get; init; }

    /// <summary>The total activity amount formatted in the plan's currency format</summary>
    [JsonPropertyName("activity_formatted")]
    public string? ActivityFormatted { get; init; }

    /// <summary>The total activity amount as a decimal currency amount</summary>
    [JsonPropertyName("activity_currency")]
    public double? ActivityCurrency { get; init; }

    /// <summary>The available amount for 'Ready to Assign' formatted in the plan's currency format</summary>
    [JsonPropertyName("to_be_budgeted_formatted")]
    public string? ToBeBudgetedFormatted { get; init; }

    /// <summary>The available amount for 'Ready to Assign' as a decimal currency amount</summary>
    [JsonPropertyName("to_be_budgeted_currency")]
    public double? ToBeBudgetedCurrency { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}