namespace Ynab.Api.Client;

/// <summary>
/// Partial class implementation to customize JSON serialization settings. This is not a
/// generated file, so it will not be overwritten by code generation tools, so don't
/// remove this when regenerating the client code.
/// </summary>
public partial class YnabApiClient
{
    static partial void UpdateJsonSerializerSettings(System.Text.Json.JsonSerializerOptions settings)
    {
        settings.Converters.Add(new TransactionFlagColorConverter());
        settings.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    }
}
