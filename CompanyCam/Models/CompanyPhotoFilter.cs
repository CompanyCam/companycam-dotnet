using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class CompanyPhotoFilter
    {
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }
        [JsonProperty("page")]
        public int? Page { get; set; }
    }
}
