using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

public enum HybridTransactionType
{
    [JsonStringEnumMemberName("transaction")]
    Transaction,

    [JsonStringEnumMemberName("subtransaction")]
    Subtransaction,
}