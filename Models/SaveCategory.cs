namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SaveCategory
{

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string? Name { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("note")]
    public string? Note { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("category_group_id")]
    public System.Guid? Category_group_id { get; set; } = default!;

    /// <summary>
    /// The goal target amount in milliunits format.  This amount can only be changed if the category already has a configured goal (goal_type != null).
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("goal_target")]
    public long? Goal_target { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}