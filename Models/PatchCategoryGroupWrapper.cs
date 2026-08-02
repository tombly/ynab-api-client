using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PatchCategoryGroupWrapper
{
    [JsonPropertyName("category_group")]
    public required SaveCategoryGroup CategoryGroup { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}
