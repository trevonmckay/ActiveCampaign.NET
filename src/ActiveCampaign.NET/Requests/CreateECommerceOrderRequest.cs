using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class CreateECommerceOrderRequest
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
        /// The order source code.
        /// 0 - historical.
        /// 1 - real-time.
        /// Only real-time orders (source = 1) will show up on your Ecommerce Dashboard
        /// and trigger the "Makes a purchase" automation start, abandoned cart actions,
        /// customer conversions, or revenue attributions.
        /// </summary>
        public required ECommerceOrderSource Source { get; set; }

        /// <summary>
        /// The email address of the customer who placed the order.
        /// </summary>
        public required string Email { get; set; }

        public ICollection<ECommerceOrderProduct>? OrderProducts { get; set; }

        public required int TotalPrice { get; set; }

        public int? ShippingAmount { get; set; }

        public int? TaxAmount { get; set; }

        public int? DiscountAmount { get; set; }

        /// <summary>
        /// The currency of the order (3-digit ISO code, e.g., 'USD').
        /// </summary>
        public required string Currency { get; set; }

        public string? OrderUrl { get; set; }

        /// <summary>
        /// The id of the connection from which this order originated.
        /// </summary>
        [JsonPropertyName("connectionid")]
        public required int ConnectionId { get; set; }

        /// <summary>
        /// The id of the customer associated with this order.
        /// </summary>
        [JsonPropertyName("customerid")]
        public required string CustomerId { get; set; }

        public required DateTimeOffset ExternalCreatedDate { get; set; }

        public DateTimeOffset? ExternalUpdatedDate { get; set; }

        public DateTimeOffset? AbandonedDate { get; set; }

        public string? ShippingMethod { get; set; }

        public string? OrderNumber { get; set; }
    }
}
