namespace ActiveCampaign
{
    public class ContactTagResponse
    {
        public IEnumerable<Contact>? Contacts { get; set; }

        public ContactTag ContactTag { get; set; }
    }
}
