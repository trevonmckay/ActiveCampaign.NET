namespace ActiveCampaign
{
    public class ECommerceOrderResponse
    {
        public ECommerceOrder EcomOrder { get; set; }

        public IEnumerable<ECommerceOrderProduct>? EcomOrderProducts { get; set; }
    }
}
