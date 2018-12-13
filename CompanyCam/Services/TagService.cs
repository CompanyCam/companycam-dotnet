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
    public class TagService : CompanyCamService
    {
        public TagService(CompanyCamRequestOptions options = null) : base(options) { }

        public async Task<List<Tag>> List(TagFilter model)
        {
            this.SetHeaders();
            var url = QueryStringBuilder.BuildUrl("tags", model);

            var response = await Client.GetAsync(url);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<List<Tag>>();

            return result;
        }

        public async Task<Tag> Create(Tag newTag)
        {
            this.SetHeaders();
            var response = await Client.PostAsJsonAsync("tags", newTag);
            HandleResponse(response);
            return await response.Content.ReadAsAsync<Tag>();
        }

        public async Task<Tag> Get(string tagId)
        {
            this.SetHeaders();
            var response = await Client.GetAsync($"tags/{tagId}");
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Tag>();

            return result;
        }

        public async Task<Tag> Update(string tagId, Tag updatedTag)
        {
            this.SetHeaders();
            var response = await Client.PutAsJsonAsync($"tags/{tagId}", updatedTag);
            HandleResponse(response);
            return await response.Content.ReadAsAsync<Tag>();
        }
    }
}
