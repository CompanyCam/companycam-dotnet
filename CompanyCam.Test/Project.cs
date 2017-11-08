using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyCam.Models;
using CompanyCam.Objects;
using CompanyCamSdk.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Project
    {

        public static CompanyCam.Project _project;

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            _project = await Helpers.CreateProject();
        }

        [TestMethod]
        public void CreateProject()
        {
            Assert.IsNotNull(_project?.id);
        }

        [TestMethod]
        public async Task UpdateProject()
        {
           

            var addr = new CompanyCam.Address()
            {
                street_address_1 = "800 A ST",
                street_address_2 = "",
                city = "",
                state = "",
                country = "US",
                postal_code = ""
            };

            _project.address = addr;
            _project.name = "Test Update";

            var returnProject = await CompanyCam.Project.Update(_project);

            Assert.AreEqual(returnProject?.name, "Test Update");
            Assert.AreEqual(returnProject?.address.street_address_1, "800 A ST");
        }

        [TestMethod]
        public async Task GetProject()
        {
            
            var returnProject = await CompanyCam.Project.Get(_project.id);

            Assert.AreEqual(returnProject?.id, _project.id);
        }

        [TestMethod]
        public async Task GetAllProjects()
        {
            var filters = new ProjectFilter()
            {
                page = 2,
                per_page = 5,
                status = Status.Active
            };

            var returnProjects = await CompanyCam.Project.GetAll(filters);

            if (returnProjects.Count <= 0)
            {
                Assert.Fail("No Projects Returned");
            }
        }

        [TestMethod]
        public async Task DeleteProject()
        {
            var responseCode = await CompanyCam.Project.Delete(_project.id);


            Assert.IsTrue(responseCode);
        }

        
    }
}
