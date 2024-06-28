namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SaveTransactionWithOptionalFields
{
    [System.Text.Json.Serialization.JsonPropertyName("account_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Guid? Account_id { get; set; } = default!;

    /// <summary>
    /// The transaction date in ISO format (e.g. 2016-12-01).  Future dates (scheduled transactions) are not permitted.  Split transaction dates cannot be changed and if a different date is supplied it will be ignored.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("date")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset? Date { get; set; } = default!;

    /// <summary>
    /// The transaction amount in milliunits format.  Split transaction amounts cannot be changed and if a different amount is supplied it will be ignored.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("amount")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public long? Amount { get; set; } = default!;

    /// <summary>
    /// The payee for the transaction.  To create a transfer between two accounts, use the account transfer payee pointing to the target account.  Account transfer payees are specified as `tranfer_payee_id` on the account resource.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("payee_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Guid? Payee_id { get; set; } = default!;

    /// <summary>
    /// The payee name.  If a `payee_name` value is provided and `payee_id` has a null value, the `payee_name` value will be used to resolve the payee by either (1) a matching payee rename rule (only if `import_id` is also specified) or (2) a payee with the same name or (3) creation of a new payee.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("payee_name")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    [System.ComponentModel.DataAnnotations.StringLength(50)]
    public string? Payee_name { get; set; } = default!;

    /// <summary>
    /// The category for the transaction.  To configure a split transaction, you can specify null for `category_id` and provide a `subtransactions` array as part of the transaction object.  If an existing transaction is a split, the `category_id` cannot be changed.  Credit Card Payment categories are not permitted and will be ignored if supplied.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("category_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Guid? Category_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("memo")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    [System.ComponentModel.DataAnnotations.StringLength(200)]
    public string? Memo { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("cleared")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public TransactionClearedStatus? Cleared { get; set; } = default!;

    /// <summary>
    /// Whether or not the transaction is approved.  If not supplied, transaction will be unapproved by default.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("approved")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Approved { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("flag_color")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public TransactionFlagColor? Flag_color { get; set; } = default!;

    /// <summary>
    /// If specified, the new transaction will be assigned this `import_id` and considered "imported".  We will also attempt to match this imported transaction to an existing "user-entered" transation on the same account, with the same amount, and with a date +/-10 days from the imported transaction date.&lt;br&gt;&lt;br&gt;Transactions imported through File Based Import or Direct Import (not through the API) are assigned an import_id in the format: 'YNAB:[milliunit_amount]:[iso_date]:[occurrence]'. For example, a transaction dated 2015-12-30 in the amount of -$294.23 USD would have an import_id of 'YNAB:-294230:2015-12-30:1'.  If a second transaction on the same account was imported and had the same date and same amount, its import_id would be 'YNAB:-294230:2015-12-30:2'.  Using a consistent format will prevent duplicates through Direct Import and File Based Import.&lt;br&gt;&lt;br&gt;If import_id is omitted or specified as null, the transaction will be treated as a "user-entered" transaction. As such, it will be eligible to be matched against transactions later being imported (via DI, FBI, or API).
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("import_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    [System.ComponentModel.DataAnnotations.StringLength(36)]
    public string? Import_id { get; set; } = default!;

    /// <summary>
    /// An array of subtransactions to configure a transaction as a split. Updating `subtransactions` on an existing split transaction is not supported.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("subtransactions")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Collections.Generic.ICollection<SaveSubTransaction>? Subtransactions { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }
}