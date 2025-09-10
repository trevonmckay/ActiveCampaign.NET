namespace ActiveCampaign
{
    public class CustomFieldCollectionResponse
    {
        public IEnumerable<CustomField> Fields { get; set; }

        public CollectionResponseMetadata? Meta { get; set; }
    }
}
