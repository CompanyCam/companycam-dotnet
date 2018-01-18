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
    public class GroupService : CompanyCamService
    {
        public GroupService(CompanyCamRequestOptions options = null) : base(options) { }


        public async Task<List<Group>> List(GroupFilter model)
        {
            var url = QueryStringBuilder.BuildUrl("groups", model);

            var response = await Client.GetAsync(url);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<List<Group>>();
            return result;


        }

        public async Task<Group> Get(string groupId)
        {
            var response = await Client.GetAsync($"groups/{groupId}");
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Group>();

            return result;

        }

        public async Task<Group> Update(string groupId, Group group)
        {
            var wrapper = new GroupWrapper()
            {
                group = group
            };

            var response = await Client.PutAsJsonAsync($"groups/{groupId}", wrapper);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Group>();

            return result;
        }

        public async Task<bool> Delete(string groupId)
        {
            var response = await Client.DeleteAsync($"groups/{groupId}");
            HandleResponse(response);
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<Group> Create(CreateGroupOptions group)
        {
            var wrapper = new CreateGroupWrapper()
            {
                group = group
            };

            var response = await Client.PostAsJsonAsync("groups/", wrapper);
            HandleResponse(response);
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
    }
}
