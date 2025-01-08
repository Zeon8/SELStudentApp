using System.Text.Json;
using System.Text.Json.Serialization;
using SELStudentApp.Core.Models.Curriculum;

namespace SELStudentApp.Core.JsonConverters;

internal class PerformanceConverter : JsonConverter<Performance?>
{
    public override Performance? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return null;
            }
            throw new JsonException("Unexpected token inside the array.");
        }

        if (reader.TokenType == JsonTokenType.StartObject)
        {
            return JsonSerializer.Deserialize<Performance>(ref reader, options);
        }
        throw new JsonException($"Unexpected token type: {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, Performance? value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value, options));
    }
}
