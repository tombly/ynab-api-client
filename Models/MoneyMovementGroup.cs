using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record MoneyMovementGroup
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>When the money movement group was created</summary>
    [JsonPropertyName("group_created_at")]
    public required DateTimeOffset GroupCreatedAt { get; init; }

    /// <summary>The month of the money movement group in ISO format (e.g. 2024-01-01)</summary>
    [JsonPropertyName("month")]
    public required DateOnly Month { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    /// <summary>The id of the user who performed the money movement group</summary>
    [JsonPropertyName("performed_by_user_id")]
    public Guid? PerformedByUserId { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}
