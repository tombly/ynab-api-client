namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TransactionSummary
{
    [System.Text.Json.Serialization.JsonPropertyName("id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Id { get; set; } = default!;

    /// <summary>
    /// The transaction date in ISO format (e.g. 2016-12-01)
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("date")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset Date { get; set; } = default!;

    /// <summary>
    /// The transaction amount in milliunits format
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("amount")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    public long Amount { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("memo")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Memo { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("cleared")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public TransactionClearedStatus Cleared { get; set; } = default!;

    /// <summary>
    /// Whether or not the transaction is approved
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("approved")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    public bool Approved { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("flag_color")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public TransactionFlagColor? Flag_color { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("account_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid Account_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("payee_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public System.Guid? Payee_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("category_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public System.Guid? Category_id { get; set; } = default!;

    /// <summary>
    /// If a transfer transaction, the account to which it transfers
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("transfer_account_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public System.Guid? Transfer_account_id { get; set; } = default!;

    /// <summary>
    /// If a transfer transaction, the id of transaction on the other side of the transfer
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("transfer_transaction_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Transfer_transaction_id { get; set; } = default!;

    /// <summary>
    /// If transaction is matched, the id of the matched transaction
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("matched_transaction_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Matched_transaction_id { get; set; } = default!;

    /// <summary>
    /// If the transaction was imported, this field is a unique (by account) import identifier.  If this transaction was imported through File Based Import or Direct Import and not through the API, the import_id will have the format: 'YNAB:[milliunit_amount]:[iso_date]:[occurrence]'.  For example, a transaction dated 2015-12-30 in the amount of -$294.23 USD would have an import_id of 'YNAB:-294230:2015-12-30:1'.  If a second transaction on the same account was imported and had the same date and same amount, its import_id would be 'YNAB:-294230:2015-12-30:2'.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("import_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Import_id { get; set; } = default!;

    /// <summary>
    /// If the transaction was imported, the payee name that was used when importing and before applying any payee rename rules
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("import_payee_name")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Import_payee_name { get; set; } = default!;

    /// <summary>
    /// If the transaction was imported, the original payee name as it appeared on the statement
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("import_payee_name_original")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    public string? Import_payee_name_original { get; set; } = default!;

    /// <summary>
    /// If the transaction is a debt/loan account transaction, the type of transaction
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("debt_transaction_type")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public TransactionSummaryDebtTransactionType? Debt_transaction_type { get; set; } = default!;

    /// <summary>
    /// Whether or not the transaction has been deleted.  Deleted transactions will only be included in delta requests.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("deleted")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
    public bool Deleted { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }
}