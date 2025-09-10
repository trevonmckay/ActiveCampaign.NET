using System.Text.Json;
using System.Text.Json.Serialization;

namespace ActiveCampaign.Serializers
{
    public class NumberToBooleanJsonConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int? numericValue = null;
            if (reader.TokenType == JsonTokenType.Number)
            {
                numericValue = reader.GetInt32();
            }
            else if (reader.TokenType == JsonTokenType.String && options.NumberHandling == JsonNumberHandling.AllowReadingFromString && int.TryParse(reader.GetString(), out int result))
            {
                numericValue = result;
            }

            switch (numericValue)
            {
                case 1:
                    return true;
                case 0:
                    return false;
                default:
                    throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            if (value)
            {
                writer.WriteNumberValue(1);
            }
            else
            {
                writer.WriteNumberValue(0);
            }
        }
    }
}
