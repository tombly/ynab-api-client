namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum TransactionSummaryDebtTransactionType
{
    [System.Runtime.Serialization.EnumMember(Value = @"payment")]
    Payment = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"refund")]
    Refund = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"fee")]
    Fee = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"interest")]
    Interest = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"escrow")]
    Escrow = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"balanceAdjustment")]
    BalanceAdjustment = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"credit")]
    Credit = 6,

    [System.Runtime.Serialization.EnumMember(Value = @"charge")]
    Charge = 7,
}