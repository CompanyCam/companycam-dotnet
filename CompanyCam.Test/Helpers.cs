using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCam;
using CompanyCam.Objects;
using CompanyCam.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    public class Helpers
    {

        public static async Task<CompanyCam.Project> CreateProject()
        {
            // set the static Api key
            CompanyCam.Config.SetApiKey(TestConfiguration.Apikey);
            // set the user email
            CompanyCam.Config.SetUserEmail(TestConfiguration.UserEmail);

            //Create Project
            var newProject = new CompanyCam.Project()
            {
                name = "Test Project",
                address = new CompanyCam.Address()
                {
                    street_address_1 = "",
                    street_address_2 = "",
                    city = "",
                    postal_code = "",
                    country = "US",
                    state = ""
                },
                coordinates = new Coordinates()
                {
                    lat = 40.8191702,
                    lon = -96.7119411
                },
                status = Status.Active,
                feature_image = new List<FeatureImage>
                {
                    new FeatureImage(){type = "thumbnail", url = "https://raowj40442-flywheel.netdna-ssl.com/wp-content/uploads/2017/01/Artboard-1.png"}
                }
            };

            return await CompanyCam.Project.Create(newProject);

        }

        //Create User
        public static async Task<CompanyCam.User> CreateUser()
        {
            CompanyCam.Config.SetApiKey(TestConfiguration.Apikey);
            // set the user email
            CompanyCam.Config.SetUserEmail(TestConfiguration.UserEmail);
            Random rnd = new Random();


            var newUser = new CreateUserOptions()
            {
                email_address = "test+" + rnd.Next(1, 100000).ToString() +  "@test.com",
                first_name = "Mr",
                last_name = "Test",
                password = "PaSsWoRd",
                phone_number = "1234567891"
            };

            return await CompanyCam.User.Create(newUser);
        }

        //Create Photo
        public static async Task<CompanyCam.Photo> CreatePhoto(string projectId)
        {
            CompanyCam.Config.SetApiKey(TestConfiguration.Apikey);
            // set the user email
            CompanyCam.Config.SetUserEmail(TestConfiguration.UserEmail);

            var newPhoto = new CompanyCam.Photo()
            {
                coordinates = new Coordinates()
                {
                    lat = 40.8191702,
                    lon = -96.7119411
                },
                captured_at = 1152230396,
                uri = "http://www.agilx.com/wp-content/uploads/2013/04/companycam.png"
            };

            return await CompanyCam.Photo.Create(projectId, newPhoto);
        }
        
        //Create Tag
        public static async Task<CompanyCam.Tag> CreateTag()
        {

            CompanyCam.Config.SetApiKey(TestConfiguration.Apikey);
            CompanyCam.Config.SetUserEmail(TestConfiguration.UserEmail);
            Random rnd = new Random();

            var newTag = new CompanyCam.Tag()
            {
                display_value = rnd.Next(1, 1000).ToString()
            };

            return await CompanyCam.Tag.CreateTag(newTag);
        }

        //Create Group
        public static async Task<CompanyCam.Group> CreateGroup(string userId)
        {
            CompanyCam.Config.SetApiKey(TestConfiguration.Apikey);
            CompanyCam.Config.SetUserEmail(TestConfiguration.UserEmail);
            Random rnd = new Random();

            var userArray = new List<string>();
            userArray.Add(userId);

            var newGroup = new CreateGroupOptions()
            {
                name = "Test Group " + rnd.Next(1,1000).ToString(),
                users = userArray
            };
            var result = await CompanyCam.Group.Create(newGroup);
            return result;
        }
    }
}
