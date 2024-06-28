namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class BudgetSummary
{
    [System.Text.Json.Serialization.JsonPropertyName("id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid Id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Name { get; set; } = default!;

    /// <summary>
    /// The last time any changes were made to the budget from either a web or mobile client
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("last_modified_on")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.DateTimeOffset? Last_modified_on { get; set; } = default!;

    /// <summary>
    /// The earliest budget month
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("first_month")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset? First_month { get; set; } = default!;

    /// <summary>
    /// The latest budget month
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("last_month")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset? Last_month { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("date_format")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public DateFormat? Date_format { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("currency_format")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public CurrencyFormat? Currency_format { get; set; } = default!;

    /// <summary>
    /// The budget accounts (only included if `include_accounts=true` specified as query parameter)
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("accounts")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<Account>? Accounts { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }
}