using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCam;
using CompanyCam.Models;
using CompanyCam.Objects;
using CompanyCam.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    public class Helpers
    {

        public static async Task<CompanyCam.Models.Project> CreateProject()
        {
            CompanyCam.CompanyCamConfiguration.SetApiKey(TestConfiguration.Apikey);
            CompanyCam.CompanyCamConfiguration.SetUserEmail(TestConfiguration.UserEmail);

            //Create Project
            var newProject = new CompanyCam.Models.Project()
            {
                Name = "Test Project",
                Address = new Address()
                {
                    StreetAddress1 = "",
                    StreetAddress2 = "",
                    City = "",
                    PostalCode = "",
                    Country = "US",
                    State = ""
                },
                Coordinates = new Coordinates()
                {
                    Lat = 40.8191702,
                    Lon = -96.7119411
                },
                Status = Status.Active,
                FeatureImage = new List<FeatureImage>
                {
                    new FeatureImage(){Type = "thumbnail", Url = "https://raowj40442-flywheel.netdna-ssl.com/wp-content/uploads/2017/01/Artboard-1.png"}
                }
            };

            return await new ProjectService().Create(newProject);

        }

        //Create User
        public static async Task<CompanyCam.Models.User> CreateUser()
        {
            CompanyCam.CompanyCamConfiguration.SetApiKey(TestConfiguration.Apikey);
            CompanyCam.CompanyCamConfiguration.SetUserEmail(TestConfiguration.UserEmail);

            Random rnd = new Random();
            
            var newUser = new CreateUserOptions()
            {
                EmailAddress = "test+" + rnd.Next(1, 100000).ToString() +  "@test.com",
                FirstName = "Mr",
                LastName = "Test",
                Password = "PaSsWoRd",
                PhoneNumber = "1234567891"
            };

            return await new UserService().Create(newUser);
        }

        //Create Photo
        public static async Task<CompanyCam.Models.Photo> CreatePhoto(string projectId)
        {
            CompanyCam.CompanyCamConfiguration.SetApiKey(TestConfiguration.Apikey);
            CompanyCam.CompanyCamConfiguration.SetUserEmail(TestConfiguration.UserEmail);

            var newPhoto = new CompanyCam.Models.Photo()
            {
                Coordinates = new Coordinates()
                {
                    Lat = 40.8191702,
                    Lon = -96.7119411
                },
                CapturedAt = 1152230396,
                Uri = "http://www.agilx.com/wp-content/uploads/2013/04/companycam.png"
            };

            return await new PhotoService().Create(projectId, newPhoto);
        }
        
        //Create Tag
        public static async Task<CompanyCam.Models.Tag> CreateTag()
        {
            CompanyCam.CompanyCamConfiguration.SetApiKey(TestConfiguration.Apikey);
            CompanyCam.CompanyCamConfiguration.SetUserEmail(TestConfiguration.UserEmail);

            Random rnd = new Random();

            var newTag = new CompanyCam.Models.Tag()
            {
                DisplayValue = rnd.Next(1, 1000).ToString()
            };

            return await new TagService().Create(newTag);
        }

        //Create Group
        public static async Task<CompanyCam.Models.Group> CreateGroup(string userId)
        {
            CompanyCam.CompanyCamConfiguration.SetApiKey(TestConfiguration.Apikey);
            CompanyCam.CompanyCamConfiguration.SetUserEmail(TestConfiguration.UserEmail);

            Random rnd = new Random();

            var userArray = new List<string>();
            userArray.Add(userId);

            var newGroup = new CreateGroupOptions()
            {
                Name = "Test Group " + rnd.Next(1,1000).ToString(),
                Users = userArray
            };
            var result = await new GroupService().Create(newGroup);
            return result;
        }
    }
}
