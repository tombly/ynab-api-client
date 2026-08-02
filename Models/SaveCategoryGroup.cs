using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record SaveCategoryGroup
{
    /// <summary>The name of the category group. The name must be a maximum of 50 characters.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}
