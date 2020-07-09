using System.Collections.Generic;
using CompanyCam.Objects;
using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class Project
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
        [JsonProperty("creator_id")]
        public string CreatorId { get; set; }
        [JsonProperty("creator_type")]
        public string CreatorType { get; set; }
        [JsonProperty("integration_relation_id")]
        public string IntegrationRelationId { get; set; }
        [JsonProperty("creator_name")]
        public string CreatorName { get; set; }
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
        [JsonProperty("geofence")]
        public List<Coordinates> Geofence { get; set; }
        [JsonProperty("feature_image")]
        public List<FeatureImage> FeatureImage { get; set; }
        [JsonProperty("project_url")]
        public string ProjectUrl { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("public")]
        public bool? Public { get; set; }
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }
    }
}
