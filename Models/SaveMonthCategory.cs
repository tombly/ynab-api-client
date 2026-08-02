using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record SaveMonthCategory
{
    /// <summary>Budgeted amount in milliunits format</summary>
    [JsonPropertyName("budgeted")]
    public required long Budgeted { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}