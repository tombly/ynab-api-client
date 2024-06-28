namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class Account
{
    [System.Text.Json.Serialization.JsonPropertyName("id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.Guid Id { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Name { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public AccountType Type { get; set; } = default!;

    /// <summary>
    /// Whether this account is on budget or not
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("on_budget")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    public bool On_budget { get; set; } = default!;

    /// <summary>
    /// Whether this account is closed or not
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("closed")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    public bool Closed { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("note")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public string? Note { get; set; } = default!;

    /// <summary>
    /// The current balance of the account in milliunits format
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("balance")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    public long Balance { get; set; } = default!;

    /// <summary>
    /// The current cleared balance of the account in milliunits format
    /// </summary>

    [System.Text.Json.Serialization.JsonPropertyName("cleared_balance")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    public long Cleared_balance { get; set; } = default!;

    /// <summary>
    /// The current uncleared balance of the account in milliunits format
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("uncleared_balance")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    public long Uncleared_balance { get; set; } = default!;

    /// <summary>
    /// The payee id which should be used when transferring to this account
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("transfer_payee_id")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]
    public System.Guid? Transfer_payee_id { get; set; } = default!;

    /// <summary>
    /// Whether or not the account is linked to a financial institution for automatic transaction import.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("direct_import_linked")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Direct_import_linked { get; set; } = default!;

    /// <summary>
    /// If an account linked to a financial institution (direct_import_linked=true) and the linked connection is not in a healthy state, this will be true.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("direct_import_in_error")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Direct_import_in_error { get; set; } = default!;

    /// <summary>
    /// A date/time specifying when the account was last reconciled.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("last_reconciled_at")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public System.DateTimeOffset? Last_reconciled_at { get; set; } = default!;

    /// <summary>
    /// The original debt/loan account balance, specified in milliunits format.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("debt_original_balance")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public long? Debt_original_balance { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("debt_interest_rates")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public LoanAccountPeriodicValue? Debt_interest_rates { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("debt_minimum_payments")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public LoanAccountPeriodicValue? Debt_minimum_payments { get; set; } = default!;

    [System.Text.Json.Serialization.JsonPropertyName("debt_escrow_amounts")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public LoanAccountPeriodicValue? Debt_escrow_amounts { get; set; } = default!;

    /// <summary>
    /// Whether or not the account has been deleted.  Deleted accounts will only be included in delta requests.
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