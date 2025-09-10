using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class CreateCustomerRequest
    {
        [JsonPropertyName("connectionid")]
        public required int ConnectionId { get; set; }

        [JsonPropertyName("externalid")]
        public required string ExternalId { get; set; }

        public required string Email { get; set; }

        public int? AcceptsMarketing { get; set; }
    }
}
