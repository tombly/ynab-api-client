namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Bulk
{
    /// <summary>
    /// The list of Transaction ids that were created.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("transaction_ids")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<string> Transaction_ids { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    /// <summary>
    /// If any Transactions were not created because they had an `import_id` matching a transaction already on the same account, the specified import_id(s) will be included in this list.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("duplicate_import_ids")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<string> Duplicate_import_ids { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }
}