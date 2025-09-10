namespace ActiveCampaign
{
    public class UpdateContactRequest
    {
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public IEnumerable<KeyValuePair<string, object>>? FieldValues { get; set; }
    }
}
