using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class ECommerceOrder
    {
        public int Id { get; set; }

        [JsonPropertyName("customerid")]
        public int CustomerId { get; set; }

        [JsonPropertyName("connectionid")]
        public int ConnectionId { get; set; }

        public int? State { get; set; }

        public int? Source { get; set; }

        [JsonPropertyName("externalid")]
        public string? ExternalId { get; set; }

        [JsonPropertyName("externalcheckoutid")]
        public string? ExternalCheckoutId { get; set; }

        public string? OrderNumber { get; set; }

        public string? Email { get; set; }

        public int? TotalPrice { get; set; }

        public int? DiscountAmount { get; set; }

        public int? ShippingAmount { get; set; }
    }
}
