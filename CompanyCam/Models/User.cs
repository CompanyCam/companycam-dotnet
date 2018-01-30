using System.Collections.Generic;
using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("profile_image")]
        public List<ProfileImage> ProfileImage { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }
    }
}
