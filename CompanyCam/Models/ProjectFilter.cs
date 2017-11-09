using CompanyCam.Objects;
using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class ProjectFilter
    {
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }
        [JsonProperty("page")]
        public int? Page { get; set; }
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
