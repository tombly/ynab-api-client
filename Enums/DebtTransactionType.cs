using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

public enum DebtTransactionType
{
    [JsonStringEnumMemberName("payment")]
    Payment,

    [JsonStringEnumMemberName("refund")]
    Refund,

    [JsonStringEnumMemberName("fee")]
    Fee,

    [JsonStringEnumMemberName("interest")]
    Interest,

    [JsonStringEnumMemberName("escrow")]
    Escrow,

    [JsonStringEnumMemberName("balanceAdjustment")]
    BalanceAdjustment,

    [JsonStringEnumMemberName("credit")]
    Credit,

    [JsonStringEnumMemberName("charge")]
    Charge,
}