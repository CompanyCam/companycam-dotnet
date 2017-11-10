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
    public class UserService : CompanyCamService
    {
        public UserService(CompanyCamRequestOptions options = null) : base(options) { }
        
        public async Task<List<User>> GetAll(UsersFilter model)
        {
            var url = QueryStringBuilder.BuildUrl("users", model);

            var response = await Client.GetAsync(url);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<List<User>>();

            return result;
        }

        public async Task<User> Get(string userId)
        {
            var response = await Client.GetAsync($"users/{userId}");
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<User>();

            return result;
        }

        public async Task<User> Update(string userId, User user)
        {
            var response = await Client.PutAsJsonAsync($"users/{userId}", user);
            HandleResponse(response);
            return await response.Content.ReadAsAsync<User>();

        }

        public async Task<bool> Delete(string userId)
        {
            var response = await Client.DeleteAsync($"users/{userId}");
            HandleResponse(response);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<User> GetCurrent()
        {
            var response = await Client.GetAsync($"users/current");
            HandleResponse(response);
            return await response.Content.ReadAsAsync<User>();
        }

        public async Task<User> Create(CreateUserOptions user)
        {
            var wrapper = new CreateUserWrapper()
            {
                user = user
            };

            var response = await Client.PostAsJsonAsync("users/", wrapper);
            HandleResponse(response);
            return await response.Content.ReadAsAsync<User>();

        }
        private class CreateUserWrapper
        {
            public CreateUserOptions user { get; set; }
        }
    }
}
