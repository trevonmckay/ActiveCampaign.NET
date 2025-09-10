namespace ActiveCampaign
{
    public class ListEcommerceOrdersOptions
    {
        public EcommerceOrderFilters? Filters { get; set; }
    }

    public class EcommerceOrderFilters
    {
        public int? ConnectionId { get; set; }

        public string? ExternalId { get; set; }

        public string? ExternalCheckoutId { get; set; }

        public string? Email { get; set; }

        public EcommerceOrderState? State { get; set; }

        public string? CustomerId { get; set; }

        public DateOnly? ExternalCreatedDate { get; set; }
    }
}
