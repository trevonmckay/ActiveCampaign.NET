using ActiveCampaign.Serializers;
using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    public class CustomField
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [JsonPropertyName("descript")]
        public string? Description { get; set; }

        public string? Type { get; set; }

        [JsonPropertyName("isrequired")]
        [JsonConverter(typeof(NumberToBooleanJsonConverter))]
        public bool? IsRequired { get; set; }

        [JsonPropertyName("perstag")]
        public string? PersistentTag { get; set; }

        [JsonPropertyName("cdate")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonPropertyName("udate")]
        public DateTimeOffset? LastModifiedAt { get; set; }

        public IDictionary<string, string>? Links { get; set; }
    }
}
