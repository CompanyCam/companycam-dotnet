using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Models;
using CompanyCamSdk.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class User
    {
        public static CompanyCam.User _user;

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            _user = await Helpers.CreateUser();
        }

        [TestMethod]
        public void CreateUser()
        {
            Assert.IsNotNull(_user?.id);
        }

        [TestMethod]
        public async Task ListAllUsers()
        {
            var filters = new UsersFilter()
            {
                Page = 2,
                PerPage = 5
            };
            
            var users = await CompanyCam.User.ListAllUsers(filters);

            Assert.IsNotNull(users[0]?.id);
        }

        [TestMethod]
        public async Task GetUser()
        {
            var user = await CompanyCam.User.GetSingle(_user.id);

            Assert.IsNotNull(user?.id);
        }

        [TestMethod]
        public async Task UpdateUser()
        {
            _user.first_name = "Bill";

            var returnUser = await CompanyCam.User.Update(_user.id, _user);

            Assert.AreEqual(returnUser?.first_name, "Bill");
        }

        [TestMethod]
        public async Task GetCurrentUser()
        {
            var user = await CompanyCam.User.GetCurrent();

            Assert.IsNotNull(user?.id);
        }

        [TestMethod]
        public async Task DeleteUser()
        {
            var response = await CompanyCam.User.Delete(_user.id);

            Assert.IsTrue(response);
        }
    }
}
