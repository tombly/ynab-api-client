using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record ExistingTransaction : SaveTransactionWithOptionalFields
{
}