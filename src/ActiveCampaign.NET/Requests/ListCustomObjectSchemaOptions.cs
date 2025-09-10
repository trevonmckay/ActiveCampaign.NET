namespace ActiveCampaign
{
    public class ListCustomObjectSchemaOptions
    {
        public int? Limit { get; set; }

        public int? Offset { get; set; }

        public CustomObjectSchemaFilters? Filters { get; set; }

        public string? ShowFields { get; set; }
    }

    public class CustomObjectSchemaFilters
    {
        public string? Slug { get; set; }

        public string? RelationshipId { get; set; }

        public string? RelationshipNamespace { get; set; }
    }
}
