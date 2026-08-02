using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Responses;

/// <summary>The `{ "data": ... }` envelope wrapping every successful YNAB API response. The client unwraps it, so methods return the payload directly.</summary>
internal sealed record DataEnvelope<TData>
{
    [JsonPropertyName("data")]
    public required TData Data { get; init; }
}
