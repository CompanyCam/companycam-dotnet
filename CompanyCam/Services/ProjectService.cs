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
    public class ProjectService : CompanyCamService
    {
        public ProjectService(CompanyCamRequestOptions options = null) : base(options) { }
        
        /// <summary>
        /// Get all project for company
        /// </summary>
        /// <returns></returns>
        public async Task<List<Project>> List(ProjectFilter model)
        {

            var url = QueryStringBuilder.BuildUrl("projects", model);
            this.SetHeaders();
            var response = await Client.GetAsync(url);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<List<Project>>();

            return result;
        }

        /// <summary>
        /// Gets the project with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Project> Get(string id)
        {
            this.SetHeaders();
            var response = await Client.GetAsync($"projects/{id}");
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Project>();

            return result;
        }

        /// <summary>
        /// Creates a new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public async Task<Project> Create(Project project)
        {
            this.SetHeaders();
            var response = await Client.PostAsJsonAsync("projects", project);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Project>();

            return result;
        }

        /// <summary>
        /// Updates the selected project
        /// </summary>
        /// <param name="projectWrapper"></param>
        /// <returns></returns>
        public async Task<Project> Update(Project project)
        {
            var wrapper = new ProjectWrapper()
            {
                project = project
            };
            this.SetHeaders();
            var response = await Client.PutAsJsonAsync($"projects/{project.Id}", wrapper);
            HandleResponse(response);
            var result = await response.Content.ReadAsAsync<Project>();

            return result;

        }

        /// <summary>
        /// Delete the project with the provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            this.SetHeaders();
            var response = await Client.DeleteAsync($"projects/{id}");
            HandleResponse(response);
            return response.StatusCode == HttpStatusCode.NoContent;
        }
        public class ProjectWrapper
        {
            public Project project { get; set; }
        }
    }
}
