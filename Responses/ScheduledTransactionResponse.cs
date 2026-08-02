using System.Text.Json.Serialization;
using Ynab.Api.Client.Models;

namespace Ynab.Api.Client.Responses;

public sealed record ScheduledTransactionResponse
{
    [JsonPropertyName("scheduled_transaction")]
    public required ScheduledTransactionDetail ScheduledTransaction { get; init; }

    [JsonExtensionData]
    public IDictionary<string, object?>? AdditionalProperties { get; init; }
}