using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Permission
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
