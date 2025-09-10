namespace ActiveCampaign
{
    public class ListCustomFieldsOptions
    {
        public int? Limit { get; set; }

        public CustomFieldsFilters? Filters { get; set; }
    }

    public class CustomFieldsFilters
    {
        public string? PersistentTag { get; set; }
    }
}
