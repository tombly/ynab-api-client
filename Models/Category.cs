namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Category
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid Id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("category_group_id")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid Category_group_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("category_group_name")]
    public string? Category_group_name { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Whether or not the category is hidden
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("hidden")]
    public bool Hidden { get; set; } = default!;

    /// <summary>
    /// DEPRECATED: No longer used.  Value will always be null.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("original_category_group_id")]
    public System.Guid? Original_category_group_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("note")]
    public string? Note { get; set; } = default!;

    /// <summary>
    /// Budgeted amount in milliunits format
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("budgeted")]
    public long Budgeted { get; set; } = default!;

    /// <summary>
    /// Activity amount in milliunits format
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("activity")]
    public long Activity { get; set; } = default!;

    /// <summary>
    /// Balance in milliunits format
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("balance")]
    public long Balance { get; set; } = default!;

    /// <summary>
    /// The type of goal, if the category has a goal (TB='Target Category Balance', TBD='Target Category Balance by Date', MF='Monthly Funding', NEED='Plan Your Spending')
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_type")]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public CategoryGoalType? Goal_type { get; set; } = default!;

    /// <summary>
    /// Indicates the monthly rollover behavior for "NEED"-type goals. When "true", the goal will always ask for the target amount in the new month ("Set Aside"). When "false", previous month category funding is used ("Refill"). For other goal types, this field will be null.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_needs_whole_amount")]
    public bool? Goal_needs_whole_amount { get; set; } = default!;

    /// <summary>
    /// A day offset modifier for the goal's due date. When goal_cadence is 2 (Weekly), this value specifies which day of the week the goal is due (0 = Sunday, 6 = Saturday). Otherwise, this value specifies which day of the month the goal is due (1 = 1st, 31 = 31st, null = Last day of Month).
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_day")]
    public int? Goal_day { get; set; } = default!;

    /// <summary>
    /// The goal cadence. Value in range 0-14. There are two subsets of these values which behave differently. For values 0, 1, 2, and 13, the goal's due date repeats every goal_cadence * goal_cadence_frequency, where 0 = None, 1 = Monthly, 2 = Weekly, and 13 = Yearly. For example, goal_cadence 1 with goal_cadence_frequency 2 means the goal is due every other month. For values 3-12 and 14, goal_cadence_frequency is ignored and the goal's due date repeats every goal_cadence, where 3 = Every 2 Months, 4 = Every 3 Months, ..., 12 = Every 11 Months, and 14 = Every 2 Years.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_cadence")]
    public int? Goal_cadence { get; set; } = default!;

    /// <summary>
    /// The goal cadence frequency. When goal_cadence is 0, 1, 2, or 13, a goal's due date repeats every goal_cadence * goal_cadence_frequency. For example, goal_cadence 1 with goal_cadence_frequency 2 means the goal is due every other month.  When goal_cadence is 3-12 or 14, goal_cadence_frequency is ignored.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_cadence_frequency")]
    public int? Goal_cadence_frequency { get; set; } = default!;

    /// <summary>
    /// The month a goal was created
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_creation_month")]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset? Goal_creation_month { get; set; } = default!;

    /// <summary>
    /// The goal target amount in milliunits
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_target")]
    public long? Goal_target { get; set; } = default!;

    /// <summary>
    /// The original target month for the goal to be completed.  Only some goal types specify this date.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_target_month")]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset? Goal_target_month { get; set; } = default!;

    /// <summary>
    /// The percentage completion of the goal
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_percentage_complete")]
    public int? Goal_percentage_complete { get; set; } = default!;

    /// <summary>
    /// The number of months, including the current month, left in the current goal period.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_months_to_budget")]
    public int? Goal_months_to_budget { get; set; } = default!;

    /// <summary>
    /// The amount of funding still needed in the current month to stay on track towards completing the goal within the current goal period. This amount will generally correspond to the 'Underfunded' amount in the web and mobile clients except when viewing a category with a Needed for Spending Goal in a future month.  The web and mobile clients will ignore any funding from a prior goal period when viewing category with a Needed for Spending Goal in a future month.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_under_funded")]
    public long? Goal_under_funded { get; set; } = default!;

    /// <summary>
    /// The total amount funded towards the goal within the current goal period.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_overall_funded")]
    public long? Goal_overall_funded { get; set; } = default!;

    /// <summary>
    /// The amount of funding still needed to complete the goal within the current goal period.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("goal_overall_left")]
    public long? Goal_overall_left { get; set; } = default!;

    /// <summary>
    /// Whether or not the category has been deleted.  Deleted categories will only be included in delta requests.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("deleted")]
    public bool Deleted { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}