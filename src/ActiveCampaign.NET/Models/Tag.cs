using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class Tag
    {
        public int Id { get; set; }

        public TagType? TagType { get; set; }

        [JsonPropertyName("tag")]
        public string? Value { get; set; }

        public string? Description { get; set; }

        [JsonPropertyName("cdate")]
        public DateTimeOffset? CreatedAt { get; set; }

        public int? SubscriberCount { get; set; }

        public IDictionary<string, string>? Links { get; set; }
    }
}
