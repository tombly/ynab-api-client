namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SubTransaction
{
    [System.Text.Json.Serialization.JsonPropertyName("id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("transaction_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Transaction_id { get; set; } = default!;

    /// <summary>
    /// The subtransaction amount in milliunits format
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("amount")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    public long Amount { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("memo")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Memo { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("payee_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public System.Guid? Payee_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("payee_name")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Payee_name { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("category_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public System.Guid? Category_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("category_name")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Category_name { get; set; } = default!;

    /// <summary>
    /// If a transfer, the account_id which the subtransaction transfers to
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("transfer_account_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public System.Guid? Transfer_account_id { get; set; } = default!;

    /// <summary>
    /// If a transfer, the id of transaction on the other side of the transfer
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("transfer_transaction_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Transfer_transaction_id { get; set; } = default!;

    /// <summary>
    /// Whether or not the subtransaction has been deleted.  Deleted subtransactions will only be included in delta requests.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("deleted")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    public bool Deleted { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }
}