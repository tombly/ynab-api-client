using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Enums;

/// <summary>The transaction type filter for transaction listings.</summary>
public enum TransactionFilterType
{
    [JsonStringEnumMemberName("uncategorized")]
    Uncategorized,

    [JsonStringEnumMemberName("unapproved")]
    Unapproved,
}
