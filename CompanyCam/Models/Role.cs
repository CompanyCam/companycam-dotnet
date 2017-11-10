using System.Collections.Generic;
using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Role
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("permissions")]
        public List<Permission> Permissions { get; set; }
    }
}
