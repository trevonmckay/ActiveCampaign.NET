using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class UpdateEcommerceOrderRequest
    {
        /// <summary>
        /// The id of the order in the external service.
        /// ONLY REQUIRED IF EXTERNALCHECKOUTID NOT INCLUDED.
        /// </summary>
        [JsonPropertyName("externalid")]
        public string? ExternalId { get; set; }

        /// <summary>
        /// The id of the cart in the external service.
        /// ONLY REQUIRED IF EXTERNALID IS NOT INCLUDED.
        /// </summary>
        [JsonPropertyName("externalcheckoutid")]
        public string? ExternalCheckoutId { get; set; }

        /// <summary>
        /// The email address of the customer who placed the order.
        /// </summary>
        public string? Email { get; set; }

        public ICollection<ECommerceOrderProduct>? OrderProducts { get; set; }

        public int? TotalPrice { get; set; }

        public int? ShippingAmount { get; set; }

        public int? TaxAmount { get; set; }

        public int? DiscountAmount { get; set; }

        /// <summary>
        /// The currency of the order (3-digit ISO code, e.g., 'USD').
        /// </summary>
        public string? Currency { get; set; }

        public string? OrderUrl { get; set; }

        public DateTimeOffset? ExternalUpdatedDate { get; set; }

        public DateTimeOffset? AbandonedDate { get; set; }

        public string? ShippingMethod { get; set; }

        public string? OrderNumber { get; set; }
    }
}
