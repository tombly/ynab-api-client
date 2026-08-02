using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PostAccountWrapper
{
    [JsonPropertyName("account")]
    public required SaveAccount Account { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}