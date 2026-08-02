using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PostScheduledTransactionWrapper
{
    [JsonPropertyName("scheduled_transaction")]
    public required SaveScheduledTransaction ScheduledTransaction { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}