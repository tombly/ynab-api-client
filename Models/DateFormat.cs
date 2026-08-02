using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

    /// <summary>The date format setting for the plan.  In some cases the format will not be available and will be specified as null.</summary>
public sealed record DateFormat
{
    [JsonPropertyName("format")]
    public required string Format { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}