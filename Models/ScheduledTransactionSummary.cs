namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class ScheduledTransactionSummary
{
    [System.Text.Json.Serialization.JsonPropertyName("id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// The first date for which the Scheduled Transaction was scheduled.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("date_first")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset Date_first { get; set; } = default!;

    /// <summary>
    /// The next date for which the Scheduled Transaction is scheduled.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("date_next")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateFormatConverter))]
    public System.DateTimeOffset Date_next { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("frequency")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public ScheduledTransactionSummaryFrequency Frequency { get; set; } = default!;

    /// <summary>
    /// The scheduled transaction amount in milliunits format
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("amount")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    public long Amount { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("memo")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public string? Memo { get; set; } = default!;

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
    /// If a transfer, the account_id which the scheduled transaction transfers to
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("transfer_account_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.Guid? Transfer_account_id { get; set; } = default!;

    /// <summary>
    /// Whether or not the scheduled transaction has been deleted.  Deleted scheduled transactions will only be included in delta requests.
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