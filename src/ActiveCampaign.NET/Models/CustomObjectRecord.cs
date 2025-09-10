namespace ActiveCampaign
{
    public class CustomObjectRecord
    {
        public string? Id { get; set; }

        public string? ExternalId { get; set; }

        public string? SchemaId { get; set; }

        public IEnumerable<CustomObjectRecordFieldValue>? Fields { get; set; }

        public IDictionary<string, int[]>? Relationships { get; set; }
    }
}
