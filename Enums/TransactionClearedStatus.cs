namespace Ynab.Api.Client;

/// <summary>
/// The cleared status of the transaction
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum TransactionClearedStatus
{

    [System.Runtime.Serialization.EnumMember(Value = @"cleared")]
    Cleared = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"uncleared")]
    Uncleared = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"reconciled")]
    Reconciled = 2,

}