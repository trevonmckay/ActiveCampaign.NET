using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public record TrackEventRequest
    {
        public required string Key { get; set; }

        public required string Event { get; set; }

        [JsonPropertyName("eventdata")]
        public string? EventData { get; set; }

        [JsonPropertyName("actid")]
        public required string AccountId { get; set; }

        public required string Visit { get; set; }
    }
}
