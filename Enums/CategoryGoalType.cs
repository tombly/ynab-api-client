using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

public enum CategoryGoalType
{
    [JsonStringEnumMemberName("TB")]
    TB,

    [JsonStringEnumMemberName("TBD")]
    TBD,

    [JsonStringEnumMemberName("MF")]
    MF,

    [JsonStringEnumMemberName("NEED")]
    NEED,

    [JsonStringEnumMemberName("DEBT")]
    DEBT,
}