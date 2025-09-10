using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class Connection
    {
        public int Id { get; set; }

        public int? IsInternal { get; set; }

        public string? Service { get; set; }

        [JsonPropertyName("externalid")]
        public string? ExternalId { get; set; }

        public string? Name { get; set; }

        public Uri? LogoUrl { get; set; }

        public Uri? LinkUrl { get; set; }

        [JsonPropertyName("cdate")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("udate")]
        public DateTime? LastUpdatedAt { get; set; }
    }
}
