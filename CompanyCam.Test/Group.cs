using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Models;
using CompanyCam.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Group
    {
        public static CompanyCam.Models.User _user;
        public static CompanyCam.Models.Group _group;

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            _user = await Helpers.CreateUser();
            _group =  await Helpers.CreateGroup(_user?.Id);
        }

        [TestMethod]
        public void CreateGroup()
        {
            Assert.IsNotNull(_group?.Id);
        }

        [TestMethod]
        public async Task GetAllGroups()
        {
            var filter = new GroupFilter()
            {
                Page = 1,
                PerPage = 25
            };

            var groups = await new GroupService().List(filter);

            Assert.IsNotNull(groups);
        }

        [TestMethod]
        public async Task GetSingleGroup()
        {
            Assert.IsNotNull(_group?.Id);

            var group = await new GroupService().Get(_group.Id);

            Assert.IsNotNull(group?.Id);
        }

        [TestMethod]
        public async Task UpdateGroup()
        {
            Assert.IsNotNull(_group?.Id);

            _group.Name = "Test123";

            var result = await new GroupService().Update(_group.Id, _group);
            Assert.IsTrue(result.Name == "Test123");
        }

        [TestMethod]
        public async Task DeleteGroup()
        {
            Assert.IsNotNull(_group?.Id);

            var responseCode = await new GroupService().Delete(_group.Id);
            Assert.IsTrue(responseCode);
        }
        
    }
}
