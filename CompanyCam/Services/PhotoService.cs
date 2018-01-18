using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Builders;
using CompanyCam.Models;
using CompanyCam.Objects;

namespace CompanyCam.Services
{
    public class PhotoService : CompanyCamService
    {
        public PhotoService(CompanyCamRequestOptions options = null) : base(options) { }
        
        public async Task<List<Photo>> List(PhotoFilter model)
        {
            var url = QueryStringBuilder.BuildUrl("photos", model);

            var response = await Client.GetAsync(url);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<List<Photo>>();

            return result;
        }
        
        public async Task<Photo> Create(string projectId, Photo photo)
        {
            var wrapper = new PhotoWrapper()
            {
                photo = photo
            };

            var response = await Client.PostAsJsonAsync($"projects/{projectId}/photos/", wrapper);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Photo>();

            return result;
        }

        public async Task<Photo> Get(string photoId)
        {
            var response = await Client.GetAsync($"photos/{photoId}");
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Photo>();

            return result;
        }

        public async Task<Photo> Update(string photoId, Photo photo)
        {
            var wrapper = new PhotoWrapper()
            {
                photo = photo
            };

            var response = await Client.PutAsJsonAsync($"photos/{photoId}", wrapper);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Photo>();
            return result;
        }

        public async Task<bool> Delete(string photoId)
        {
            var response = await Client.DeleteAsync($"photos/{photoId}");
            HandleResponse(response);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        private class PhotoWrapper
        {
            public Photo photo { get; set; }
        }
    }
}
