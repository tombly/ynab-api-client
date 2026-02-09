namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SaveTransactionWithOptionalFields
{

    [System.Text.Json.Serialization.JsonPropertyName("account_id")]
    public System.Guid? Account_id { get; set; } = default!;

    /// <summary>
    /// The transaction date in ISO format (e.g. 2016-12-01).  Future dates (scheduled transactions) are not permitted.  Split transaction dates cannot be changed and if a different date is supplied it will be ignored.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("date")]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset? Date { get; set; } = default!;

    /// <summary>
    /// The transaction amount in milliunits format.  Split transaction amounts cannot be changed and if a different amount is supplied it will be ignored.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("amount")]
    public long? Amount { get; set; } = default!;

    /// <summary>
    /// The payee for the transaction.  To create a transfer between two accounts, use the account transfer payee pointing to the target account.  Account transfer payees are specified as `transfer_payee_id` on the account resource.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("payee_id")]
    public System.Guid? Payee_id { get; set; } = default!;

    /// <summary>
    /// The payee name.  If a `payee_name` value is provided and `payee_id` has a null value, the `payee_name` value will be used to resolve the payee by either (1) a matching payee rename rule (only if `import_id` is also specified) or (2) a payee with the same name or (3) creation of a new payee.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("payee_name")]
    [System.ComponentModel.DataAnnotations.StringLength(200)]
    public string? Payee_name { get; set; } = default!;

    /// <summary>
    /// The category for the transaction.  To configure a split transaction, you can specify null for `category_id` and provide a `subtransactions` array as part of the transaction object.  If an existing transaction is a split, the `category_id` cannot be changed.  Credit Card Payment categories are not permitted and will be ignored if supplied.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("category_id")]
    public System.Guid? Category_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("memo")]
    [System.ComponentModel.DataAnnotations.StringLength(500)]
    public string? Memo { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("cleared")]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter<TransactionClearedStatus>))]
    public TransactionClearedStatus? Cleared { get; set; } = default!;

    /// <summary>
    /// Whether or not the transaction is approved.  If not supplied, transaction will be unapproved by default.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("approved")]
    public bool? Approved { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("flag_color")]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter<TransactionFlagColor>))]
    public TransactionFlagColor? Flag_color { get; set; } = default!;

    /// <summary>
    /// An array of subtransactions to configure a transaction as a split. Updating `subtransactions` on an existing split transaction is not supported.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("subtransactions")]
    public System.Collections.Generic.ICollection<SaveSubTransaction>? Subtransactions { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}