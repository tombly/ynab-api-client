namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class MonthDetail : MonthSummary
{
    /// <summary>
    /// The budget month categories.  Amounts (budgeted, activity, balance, etc.) are specific to the {month} parameter specified.
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("categories")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<Category> Categories { get; set; } = new System.Collections.ObjectModel.Collection<Category>();
}