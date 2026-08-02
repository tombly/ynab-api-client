using System.Text.Json.Serialization;

namespace Ynab.Api.Client.Models;

public sealed record SaveTransactionWithIdOrImportId : SaveTransactionWithOptionalFields
{
    /// <summary>If specified, this id will be used to lookup a transaction by its `id` for the purpose of updating the transaction itself. If not specified, an `import_id` should be supplied.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>If specified, this id will be used to lookup a transaction by its `import_id` for the purpose of updating the transaction itself. If not specified, an `id` should be supplied.  You may not provide both an `id` and an `import_id` and updating an `import_id` on an existing transaction is not allowed.</summary>
    [JsonPropertyName("import_id")]
    public string? ImportId { get; init; }
}