using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class TagTypeJsonConverter : JsonConverter<TagType>
    {
        public override TagType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(TagType));
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            string? value = reader.GetString();
            return TagType.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, TagType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
