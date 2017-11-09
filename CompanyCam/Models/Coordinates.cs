using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }
        [JsonProperty("lon")]
        public double Lon { get; set; }
    }
}