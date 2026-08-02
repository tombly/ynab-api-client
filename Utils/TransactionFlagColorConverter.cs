using System.Text.Json;
using System.Text.Json.Serialization;
using Ynab.Api.Client.Enums;

namespace Ynab.Api.Client.Utils;

/// <summary>
/// Handles <see cref="TransactionFlagColor"/> values, which the YNAB API sends as
/// color names or an empty string (mapped to <see cref="TransactionFlagColor.Empty"/>).
/// </summary>
internal sealed class TransactionFlagColorConverter : JsonConverter<TransactionFlagColor>
{
    public override TransactionFlagColor Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
        => reader.GetString() switch
        {
            "" or null => TransactionFlagColor.Empty,
            "red" => TransactionFlagColor.Red,
            "orange" => TransactionFlagColor.Orange,
            "yellow" => TransactionFlagColor.Yellow,
            "green" => TransactionFlagColor.Green,
            "blue" => TransactionFlagColor.Blue,
            "purple" => TransactionFlagColor.Purple,
            var value => throw new JsonException($"Unknown TransactionFlagColor value: '{value}'")
        };

    public override void Write(Utf8JsonWriter writer, TransactionFlagColor value, JsonSerializerOptions options)
        => writer.WriteStringValue(value switch
        {
            TransactionFlagColor.Empty => "",
            TransactionFlagColor.Red => "red",
            TransactionFlagColor.Orange => "orange",
            TransactionFlagColor.Yellow => "yellow",
            TransactionFlagColor.Green => "green",
            TransactionFlagColor.Blue => "blue",
            TransactionFlagColor.Purple => "purple",
            _ => throw new ArgumentException($"Unknown TransactionFlagColor value: {value}")
        });
}
