using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PatchMonthCategoryWrapper
{
    [JsonPropertyName("category")]
    public required SaveMonthCategory Category { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}