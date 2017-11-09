using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Models;
using CompanyCam.Objects;

namespace CompanyCam.Services
{
    public class CompanyService : CompanyCamService
    {
        public CompanyService(CompanyCamRequestOptions options = null) : base(options) { }

        public async Task<Company> Get(string companyId)
        {
            var response = await Client.GetAsync($"companies/{companyId}");
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Company>();
            return result;
        }
    }
}
