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
    public class User
    {
        #region Properties
        public string id { get; set; }
        public string company_id { get; set; }
        public string email_address { get; set; }
        public string status { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public List<ProfileImage> profile_image { get; set; }
        public string phone_number { get; set; }
        public Role role { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }
        #endregion

        #region Methods

        public static async Task<List<User>> ListAllUsers(UsersFilter model)
        {
            var url = QueryStringBuilder.BuildUrl("users", model);

            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<List<User>>();

            return result;
        }

        public static async Task<User> Get(string userId)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync($"users/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<User>();

            return result;
        }

        public static async Task<User> Update(string userId, User user)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.PutAsJsonAsync($"users/{userId}", user);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            return await response.Content.ReadAsAsync<User>();

        }

        public static async Task<bool> Delete(string userId)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.DeleteAsync($"users/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public static async Task<User> GetCurrent()
        {
            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync($"users/current");
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            return await response.Content.ReadAsAsync<User>();
        }

        public static async Task<User> Create(CreateUserOptions user)
        {
            var wrapper = new CreateUserWrapper()
            {
                user = user
            };

            var apiService = new ApiService();

            var response = await apiService.Client.PostAsJsonAsync("users/", wrapper);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            return await response.Content.ReadAsAsync<User>();

        }
        private class CreateUserWrapper
        {
            public CreateUserOptions user { get; set; }
        }
        #endregion
    }
}
