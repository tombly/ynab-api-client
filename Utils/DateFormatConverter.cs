namespace Ynab.Api.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
internal class DateFormatConverter : System.Text.Json.Serialization.JsonConverter<System.DateTimeOffset>
{
    public override System.DateTimeOffset Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
    {
        var dateTime = reader.GetString();
        if (dateTime == null)
        {
            throw new System.Text.Json.JsonException("Unexpected JsonTokenType.Null");
        }

        return System.DateTimeOffset.Parse(dateTime);
    }

    public override void Write(System.Text.Json.Utf8JsonWriter writer, System.DateTimeOffset value, System.Text.Json.JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}