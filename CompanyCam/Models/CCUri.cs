using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Uri
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uri")]
        public string Url { get; set; }
    }
}
