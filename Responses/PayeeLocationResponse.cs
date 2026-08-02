using System.Text.Json.Serialization;
using Ynab.Api.Client.Models;

namespace Ynab.Api.Client.Responses;

public sealed record PayeeLocationResponse
{
    [JsonPropertyName("payee_location")]
    public required PayeeLocation PayeeLocation { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}