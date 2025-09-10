namespace ActiveCampaign
{
    public record SetEventTrackingRequest
    {
        public required EventTrackingStatus EventTracking { get; set; }
    }
}
