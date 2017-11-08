using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Services;
using Newtonsoft.Json;

namespace CompanyCam
{
    public class Company
    {
        public string id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public Address address { get; set; }
        public List<Logo> logo { get; set; }

        public static async Task<Company> GetSingle(string companyId)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync($"companies/{companyId}");
            var result = await response.Content.ReadAsAsync<Company>();

            return result;
        }
    }

    
}
