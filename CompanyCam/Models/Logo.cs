using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Logo
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
