namespace ActiveCampaign
{
    public class ContactFieldValue
    {
        public int Contact { get; set; }

        public int Field { get; set; }

        public string? Value { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? LastUpdatedAt { get; set; }

        public IDictionary<string, string>? Links { get; set; }

        public int Id { get; set; }

        public string? Owner { get; set; }
    }
}
