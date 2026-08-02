using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;

namespace Ynab.Api.Client.Models;

public sealed record SaveAccount
{
    /// <summary>The name of the account</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    public required SaveAccountType Type { get; init; }

    /// <summary>The current balance of the account in milliunits format</summary>
    [JsonPropertyName("balance")]
    public required long Balance { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}