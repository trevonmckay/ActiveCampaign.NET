namespace ActiveCampaign
{
    public enum EcommerceOrderState
    {
        Pending = 0,

        Completed = 1,

        Abandoned = 2,

        Recovered = 3,

        /// <summary>
        /// Customer checked out but payment is not yet completed.
        /// </summary>
        Waiting = 4,
    }
}
