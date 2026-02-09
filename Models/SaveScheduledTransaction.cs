namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SaveScheduledTransaction
{

    [System.Text.Json.Serialization.JsonPropertyName("account_id")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid Account_id { get; set; } = default!;

    /// <summary>
    /// The scheduled transaction date in ISO format (e.g. 2016-12-01).  This should be a future date no more than 5 years into the future.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("date")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset Date { get; set; } = default!;

    /// <summary>
    /// The scheduled transaction amount in milliunits format.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("amount")]
    public long? Amount { get; set; } = default!;

    /// <summary>
    /// The payee for the scheduled transaction.  To create a transfer between two accounts, use the account transfer payee pointing to the target account.  Account transfer payees are specified as `transfer_payee_id` on the account resource.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("payee_id")]
    public System.Guid? Payee_id { get; set; } = default!;

    /// <summary>
    /// The payee name for the the scheduled transaction.  If a `payee_name` value is provided and `payee_id` has a null value, the `payee_name` value will be used to resolve the payee by either (1) a payee with the same name or (2) creation of a new payee.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("payee_name")]
    [System.ComponentModel.DataAnnotations.StringLength(200)]
    public string? Payee_name { get; set; } = default!;

    /// <summary>
    /// The category for the scheduled transaction. Credit Card Payment categories are not permitted. Creating a split scheduled transaction is not currently supported.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("category_id")]
    public System.Guid? Category_id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("memo")]
    [System.ComponentModel.DataAnnotations.StringLength(500)]
    public string? Memo { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("flag_color")]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter<TransactionFlagColor>))]
    public TransactionFlagColor? Flag_color { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("frequency")]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter<ScheduledTransactionFrequency>))]
    public ScheduledTransactionFrequency? Frequency { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}