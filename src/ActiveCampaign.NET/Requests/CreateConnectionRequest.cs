using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class CreateConnectionRequest
    {
        public int IsInternal { get; set; } = 0;

        public required string Service { get; set; }

        [JsonPropertyName("externalid")]
        public required string ExternalId { get; set; }

        public required string Name { get; set; }

        public required string LogoUrl { get; set; }

        public required string LinkUrl { get; set; }
    }
}
