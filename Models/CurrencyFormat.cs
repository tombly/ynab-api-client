namespace Ynab.Api.Client;

/// <summary>
/// The currency format setting for the budget.  In some cases the format will not be available and will be specified as null.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class CurrencyFormat
{

    [System.Text.Json.Serialization.JsonPropertyName("iso_code")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Iso_code { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("example_format")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Example_format { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("decimal_digits")]
    public int Decimal_digits { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("decimal_separator")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Decimal_separator { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("symbol_first")]
    public bool Symbol_first { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("group_separator")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Group_separator { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("currency_symbol")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Currency_symbol { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("display_symbol")]
    public bool Display_symbol { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}