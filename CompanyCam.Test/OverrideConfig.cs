using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyCam;
using CompanyCam.Models;
using CompanyCam.Objects;
using CompanyCam.Services;
using CompanyCamSdk.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class OverrideConfig
    {

        [TestMethod]
        public async Task CanOverrideConfig()
        {
            var service = new ProjectService(new CompanyCamRequestOptions()
            {
                ApiKey = "TESTAPIOVERIDE",
                UserEmailAddress = "someone@someone.com"
            });

            try
            {
                await service.List(new ProjectFilter());
            }
            catch (CompanyCamException companyCamException)
            {
                if (companyCamException.Message == "Unauthorized")
                {
                    return;
                }
            }

            Assert.Fail("Expected Unathorized");
        }
    }
}
