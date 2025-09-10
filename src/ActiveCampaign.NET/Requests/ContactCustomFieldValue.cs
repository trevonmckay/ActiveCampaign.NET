namespace ActiveCampaign
{
    public class ContactCustomFieldValue
    {
        public required int Contact { get; set; }

        public required int Field { get; set; }

        public required object? Value { get; set; }
    }
}
