namespace ActiveCampaign
{
    public class CustomObjectSchema
    {
        public string? Id { get; set; }

        public string? Slug { get; set; }

        public string? ParentId { get; set; }

        public int? ParentVersion { get; set; }

        public string? Visibility { get; set; }

        public bool? Customized { get; set; }

        public CustomObjectSchemaLabels? Labels { get; set; }

        public string? Description { get; set; }

        public string? AppId { get; set; }

        public DateTimeOffset? CreatedTimestamp { get; set; }

        public DateTimeOffset? UpdatedTimestamp { get; set; }

        public DateTimeOffset? ParentSchemaCreatedTimestamp { get; set; }

        public DateTimeOffset? ParentSchemaUpdatedTimestamp { get; set; }

        public IEnumerable<CustomObjectSchemaField>? Fields { get; set; }
    }

    public class CustomObjectSchemaLabels
    {
        public string? Singular { get; set; }

        public string? Plural { get; set; }
    }

    public class CustomObjectSchemaField
    {
        public string? Id { get; set; }

        public CustomObjectSchemaLabels? Labels { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }

        public bool? Required { get; set; }

        public IEnumerable<CustomObjectSchemaFieldOption>? Options { get; set; }

        public int? Scale { get; set; }

        public string? DefaultCurrency { get; set; }

        public bool? Inherited { get; set; }
    }

    public class CustomObjectSchemaFieldOption
    {
        public string? Id { get; set; }

        public string? Value { get; set; }
    }
}
