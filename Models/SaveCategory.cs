using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;

namespace Ynab.Api.Client.Models;

public sealed record SaveCategory
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("category_group_id")]
    public Guid? CategoryGroupId { get; init; }

    /// <summary>The goal target amount in milliunits format.  If value is specified and goal has not already been configured for category, a monthly goal will be created for the category with this target amount.  If goal_type is not specified, it will default to 'NEED' or 'MF' for Credit Card Payment categories. When updating a category, passing null removes any existing target.</summary>
    [JsonPropertyName("goal_target")]
    public long? GoalTarget { get; init; }

    /// <summary>The goal target date in ISO format (e.g. 2016-12-01).</summary>
    [JsonPropertyName("goal_target_date")]
    public DateOnly? GoalTargetDate { get; init; }

    /// <summary>Whether the goal requires the full target amount each period. Only supported for 'NEED' goals. When true, the goal is configured as 'Set aside another...'. When false, the goal is configured as 'Refill up to...'.</summary>
    [JsonPropertyName("goal_needs_whole_amount")]
    public bool? GoalNeedsWholeAmount { get; init; }

    /// <summary>When specified, configures a recurring 'NEED' target of goal_target that repeats at this frequency, replacing any existing target. Requires goal_target. Cannot be combined with goal_target_date and is not supported for Credit Card Payment categories. Omit to leave an existing target's cadence unchanged.</summary>
    [JsonPropertyName("goal_frequency")]
    public GoalFrequency? GoalFrequency { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}