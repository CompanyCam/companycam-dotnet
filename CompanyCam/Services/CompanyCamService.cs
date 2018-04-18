using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using CompanyCam.Objects;

namespace CompanyCam.Services
{
    public class CompanyCamService
    {
        public CompanyCamRequestOptions Options { get; set; }
        public HttpClient Client;

        protected CompanyCamService(CompanyCamRequestOptions options)
        {
            Options = options;

            var url = $"https://api.companycam.com/v2/"; // set the URL for the API

            this.Client = new HttpClient()
            {
                BaseAddress = new System.Uri(url)
            };
            this.Client.DefaultRequestHeaders.Add("X-CompanyCam-Secret", Options?.SecretKey ?? CompanyCamConfiguration.GetSecretKey());
            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Options?.ApiKey ?? CompanyCamConfiguration.GetApiKey());
            this.Client.DefaultRequestHeaders.Add("X-CompanyCam-User", Options?.UserEmailAddress ?? CompanyCamConfiguration.GetUserEmail());
            this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        internal static void HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString(), new Exception(response.ReasonPhrase));
            }
        }
    }
}
