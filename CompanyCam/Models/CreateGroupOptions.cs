using System.Collections.Generic;
using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class CreateGroupOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("users")]
        public List<string> Users { get; set; }
    }
}
