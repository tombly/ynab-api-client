using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

    /// <summary>The currency format setting for the plan.  In some cases the format will not be available and will be specified as null.</summary>
public sealed record CurrencyFormat
{
    [JsonPropertyName("iso_code")]
    public required string IsoCode { get; init; }

    [JsonPropertyName("example_format")]
    public required string ExampleFormat { get; init; }

    [JsonPropertyName("decimal_digits")]
    public required int DecimalDigits { get; init; }

    [JsonPropertyName("decimal_separator")]
    public required string DecimalSeparator { get; init; }

    [JsonPropertyName("symbol_first")]
    public required bool SymbolFirst { get; init; }

    [JsonPropertyName("group_separator")]
    public required string GroupSeparator { get; init; }

    [JsonPropertyName("currency_symbol")]
    public required string CurrencySymbol { get; init; }

    [JsonPropertyName("display_symbol")]
    public required bool DisplaySymbol { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}