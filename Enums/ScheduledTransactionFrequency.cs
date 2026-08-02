using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

/// <summary>The scheduled transaction frequency</summary>
public enum ScheduledTransactionFrequency
{
    [JsonStringEnumMemberName("never")]
    Never,

    [JsonStringEnumMemberName("daily")]
    Daily,

    [JsonStringEnumMemberName("weekly")]
    Weekly,

    [JsonStringEnumMemberName("everyOtherWeek")]
    EveryOtherWeek,

    [JsonStringEnumMemberName("twiceAMonth")]
    TwiceAMonth,

    [JsonStringEnumMemberName("every4Weeks")]
    Every4Weeks,

    [JsonStringEnumMemberName("monthly")]
    Monthly,

    [JsonStringEnumMemberName("everyOtherMonth")]
    EveryOtherMonth,

    [JsonStringEnumMemberName("every3Months")]
    Every3Months,

    [JsonStringEnumMemberName("every4Months")]
    Every4Months,

    [JsonStringEnumMemberName("twiceAYear")]
    TwiceAYear,

    [JsonStringEnumMemberName("yearly")]
    Yearly,

    [JsonStringEnumMemberName("everyOtherYear")]
    EveryOtherYear,
}