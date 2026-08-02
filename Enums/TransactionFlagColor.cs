using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

/// <summary>The transaction flag</summary>
public enum TransactionFlagColor
{
    [JsonStringEnumMemberName("red")]
    Red,

    [JsonStringEnumMemberName("orange")]
    Orange,

    [JsonStringEnumMemberName("yellow")]
    Yellow,

    [JsonStringEnumMemberName("green")]
    Green,

    [JsonStringEnumMemberName("blue")]
    Blue,

    [JsonStringEnumMemberName("purple")]
    Purple,

    [JsonStringEnumMemberName("")]
    Empty,
}