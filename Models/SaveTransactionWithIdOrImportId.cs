namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.6.3.0 (NJsonSchema v11.5.2.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SaveTransactionWithIdOrImportId : SaveTransactionWithOptionalFields
{

    /// <summary>
    /// If specified, this id will be used to lookup a transaction by its `id` for the purpose of updating the transaction itself. If not specified, an `import_id` should be supplied.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public string? Id { get; set; } = default!;

    /// <summary>
    /// If specified, this id will be used to lookup a transaction by its `import_id` for the purpose of updating the transaction itself. If not specified, an `id` should be supplied.  You may not provide both an `id` and an `import_id` and updating an `import_id` on an existing transaction is not allowed.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("import_id")]
    [System.ComponentModel.DataAnnotations.StringLength(36)]
    public string? Import_id { get; set; } = default!;

}