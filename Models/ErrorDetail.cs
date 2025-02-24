namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ErrorDetail
{

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Name { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("detail")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Detail { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}