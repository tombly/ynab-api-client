namespace Ynab.Api.Client;

/// <summary>
/// Custom JSON converter for TransactionFlagColor that properly handles empty
/// string values. This is not generated code, so it will not be overwritten
/// by code generation tools, so don't remove this when regenerating the client
/// code.
/// 
/// After regeneration, remove any [JsonConverter] attributes referencing the
/// TransactionFlagColor enum (since the converter is now registered globally).
/// </summary>
internal class TransactionFlagColorConverter : System.Text.Json.Serialization.JsonConverter<TransactionFlagColor>
{
    public override TransactionFlagColor Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
    {
        var value = reader.GetString();
        
        return value switch
        {
            "" or null => TransactionFlagColor.Empty,
            "red" => TransactionFlagColor.Red,
            "orange" => TransactionFlagColor.Orange,
            "yellow" => TransactionFlagColor.Yellow,
            "green" => TransactionFlagColor.Green,
            "blue" => TransactionFlagColor.Blue,
            "purple" => TransactionFlagColor.Purple,
            _ => throw new System.Text.Json.JsonException($"Unknown TransactionFlagColor value: '{value}'")
        };
    }

    public override void Write(System.Text.Json.Utf8JsonWriter writer, TransactionFlagColor value, System.Text.Json.JsonSerializerOptions options)
    {
        var stringValue = value switch
        {
            TransactionFlagColor.Empty => "",
            TransactionFlagColor.Red => "red",
            TransactionFlagColor.Orange => "orange",
            TransactionFlagColor.Yellow => "yellow",
            TransactionFlagColor.Green => "green",
            TransactionFlagColor.Blue => "blue",
            TransactionFlagColor.Purple => "purple",
            _ => throw new System.ArgumentException($"Unknown TransactionFlagColor value: {value}")
        };
        
        writer.WriteStringValue(stringValue);
    }
}
