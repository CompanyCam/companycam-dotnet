using System;
using System.Threading.Tasks;
using CompanyCam.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Tag
    {
        public static CompanyCam.Tag _tag;


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
               page = 2,
               per_page = 5
            };

            var tags = await CompanyCam.Tag.GetAllTags(filters);

            Assert.IsNotNull(tags[0]?.id);
        }

        [TestMethod]
        public void CreateTag()
        {
            Assert.IsNotNull(_tag.id);
        }

        [TestMethod]
        public async Task GetTag()
        {
            var tag = await CompanyCam.Tag.Get(_tag.id);
            Assert.IsNotNull(tag?.id);
        }

        [TestMethod]
        public async Task UpdateTag()
        {
            Random rnd = new Random();
            var newValue = rnd.Next(1, 1000).ToString();

            var newTag = new CompanyCam.Tag()
            {
                display_value = newValue
            };

            var tag = await CompanyCam.Tag.UpdateTag(_tag.id, newTag);

            Assert.AreEqual(tag.display_value, newValue);
        }
    }
}
