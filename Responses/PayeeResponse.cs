using System.Text.Json.Serialization;
using Ynab.Api.Client.Models;

namespace Ynab.Api.Client.Responses;

public sealed record PayeeResponse
{
    [JsonPropertyName("payee")]
    public required Payee Payee { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}