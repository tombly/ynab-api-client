namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SaveTransactionsData
{
    /// <summary>
    /// The transaction ids that were saved
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("transaction_ids")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<string> Transaction_ids { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    [System.Text.Json.Serialization.JsonPropertyName("transaction")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public TransactionDetail? Transaction { get; set; } = default!;

    /// <summary>
    /// If multiple transactions were specified, the transactions that were saved
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("transactions")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public System.Collections.Generic.ICollection<TransactionDetail>? Transactions { get; set; } = default!;

    /// <summary>
    /// If multiple transactions were specified, a list of import_ids that were not created because of an existing `import_id` found on the same account
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("duplicate_import_ids")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public System.Collections.Generic.ICollection<string>? Duplicate_import_ids { get; set; } = default!;

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("server_knowledge")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    public long Server_knowledge { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }
}