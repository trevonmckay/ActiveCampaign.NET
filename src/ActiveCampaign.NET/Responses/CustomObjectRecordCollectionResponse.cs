namespace ActiveCampaign
{
    public class CustomObjectRecordCollectionResponse
    {
        public IEnumerable<CustomObjectRecord>? Records { get; set; }

        public CollectionResponseMetadata? Meta { get; set; }
    }

    public class CollectionResponseMetadata
    {
        public long? Total { get; set; }

        public long? Count { get; set; }

        public long? Limit { get; set; }

        public long? Offset { get; set; }
    }
}
