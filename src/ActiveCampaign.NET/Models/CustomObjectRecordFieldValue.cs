using System.Text.Json;

namespace ActiveCampaign
{
    public class CustomObjectRecordFieldValue
    {
        public string? Id { get; set; }

        public object? Value { get; set; }

        public string? Currency { get; set; }

        public object? GetValue()
        {
            if (Value is JsonElement jsonElement)
            {
                switch (jsonElement.ValueKind)
                {
                    case JsonValueKind.String:
                        return jsonElement.GetString();
                    case JsonValueKind.Number:
                        return jsonElement.GetInt32();
                    case JsonValueKind.True:
                        return true;
                    case JsonValueKind.False:
                        return false;
                    case JsonValueKind.Null:
                        return null;
                    default:
                        return Value;
                }
            }
            else
            {
                return Value;
            }
        }
    }
}
