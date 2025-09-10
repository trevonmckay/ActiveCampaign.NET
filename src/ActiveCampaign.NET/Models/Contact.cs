using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class Contact
    {
        public int Id { get; set; }

        [JsonPropertyName("cdate")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonPropertyName("udate")]
        public DateTimeOffset? LastUpdatedAt { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? OrgId { get; set; }

        public string? EmailLocal { get; set; }

        public string? EmailDomain { get; set; }

        public IDictionary<string, string>? Links { get; set; }
    }
}
