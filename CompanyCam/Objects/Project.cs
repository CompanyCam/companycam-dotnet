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
    public class Project
    {

        #region properties
        public string id { get; set; }
        public string company_id { get; set; }
        public string creator_id { get; set; }
        public string creator_type { get; set; }
        public string creator_name { get; set; }
        public Status status { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public Coordinates coordinates { get; set; }
        public List<Coordinates> geofence { get; set; }
        public List<FeatureImage> feature_image { get; set; }
        public string project_url { get; set; }
        public string slug { get; set; }
        public bool @public { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Get all project for company
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Project>> GetAll(ProjectFilter model)
        {

            var url = QueryStringBuilder.BuildUrl("projects", model);

            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<List<Project>>();

            return result;
        }

        /// <summary>
        /// Gets the project with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<Project> Get(string id)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.GetAsync($"projects/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<Project>();

            return result;
        }

        /// <summary>
        /// Creates a new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public static async Task<Project> Create(Project project)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.PostAsJsonAsync("projects", project);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<Project>();

            return result;
        }

        /// <summary>
        /// Updates the selected project
        /// </summary>
        /// <param name="projectWrapper"></param>
        /// <returns></returns>
        public static async Task<Project> Update(Project project)
        {
            var wrapper = new ProjectWrapper()
            {
                project = project
            };
            var apiService = new ApiService();
            var response = await apiService.Client.PutAsJsonAsync($"projects/{project.id}", wrapper);
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            var result = await response.Content.ReadAsAsync<Project>();

            return result;

        }

        /// <summary>
        /// Delete the project with the provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<bool> Delete(string id)
        {
            var apiService = new ApiService();
            var response = await apiService.Client.DeleteAsync($"projects/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new CompanyCamException(response.StatusCode.ToString());
            }
            return response.StatusCode == HttpStatusCode.NoContent;
        }
        public class ProjectWrapper
        {
            public Project project { get; set; }
        }
        #endregion

    }
}
