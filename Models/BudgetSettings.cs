namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class BudgetSettings
{
    [System.Text.Json.Serialization.JsonPropertyName("date_format")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    public DateFormat? Date_format { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("currency_format")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    public CurrencyFormat? Currency_format { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;
    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }
}