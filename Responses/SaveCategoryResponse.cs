using System.Text.Json.Serialization;
using Ynab.Api.Client.Models;

namespace Ynab.Api.Client.Responses;

public sealed record SaveCategoryResponse
{
    [JsonPropertyName("category")]
    public required Category Category { get; init; }

    /// <summary>The knowledge of the server</summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}