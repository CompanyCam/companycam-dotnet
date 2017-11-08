using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCam;
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
                name = "Agilx Office",
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
                status = "active",
                feature_image = new List<FeatureImage>
                {
                    new FeatureImage(){type = "thumbnail", url = "http://www.agilx.com/wp-content/uploads/2013/04/companycam.png"}
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


            var newUser = new CreateUser()
            {
                email_address = "keith.jett+" + rnd.Next(1, 1000).ToString() +  "@agilx.com",
                first_name = "Keith",
                last_name = "Jett",
                password = "Password$1",
                phone_number = "1234567891"
            };

            return await CompanyCam.CreateUser.Create(newUser);
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

            var newGroup = new CreateGroup()
            {
                name = "Test Group " + rnd.Next(1,1000).ToString(),
                users = userArray
            };
            var result = await CompanyCam.CreateGroup.Create(newGroup);
            return result;
        }
    }
}
