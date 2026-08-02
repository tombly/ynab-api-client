using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PlanSettings
{
    [JsonPropertyName("date_format")]
    public DateFormat? DateFormat { get; init; }

    [JsonPropertyName("currency_format")]
    public CurrencyFormat? CurrencyFormat { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}