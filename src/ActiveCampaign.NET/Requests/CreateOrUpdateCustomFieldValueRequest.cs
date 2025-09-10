namespace ActiveCampaign
{
    public class CreateOrUpdateCustomFieldValueRequest
    {
        public required ContactCustomFieldValue FieldValue { get; set; }

        public bool? UseDefaults { get; set; }
    }
}
