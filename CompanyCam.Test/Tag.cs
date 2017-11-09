using System;
using System.Threading.Tasks;
using CompanyCam.Models;
using CompanyCam.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Tag
    {
        public static CompanyCam.Models.Tag _tag;


        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            _tag = await Helpers.CreateTag();
        }

        [TestMethod]
        public async Task GetAllTags()
        {
            var filters = new TagFilter()
            {
               Page = 2,
               PerPage = 5
            };

            var tags = await new TagService().GetAll(filters);

            Assert.IsNotNull(tags[0]?.Id);
        }

        [TestMethod]
        public void CreateTag()
        {
            Assert.IsNotNull(_tag.Id);
        }

        [TestMethod]
        public async Task GetTag()
        {
            var tag = await new TagService().Get(_tag.Id);
            Assert.IsNotNull(tag?.Id);
        }

        [TestMethod]
        public async Task UpdateTag()
        {
            Random rnd = new Random();
            var newValue = rnd.Next(1, 1000).ToString();

            var newTag = new CompanyCam.Models.Tag()
            {
                DisplayValue = newValue
            };

            var tag = await new TagService().Update(_tag.Id, newTag);

            Assert.AreEqual(tag.DisplayValue, newValue);
        }
    }
}
