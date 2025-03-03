namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SaveCategoryData
{

    [System.Text.Json.Serialization.JsonPropertyName("category")]
    [System.ComponentModel.DataAnnotations.Required]
    public Category Category { get; set; } = new Category();

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