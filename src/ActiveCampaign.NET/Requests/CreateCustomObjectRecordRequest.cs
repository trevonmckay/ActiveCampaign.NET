namespace ActiveCampaign
{
    public class CreateCustomObjectRecordRequest
    {
        public string? ExternalId { get; set; }

        public required IEnumerable<CustomObjectRecordFieldValue> Fields { get; set; }
    
        public IDictionary<string, int[]>? Relationships { get; set; }
    }
}
