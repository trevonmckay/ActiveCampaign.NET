namespace ActiveCampaign
{
    public class ContactResponse
    {
        public IEnumerable<ContactFieldValue>? FieldValues { get; set; }

        public Contact? Contact { get; set; }
    }
}
