using ActiveCampaign.Serializers;
using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class CreateCustomFieldRequest
    {
        /// <summary>
        /// Possible Values: dropdown, hidden, checkbox, date, text, datetime, textarea, NULL, listbox, radio.
        /// </summary>
        public required string Type { get; set; }

        /// <summary>
        /// Title of the field being created.
        /// </summary>
        public required string Title { get; set; }

        [JsonPropertyName("descript")]
        public string? Description { get; set; }

        [JsonPropertyName("perstag")]
        public string? PersistentTag { get; set; }

        [JsonConverter(typeof(NumberToBooleanJsonConverter))]
        public bool? Visible { get; set; }

        /// <summary>
        /// Possible Vales: nimble, contactually, mindbody, salesforce,
        /// highrise, google_spreadsheets, pipedrive, onepage,
        /// google_contacts, freshbooks, shopify, zendesk, etsy,
        /// NULL, bigcommerce, capsule, bigcommerce_oauth, sugarcrm,
        /// zohocrm, batchbook.
        /// </summary>
        public string? Service { get; set; }

        /// <summary>
        /// Order of appearance in ‘My Fields’ tab.
        /// </summary>
        public int? OrderNumber { get; set; }
    }
}
