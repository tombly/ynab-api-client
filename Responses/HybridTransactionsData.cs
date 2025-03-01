namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class HybridTransactionsData
{

    [System.Text.Json.Serialization.JsonPropertyName("transactions")]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<HybridTransaction> Transactions { get; set; } = new System.Collections.ObjectModel.Collection<HybridTransaction>();

    /// <summary>
    /// The knowledge of the server
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("server_knowledge")]
    public long? Server_knowledge { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}