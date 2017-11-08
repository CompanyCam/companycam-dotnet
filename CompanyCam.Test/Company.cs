using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Company
    {

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            CompanyCam.Config.SetApiKey(TestConfiguration.Apikey);
            CompanyCam.Config.SetUserEmail(TestConfiguration.UserEmail);
        }
        [TestMethod]
        public async Task GetSingleCompany()
        {
            //var company = await CompanyCam.Company.GetSingle("3SwM_yt9");
            var company = await CompanyCam.Company.GetSingle("201549");

            Assert.IsNotNull(company?.id);
        }
    }
}
