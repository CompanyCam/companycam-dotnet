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
    public class Group
    {

        #region properties

        public string id { get; set; }
        public string companyId { get; set; }
        public string name { get; set; }
        public List<User> users { get; set; }
        public string status { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }
        public string group_url { get; set; }

        #endregion

        #region methods

        public static async Task<List<Group>> GetAll(GroupFilter model)
        {
            var url = QueryStringBuilder.BuildUrl("groups", model);

            var apiService = new ApiService();

            var response = await apiService.Client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<List<Group>>();
            return result;


        }

        public static async Task<Group> Create(Group group)
        {
            var wrapper = new GroupWrapper()
            {
                group = group
            };
            var apiService = new ApiService();

            var response = await apiService.Client.PostAsJsonAsync("groups/", wrapper);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<Group>();

            return result;

        }

        public static async Task<Group> Get(string groupId)
        {
            var apiService = new ApiService();


            var response = await apiService.Client.GetAsync($"groups/{groupId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<Group>();

            return result;

        }

        public static async Task<Group> Update(string groupId, Group group)
        {
            var wrapper = new GroupWrapper()
            {
                group = group
            };
            var apiService = new ApiService();
            var response = await apiService.Client.PutAsJsonAsync($"groups/{groupId}", wrapper);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<Group>();

            return result;
        }

        public static async Task<bool> Delete(string groupId)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.DeleteAsync($"groups/{groupId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public static async Task<Group> Create(CreateGroupOptions group)
        {
            var wrapper = new CreateGroupWrapper()
            {
                group = group
            };
            var apiService = new ApiService();
            var response = await apiService.Client.PostAsJsonAsync("groups/", wrapper);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<Group>();
            return result;
        }

        private class CreateGroupWrapper
        {
            public CreateGroupOptions group { get; set; }
        }
        private class GroupWrapper
        {
            public Group group { get; set; }
        }
        #endregion
    }
}
