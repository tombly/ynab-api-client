namespace Ynab.Api.Client;

/// <summary>
/// The cleared status of the transaction
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public enum TransactionClearedStatus
{

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"cleared")]
    Cleared = 0,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"uncleared")]
    Uncleared = 1,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"reconciled")]
    Reconciled = 2,

}