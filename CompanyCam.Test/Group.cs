using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Group
    {
        public static CompanyCam.User _user;
        public static CompanyCam.Group _group;

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            _user = await Helpers.CreateUser();
            _group =  await Helpers.CreateGroup(_user?.id);
        }

        [TestMethod]
        public void CreateGroup()
        {
            Assert.IsNotNull(_group?.id);
        }

        [TestMethod]
        public async Task GetAllGroups()
        {
            var filter = new GroupFilter()
            {
                page = 1,
                per_page = 25
            };

            var groups = await CompanyCam.Group.GetAll(filter);

            Assert.IsNotNull(groups);
        }

        [TestMethod]
        public async Task GetSingleGroup()
        {
            Assert.IsNotNull(_group?.id);

            var group = await CompanyCam.Group.Get(_group.id);

            Assert.IsNotNull(group?.id);
        }

        [TestMethod]
        public async Task UpdateGroup()
        {
            Assert.IsNotNull(_group?.id);

            _group.name = "Test123";

            var result = await CompanyCam.Group.Update(_group.id, _group);
            Assert.IsTrue(result.name == "Test123");
        }

        [TestMethod]
        public async Task DeleteGroup()
        {
            Assert.IsNotNull(_group?.id);

            var responseCode = await CompanyCam.Group.Delete(_group.id);
            Assert.IsTrue(responseCode);
        }
        
    }
}
