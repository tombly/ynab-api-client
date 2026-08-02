using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record MonthDetail : MonthSummary
{
    /// <summary>The plan month categories.  Amounts (budgeted, activity, balance, etc.) are specific to the {month} parameter specified.</summary>
    [JsonPropertyName("categories")]
    public required IReadOnlyList<Category> Categories { get; init; }
}