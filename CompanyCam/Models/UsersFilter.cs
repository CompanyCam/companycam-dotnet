using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class UsersFilter
    {
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }
        [JsonProperty("page")]
        public int? Page { get; set; }
    }
}
