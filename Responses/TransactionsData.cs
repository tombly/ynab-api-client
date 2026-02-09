namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TransactionsData
{

    [System.Text.Json.Serialization.JsonPropertyName("transactions")]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<TransactionDetail> Transactions { get; set; } = new System.Collections.ObjectModel.Collection<TransactionDetail>();

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("server_knowledge")]
    public long Server_knowledge { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}