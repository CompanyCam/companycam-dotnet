using System.Collections.Generic;
using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Photo
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
        [JsonProperty("creator_id")]
        public string CreatorId { get; set; }
        [JsonProperty("creator_type")]
        public string CreatorType { get; set; }
        [JsonProperty("creator_name")]
        public string CreatorName { get; set; }
        [JsonProperty("project_Id")]
        public int ProjectId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
        [JsonProperty("uris")]
        public List<Uri> Uris { get; set; }
        [JsonProperty("hash")]
        public string Hash { get; set; }
        [JsonProperty("internal")]
        public bool Internal { get; set; }
        [JsonProperty("captured_at")]
        public int CapturedAt { get; set; }
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }
        [JsonProperty("processing_status")]
        public string ProcessingStatus { get; set; }
    }
}
