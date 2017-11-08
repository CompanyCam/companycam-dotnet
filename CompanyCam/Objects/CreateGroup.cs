using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Objects;
using CompanyCam.Services;
using Newtonsoft.Json;

namespace CompanyCam
{
    public class CreateGroup
    {
        public string name { get; set; }
        public List<string> users { get; set; }

        public static async Task<Group> Create(CreateGroup group)
        {
            var wrapper = new CreateGroupWrapper()
            {
                group = group
            };
            var apiService = new ApiService();
            var response = await apiService.Client.PostAsJsonAsync("groups/", wrapper);

            var result = await response.Content.ReadAsAsync<Group>();
            return result;
        }
    }
}
