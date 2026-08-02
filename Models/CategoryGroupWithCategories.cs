using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record CategoryGroupWithCategories : CategoryGroup
{
    /// <summary>Category group categories.  Amounts (budgeted, activity, balance, etc.) are specific to the current plan month (UTC).</summary>
    [JsonPropertyName("categories")]
    public required IReadOnlyList<Category> Categories { get; init; }
}