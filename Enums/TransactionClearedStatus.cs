using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

/// <summary>The cleared status of the transaction</summary>
public enum TransactionClearedStatus
{
    [JsonStringEnumMemberName("cleared")]
    Cleared,

    [JsonStringEnumMemberName("uncleared")]
    Uncleared,

    [JsonStringEnumMemberName("reconciled")]
    Reconciled,
}