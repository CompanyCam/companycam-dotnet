using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Address
    {
        [JsonProperty("street_address_1")]
        public string StreetAddress1 { get; set; }
        [JsonProperty("street_address_2")]
        public string StreetAddress2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
