using ActiveCampaign.Serializers;
using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public record TrackEventResponse
    {
        [JsonConverter(typeof(NumberToBooleanJsonConverter))]
        [JsonInclude]
        public bool Success { get; internal set; }

        [JsonInclude]
        public string? Message { get; internal set; }
    }
}
