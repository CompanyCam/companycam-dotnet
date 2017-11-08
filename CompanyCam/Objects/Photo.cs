using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Builders;
using CompanyCam.Models;
using CompanyCam.Objects;
using CompanyCam.Services;
using Newtonsoft.Json;

namespace CompanyCam
{
    public class Photo
    {

        #region properties

        public string id { get; set; }
        public string company_id { get; set; }
        public string creator_id { get; set; }
        public string creator_type { get; set; }
        public string creator_name { get; set; }
        public int project_id { get; set; }
        public string status { get; set; }
        public Coordinates coordinates { get; set; }
        public List<Uri> uris { get; set; }
        public string uri { get; set; }
        public string hash { get; set; }
        public bool @internal { get; set; }
        public int captured_at { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }

        #endregion

        #region methods

        public static async Task<List<Photo>> GetAll(PhotoFilter model)
        {
            var url = QueryStringBuilder.BuildUrl("photos", model);

            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<List<Photo>>();

            return result;
        }

        public static async Task<List<Photo>> GetAllProject(ProjectPhotoFilter model)
        {
            var builder = new PhotoUrlBuilder();
            var url = builder.BuildProjectPhotoUrl(model);

            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<List<Photo>>();

            return result;
        }

        public static async Task<Photo> Create(string projectId, Photo photo)
        {
            var wrapper = new PhotoWrapper()
            {
                photo = photo
            };
            var apiService = new ApiService();
            var response = await apiService.Client.PostAsJsonAsync($"projects/{projectId}/photos/", wrapper);
            var result = await response.Content.ReadAsAsync<Photo>();

            return result;
        }

        public static async Task<Photo> GetSingle(string photoId)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync($"photos/{photoId}");
            var result = await response.Content.ReadAsAsync<Photo>();

            return result;
        }

        public static async Task<bool> Update(string photoId, Photo photo)
        {
            var wrapper = new PhotoWrapper()
            {
                photo = photo
            };
            var apiService = new ApiService();
            var response = await apiService.Client.PutAsJsonAsync($"photos/{photoId}", wrapper);
            
            return response.StatusCode == HttpStatusCode.OK;
        }

        public static async Task<bool> Delete(string photoId)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.DeleteAsync($"photos/{photoId}");

            return response.StatusCode == HttpStatusCode.NoContent;
        }
        
        #endregion
    }
}
