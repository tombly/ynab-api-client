namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class BudgetDetail : BudgetSummary
{
    [System.Text.Json.Serialization.JsonPropertyName("payees")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<Payee>? Payees { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("payee_locations")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<PayeeLocation>? Payee_locations { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("category_groups")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<CategoryGroup>? Category_groups { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("categories")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<Category>? Categories { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("months")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<MonthDetail>? Months { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("transactions")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<TransactionSummary>? Transactions { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("subtransactions")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<SubTransaction>? Subtransactions { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("scheduled_transactions")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<ScheduledTransactionSummary>? Scheduled_transactions { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("scheduled_subtransactions")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<ScheduledSubTransaction>? Scheduled_subtransactions { get; set; } = default!;
}