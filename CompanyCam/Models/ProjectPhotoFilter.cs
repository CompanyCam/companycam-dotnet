using System.Collections.Generic;
using CompanyCam.Objects;
using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class ProjectPhotoFilter
    {
        [JsonProperty("projectId")]
        public string ProjectId { get; set; }
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }
        [JsonProperty("page")]
        public int? Page { get; set; }
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("start_date")]
        public int? StartDate { get; set; }
        [JsonProperty("end_date")]
        public int? EndDate { get; set; }
        [JsonProperty("user_ids")]
        public List<string> UserIds { get; set; }
        [JsonProperty("group_ids")]
        public List<string> GroupIds { get; set; }
        [JsonProperty("tag_ids")]
        public List<string> TagIds { get; set; }
    }
}
