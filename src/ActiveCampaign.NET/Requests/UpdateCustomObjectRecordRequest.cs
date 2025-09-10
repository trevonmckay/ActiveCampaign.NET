namespace ActiveCampaign
{
    public class UpdateCustomObjectRecordRequest
    {
        public string? Id { get; set; }

        public string? ExternalId { get; set; }

        public required IEnumerable<CustomObjectRecordFieldValue>? Fields { get; set; }

        public IDictionary<string, int[]>? Relationships { get; set; }
    }
}
