using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Services;
using CompanyCamApi;
using Newtonsoft.Json;

namespace CompanyCam
{
    public class CreateUser
    {
        public string email_address { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }

        public static async Task<User> Create(CreateUser user)
        {
            var wrapper = new CreateUserWrapper()
            {
                user = user
            };

            var apiService = new ApiService();
            var response = await apiService.Client.PostAsJsonAsync("users/", wrapper);
            
            return await response.Content.ReadAsAsync<User>();
        }
    }
}
