using System.Collections.Generic;
using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Company
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("logo")]
        public List<Logo> Logo { get; set; }
    }


}
