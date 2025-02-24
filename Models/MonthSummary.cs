namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class MonthSummary
{

    [System.Text.Json.Serialization.JsonPropertyName("month")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset Month { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("note")]
    public string? Note { get; set; } = default!;

    /// <summary>
    /// The total amount of transactions categorized to 'Inflow: Ready to Assign' in the month
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("income")]
    public long Income { get; set; } = default!;

    /// <summary>
    /// The total amount budgeted in the month
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("budgeted")]
    public long Budgeted { get; set; } = default!;

    /// <summary>
    /// The total amount of transactions in the month, excluding those categorized to 'Inflow: Ready to Assign'
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("activity")]
    public long Activity { get; set; } = default!;

    /// <summary>
    /// The available amount for 'Ready to Assign'
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("to_be_budgeted")]
    public long To_be_budgeted { get; set; } = default!;

    /// <summary>
    /// The Age of Money as of the month
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("age_of_money")]
    public int? Age_of_money { get; set; } = default!;

    /// <summary>
    /// Whether or not the month has been deleted.  Deleted months will only be included in delta requests.
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