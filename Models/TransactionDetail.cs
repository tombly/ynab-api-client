namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TransactionDetail : TransactionSummary
{
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

    /// <summary>
    /// If a split transaction, the subtransactions.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("subtransactions")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<SubTransaction> Subtransactions { get; set; } = new System.Collections.ObjectModel.Collection<SubTransaction>();
}