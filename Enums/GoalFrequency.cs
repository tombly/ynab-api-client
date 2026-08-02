using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

/// <summary>The frequency at which a recurring 'NEED' goal target repeats.</summary>
public enum GoalFrequency
{
    [JsonStringEnumMemberName("monthly")]
    Monthly,

    [JsonStringEnumMemberName("weekly")]
    Weekly,

    [JsonStringEnumMemberName("yearly")]
    Yearly,
}
