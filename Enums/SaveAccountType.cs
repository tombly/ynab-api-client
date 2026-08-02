using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

/// <summary>The type of account</summary>
public enum SaveAccountType
{
    [JsonStringEnumMemberName("checking")]
    Checking,

    [JsonStringEnumMemberName("savings")]
    Savings,

    [JsonStringEnumMemberName("cash")]
    Cash,

    [JsonStringEnumMemberName("creditCard")]
    CreditCard,

    [JsonStringEnumMemberName("otherAsset")]
    OtherAsset,

    [JsonStringEnumMemberName("otherLiability")]
    OtherLiability,
}
