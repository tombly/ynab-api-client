namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public enum TransactionSummaryDebtTransactionType
{

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"payment")]
    Payment = 0,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"refund")]
    Refund = 1,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"fee")]
    Fee = 2,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"interest")]
    Interest = 3,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"escrow")]
    Escrow = 4,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"balanceAdjustment")]
    BalanceAdjustment = 5,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"credit")]
    Credit = 6,

    [System.Text.Json.Serialization.JsonStringEnumMemberName(@"charge")]
    Charge = 7,

}