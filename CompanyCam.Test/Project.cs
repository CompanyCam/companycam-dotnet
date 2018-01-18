using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyCam.Models;
using CompanyCam.Objects;
using CompanyCam.Services;
using CompanyCamSdk.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Project
    {

        public static CompanyCam.Models.Project _project;

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            _project = await Helpers.CreateProject();
        }

        [TestMethod]
        public void CreateProject()
        {
            Assert.IsNotNull(_project?.Id);
        }

        [TestMethod]
        public async Task UpdateProject()
        {
           

            var addr = new Address()
            {
                StreetAddress1 = "800 A ST",
                StreetAddress2 = "",
                City = "",
                State = "",
                Country = "US",
                PostalCode = ""
            };

            _project.Address = addr;
            _project.Name = "Test Update";

            var returnProject = await new ProjectService().Update(_project);

            Assert.AreEqual(returnProject?.Name, "Test Update");
            Assert.AreEqual(returnProject?.Address.StreetAddress1, "800 A ST");
        }

        [TestMethod]
        public async Task GetProject()
        {
            
            var returnProject = await new ProjectService().Get(_project.Id);

            Assert.AreEqual(returnProject?.Id, _project.Id);
        }

        [TestMethod]
        public async Task GetAllProjects()
        {
            var filters = new ProjectFilter()
            {
                Page = 2,
                PerPage = 5,
                Status = Status.Active
            };

            var returnProjects = await new ProjectService().List(filters);

            if (returnProjects.Count <= 0)
            {
                Assert.Fail("No Projects Returned");
            }
        }

        [TestMethod]
        public async Task DeleteProject()
        {
            var responseCode = await new ProjectService().Delete(_project.Id);


            Assert.IsTrue(responseCode);
        }

        
    }
}
