using System.Text.Json.Serialization;
using Ynab.Api.Client.Models;

namespace Ynab.Api.Client.Responses;

public sealed record PlanSummaryResponse
{
    [JsonPropertyName("plans")]
    public required IReadOnlyList<PlanSummary> Plans { get; init; }

    [JsonPropertyName("default_plan")]
    public PlanSummary? DefaultPlan { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}