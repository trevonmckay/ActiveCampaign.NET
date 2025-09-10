namespace ActiveCampaign
{
    public class CreateContactRequest
    {
        public required string Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public IEnumerable<KeyValuePair<string, object>>? FieldValues { get; set; }
    }
}
