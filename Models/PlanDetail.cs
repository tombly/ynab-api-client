using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record PlanDetail : PlanSummary
{
    [JsonPropertyName("payees")]
    public IReadOnlyList<Payee>? Payees { get; init; }

    [JsonPropertyName("payee_locations")]
    public IReadOnlyList<PayeeLocation>? PayeeLocations { get; init; }

    [JsonPropertyName("category_groups")]
    public IReadOnlyList<CategoryGroup>? CategoryGroups { get; init; }

    [JsonPropertyName("categories")]
    public IReadOnlyList<Category>? Categories { get; init; }

    [JsonPropertyName("months")]
    public IReadOnlyList<MonthDetail>? Months { get; init; }

    [JsonPropertyName("transactions")]
    public IReadOnlyList<TransactionSummary>? Transactions { get; init; }

    [JsonPropertyName("subtransactions")]
    public IReadOnlyList<SubTransaction>? Subtransactions { get; init; }

    [JsonPropertyName("scheduled_transactions")]
    public IReadOnlyList<ScheduledTransactionSummary>? ScheduledTransactions { get; init; }

    [JsonPropertyName("scheduled_subtransactions")]
    public IReadOnlyList<ScheduledSubTransaction>? ScheduledSubtransactions { get; init; }
}