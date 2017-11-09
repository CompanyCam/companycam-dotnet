using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Models;
using CompanyCam.Services;
using CompanyCamSdk.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class User
    {
        public static CompanyCam.Models.User _user;

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            _user = await Helpers.CreateUser();
        }

        [TestMethod]
        public void CreateUser()
        {
            Assert.IsNotNull(_user?.Id);
        }

        [TestMethod]
        public async Task ListAllUsers()
        {
            var filters = new UsersFilter()
            {
                Page = 2,
                PerPage = 5
            };
            
            var users = await new UserService().GetAll(filters);

            Assert.IsNotNull(users[0]?.Id);
        }

        [TestMethod]
        public async Task GetUser()
        {
            var user = await new UserService().Get(_user.Id);

            Assert.IsNotNull(user?.Id);
        }

        [TestMethod]
        public async Task UpdateUser()
        {
            _user.FirstName = "UpdateUser";

            var returnUser = await new UserService().Update(_user.Id, _user);

            Assert.AreEqual(returnUser?.FirstName, "UpdateUser");
        }

        [TestMethod]
        public async Task GetCurrentUser()
        {
            var user = await new UserService().GetCurrent();

            Assert.IsNotNull(user?.Id);
        }

        [TestMethod]
        public async Task DeleteUser()
        {
            var response = await new UserService().Delete(_user.Id);

            Assert.IsTrue(response);
        }
    }
}
