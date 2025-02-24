namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SaveCategory
{

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string? Name { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("note")]
    public string? Note { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("category_group_id")]
    public System.Guid? Category_group_id { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}