using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class ContactTag
    {
        public int Id { get; set; }

        public int Contact { get; set; }

        public int Tag { get; set; }

        public IDictionary<string, string>? Links { get; set; }

        [JsonPropertyName("cdate")]
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
