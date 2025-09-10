namespace ActiveCampaign
{
    public class ListCustomObjectRecordsOptions
    {
        public int? Limit { get; set; }

        public int? Offset { get; set; }

        public ListCustomObjectRecordsFilters? Filters { get; set; }
    }

    public class ListCustomObjectRecordsFilters
    {
        public int? ContactId { get; set; }
    }
}
