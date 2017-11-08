using System;
using System.Collections.Generic;
using System.Linq;
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
    public class Tag
    {
        public string id { get; set; }
        public string company_id { get; set; }
        public string display_value { get; set; }
        public string value { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }


        public static async Task<List<Tag>> GetAllTags(TagFilter model)
        {
            var url = QueryStringBuilder.BuildUrl("tags", model);

            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<List<Tag>>();

            return result;
        }

        public static async Task<Tag> CreateTag(Tag newTag)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.PostAsJsonAsync("tags", newTag);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            return await response.Content.ReadAsAsync<Tag>();
        }

        public static async Task<Tag> Get(string tagId)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync($"tags/{tagId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<Tag>();

            return result;
        }

        public static async Task<Tag> UpdateTag(string tagId, Tag updatedTag)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.PutAsJsonAsync($"tags/{tagId}", updatedTag);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            return await response.Content.ReadAsAsync<Tag>();
        }
    }
}
