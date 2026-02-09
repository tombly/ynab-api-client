namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SaveSubTransaction
{

    /// <summary>
    /// The subtransaction amount in milliunits format.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("amount")]
    public long Amount { get; set; } = default!;

    /// <summary>
    /// The payee for the subtransaction.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("payee_id")]
    public System.Guid? Payee_id { get; set; } = default!;

    /// <summary>
    /// The payee name.  If a `payee_name` value is provided and `payee_id` has a null value, the `payee_name` value will be used to resolve the payee by either (1) a matching payee rename rule (only if import_id is also specified on parent transaction) or (2) a payee with the same name or (3) creation of a new payee.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("payee_name")]
    [System.ComponentModel.DataAnnotations.StringLength(200)]
    public string? Payee_name { get; set; } = default!;

    /// <summary>
    /// The category for the subtransaction.  Credit Card Payment categories are not permitted and will be ignored if supplied.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("category_id")]
    public System.Guid? Category_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("memo")]
    [System.ComponentModel.DataAnnotations.StringLength(500)]
    public string? Memo { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}