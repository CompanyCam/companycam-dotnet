using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyCam.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Company
    {

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            CompanyCam.CompanyCamConfiguration.SetApiKey(TestConfiguration.Apikey);
            CompanyCam.CompanyCamConfiguration.SetUserEmail(TestConfiguration.UserEmail);
        }
        [TestMethod]
        public async Task GetSingleCompany()
        {
            var company = await new CompanyService().Get("8");

            Assert.IsNotNull(company?.Id);
        }
    }
}
