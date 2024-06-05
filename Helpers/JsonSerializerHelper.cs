namespace DGII_Connect;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class NullToEmptyObjectListConverter<T> : JsonConverter<List<T>> where T : class, new()
{
    public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // This part is not relevant for your scenario since we are only concerned with writing JSON
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        if (value != null)
        {
            foreach (var item in value)
            {
                if (item == null)
                {
                    writer.WriteStartObject();
                    writer.WriteEndObject();
                }
                else
                {
                    JsonSerializer.Serialize(writer, item, options);
                }
            }
        }

        writer.WriteEndArray();
    }
}

public class NullToEmptyObjectConverter<T> : JsonConverter<T> where T : class, new()
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // This part is not relevant for your scenario since we are only concerned with writing JSON
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        else
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}