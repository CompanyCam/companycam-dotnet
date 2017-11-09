using Newtonsoft.Json;

namespace CompanyCam.Models
{
    public class CreateUserOptions
    {
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
