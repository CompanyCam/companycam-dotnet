using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCam.Services
{
    public class ApiService
    {
        public HttpClient Client;

        public ApiService()
        {
            var url = $"https://api.companycam.com/v2/"; // set the URL for the API

            this.Client = new HttpClient()
            {
                BaseAddress = new System.Uri(url)
            };
            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.ApiKey);
            this.Client.DefaultRequestHeaders.Add("X-CompanyCam-User", Config.UserEmailAddress);
            this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
