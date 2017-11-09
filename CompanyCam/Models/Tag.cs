using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Tag
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
        [JsonProperty("display_value")]
        public string DisplayValue { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }
    }
}
