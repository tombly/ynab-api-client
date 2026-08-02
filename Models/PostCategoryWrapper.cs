using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PostCategoryWrapper
{
    [JsonPropertyName("category")]
    public required SaveCategory Category { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}
