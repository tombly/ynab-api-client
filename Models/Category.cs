using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;

namespace Ynab.Api.Client.Models;

public sealed record Category
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("category_group_id")]
    public required Guid CategoryGroupId { get; init; }

    [JsonPropertyName("category_group_name")]
    public string? CategoryGroupName { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Whether or not the category is hidden</summary>
    [JsonPropertyName("hidden")]
    public required bool Hidden { get; init; }

    /// <summary>Whether or not the category is internal</summary>
    [JsonPropertyName("internal")]
    public required bool Internal { get; init; }

    /// <summary>DEPRECATED: No longer used.  Value will always be null.</summary>
    [JsonPropertyName("original_category_group_id")]
    public Guid? OriginalCategoryGroupId { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    /// <summary>Budgeted amount in milliunits format</summary>
    [JsonPropertyName("budgeted")]
    public required long Budgeted { get; init; }

    /// <summary>Activity amount in milliunits format</summary>
    [JsonPropertyName("activity")]
    public required long Activity { get; init; }

    /// <summary>Balance in milliunits format</summary>
    [JsonPropertyName("balance")]
    public required long Balance { get; init; }

    /// <summary>The type of goal, if the category has a goal (TB='Target Category Balance', TBD='Target Category Balance by Date', MF='Monthly Funding', NEED='Plan Your Spending')</summary>
    [JsonPropertyName("goal_type")]
    public CategoryGoalType? GoalType { get; init; }

    /// <summary>Indicates the monthly rollover behavior for "NEED"-type goals. When "true", the goal will always ask for the target amount in the new month ("Set Aside"). When "false", previous month category funding is used ("Refill"). For other goal types, this field will be null.</summary>
    [JsonPropertyName("goal_needs_whole_amount")]
    public bool? GoalNeedsWholeAmount { get; init; }

    /// <summary>A day offset modifier for the goal's due date. When goal_cadence is 2 (Weekly), this value specifies which day of the week the goal is due (0 = Sunday, 6 = Saturday). Otherwise, this value specifies which day of the month the goal is due (1 = 1st, 31 = 31st, null = Last day of Month).</summary>
    [JsonPropertyName("goal_day")]
    public int? GoalDay { get; init; }

    /// <summary>The goal cadence. Value in range 0-14. There are two subsets of these values which behave differently. For values 0, 1, 2, and 13, the goal's due date repeats every goal_cadence * goal_cadence_frequency, where 0 = None, 1 = Monthly, 2 = Weekly, and 13 = Yearly. For example, goal_cadence 1 with goal_cadence_frequency 2 means the goal is due every other month. For values 3-12 and 14, goal_cadence_frequency is ignored and the goal's due date repeats every goal_cadence, where 3 = Every 2 Months, 4 = Every 3 Months, ..., 12 = Every 11 Months, and 14 = Every 2 Years.</summary>
    [JsonPropertyName("goal_cadence")]
    public int? GoalCadence { get; init; }

    /// <summary>The goal cadence frequency. When goal_cadence is 0, 1, 2, or 13, a goal's due date repeats every goal_cadence * goal_cadence_frequency. For example, goal_cadence 1 with goal_cadence_frequency 2 means the goal is due every other month.  When goal_cadence is 3-12 or 14, goal_cadence_frequency is ignored.</summary>
    [JsonPropertyName("goal_cadence_frequency")]
    public int? GoalCadenceFrequency { get; init; }

    /// <summary>The month a goal was created</summary>
    [JsonPropertyName("goal_creation_month")]
    public DateOnly? GoalCreationMonth { get; init; }

    /// <summary>The goal target amount in milliunits</summary>
    [JsonPropertyName("goal_target")]
    public long? GoalTarget { get; init; }

    /// <summary>DEPRECATED: No longer used.  Use `goal_target_date` instead.</summary>
    [JsonPropertyName("goal_target_month")]
    public DateOnly? GoalTargetMonth { get; init; }

    /// <summary>The target date for the goal to be completed.  Only some goal types specify this date.</summary>
    [JsonPropertyName("goal_target_date")]
    public DateOnly? GoalTargetDate { get; init; }

    /// <summary>The percentage completion of the goal</summary>
    [JsonPropertyName("goal_percentage_complete")]
    public int? GoalPercentageComplete { get; init; }

    /// <summary>The number of months, including the current month, left in the current goal period.</summary>
    [JsonPropertyName("goal_months_to_budget")]
    public int? GoalMonthsToBudget { get; init; }

    /// <summary>The amount of funding still needed in the current month to stay on track towards completing the goal within the current goal period. This amount will generally correspond to the 'Underfunded' amount in the web and mobile clients except when viewing a category with a Needed for Spending Goal in a future month.  The web and mobile clients will ignore any funding from a prior goal period when viewing category with a Needed for Spending Goal in a future month.</summary>
    [JsonPropertyName("goal_under_funded")]
    public long? GoalUnderFunded { get; init; }

    /// <summary>The total amount funded towards the goal within the current goal period.</summary>
    [JsonPropertyName("goal_overall_funded")]
    public long? GoalOverallFunded { get; init; }

    /// <summary>The amount of funding still needed to complete the goal within the current goal period.</summary>
    [JsonPropertyName("goal_overall_left")]
    public long? GoalOverallLeft { get; init; }

    /// <summary>The date/time the goal was snoozed.  If the goal is not snoozed, this will be null.</summary>
    [JsonPropertyName("goal_snoozed_at")]
    public DateTimeOffset? GoalSnoozedAt { get; init; }

    /// <summary>Whether or not the category has been deleted.  Deleted categories will only be included in delta requests.</summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    /// <summary>Available balance of the category formatted in the plan's currency format</summary>
    [JsonPropertyName("balance_formatted")]
    public string? BalanceFormatted { get; init; }

    /// <summary>Available balance of the category as a decimal currency amount</summary>
    [JsonPropertyName("balance_currency")]
    public double? BalanceCurrency { get; init; }

    /// <summary>Activity of the category formatted in the plan's currency format</summary>
    [JsonPropertyName("activity_formatted")]
    public string? ActivityFormatted { get; init; }

    /// <summary>Activity of the category as a decimal currency amount</summary>
    [JsonPropertyName("activity_currency")]
    public double? ActivityCurrency { get; init; }

    /// <summary>Assigned (budgeted) amount of the category formatted in the plan's currency format</summary>
    [JsonPropertyName("budgeted_formatted")]
    public string? BudgetedFormatted { get; init; }

    /// <summary>Assigned (budgeted) amount of the category as a decimal currency amount</summary>
    [JsonPropertyName("budgeted_currency")]
    public double? BudgetedCurrency { get; init; }

    /// <summary>The goal target amount formatted in the plan's currency format</summary>
    [JsonPropertyName("goal_target_formatted")]
    public string? GoalTargetFormatted { get; init; }

    /// <summary>The goal target amount as a decimal currency amount</summary>
    [JsonPropertyName("goal_target_currency")]
    public double? GoalTargetCurrency { get; init; }

    /// <summary>The goal underfunded amount formatted in the plan's currency format</summary>
    [JsonPropertyName("goal_under_funded_formatted")]
    public string? GoalUnderFundedFormatted { get; init; }

    /// <summary>The goal underfunded amount as a decimal currency amount</summary>
    [JsonPropertyName("goal_under_funded_currency")]
    public double? GoalUnderFundedCurrency { get; init; }

    /// <summary>The total amount funded towards the goal formatted in the plan's currency format</summary>
    [JsonPropertyName("goal_overall_funded_formatted")]
    public string? GoalOverallFundedFormatted { get; init; }

    /// <summary>The total amount funded towards the goal as a decimal currency amount</summary>
    [JsonPropertyName("goal_overall_funded_currency")]
    public double? GoalOverallFundedCurrency { get; init; }

    /// <summary>The amount of funding still needed to complete the goal formatted in the plan's currency format</summary>
    [JsonPropertyName("goal_overall_left_formatted")]
    public string? GoalOverallLeftFormatted { get; init; }

    /// <summary>The amount of funding still needed to complete the goal as a decimal currency amount</summary>
    [JsonPropertyName("goal_overall_left_currency")]
    public double? GoalOverallLeftCurrency { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}