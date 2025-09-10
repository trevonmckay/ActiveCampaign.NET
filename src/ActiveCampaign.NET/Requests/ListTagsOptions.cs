namespace ActiveCampaign
{
    public class ListTagsOptions
    {
        public string? Search { get; set; }

        public TagsFilters? Filters { get; set; }
    }

    public class TagsFilters
    {
        public string? Tag { get; set; }
    }
}
