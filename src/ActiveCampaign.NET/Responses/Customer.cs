using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class Customer
    {
        [JsonPropertyName("connectionid")]
        public int ConnectionId { get; set; }

        [JsonPropertyName("externalid")]
        public string? ExternalId { get; set; }

        public string? Email { get; set; }

        public int? TotalRevenue { get; set; }

        public int? TotalOrders { get; set; }

        public int? TotalProducts { get; set; }

        public int? AvgRevenuePerOrder { get; set; }

        public string? AvgProductCategory { get; set; }

        [JsonPropertyName("tstamp")]
        public DateTimeOffset? Timestamp { get; set; }

        public int? AcceptsMarketing { get; set; }

        public IDictionary<string, object?>? Links { get; set; }

        public string? Id { get; set; }

        public int? Connection { get; set; }
    }
}