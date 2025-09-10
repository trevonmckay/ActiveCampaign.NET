namespace ActiveCampaign
{
    public class CreateTagRequest
    {
        public required string Tag { get; set; }

        public required TagType TagType { get; set; }

        public string? Description { get; set; }
    }
}
