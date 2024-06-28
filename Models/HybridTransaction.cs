namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class HybridTransaction : TransactionSummary
{
    /// <summary>
    /// Whether the hybrid transaction represents a regular transaction or a subtransaction
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("type")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public HybridTransactionType Type { get; set; } = default!;

    /// <summary>
    /// For subtransaction types, this is the id of the parent transaction.  For transaction types, this id will be always be null.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("parent_transaction_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public string? Parent_transaction_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("account_name")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Account_name { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("payee_name")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public string? Payee_name { get; set; } = default!;

    /// <summary>
    /// The name of the category.  If a split transaction, this will be 'Split'.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("category_name")]

    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public string? Category_name { get; set; } = default!;
}