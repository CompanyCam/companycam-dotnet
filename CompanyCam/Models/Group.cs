using System.Collections.Generic;
using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Group
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("users")]
        public List<User> Users { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        [JsonProperty("group_url")]
        public string GroupUrl { get; set; }
    }
}
