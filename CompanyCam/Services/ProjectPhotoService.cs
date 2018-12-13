using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Builders;
using CompanyCam.Models;
using CompanyCam.Objects;

namespace CompanyCam.Services
{
    public class ProjectPhotoService : CompanyCamService
    {
        public ProjectPhotoService(CompanyCamRequestOptions options = null) : base(options) { }

        public async Task<List<Photo>> List(ProjectPhotoFilter model)
        {
            this.SetHeaders();
            var builder = new PhotoUrlBuilder();
            var url = builder.BuildProjectPhotoUrl(model);

            var response = await Client.GetAsync(url);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<List<Photo>>();

            return result;
        }
    }
}
