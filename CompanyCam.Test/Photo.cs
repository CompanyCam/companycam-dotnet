using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CompanyCam.Models;
using CompanyCam.Objects;
using CompanyCamSdk.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Photo
    {
        public static CompanyCam.Project _project;
        public static CompanyCam.Photo _photo;
        public static CompanyCam.User _user;

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            _project = await Helpers.CreateProject();
            _photo = await Helpers.CreatePhoto(_project.id);
            _user = await Helpers.CreateUser();
        }

        [TestMethod]
        public void CreatePhoto()
        {
            Assert.IsNotNull(_photo?.id);
        }

        [TestMethod]
        public async Task GetAllPhotos()
        {
            var model = new PhotoFilter()
            {
                per_page = 20,
                page = 2,
                status = Status.Active, 
            };

            var photos = await CompanyCam.Photo.GetAll(model);
            Assert.IsTrue(photos.Count >= 1);
        }

        [TestMethod]
        public async Task GetAllProjectPhotos()
        {
            var model = new ProjectPhotoFilter()
            {
                projectId = _project.id,
                status = Status.Active,
            };

            var photos = await CompanyCam.Photo.GetAllProject(model);
            Assert.IsTrue(photos.Count >= 1);
        }

        [TestMethod]
        public async Task GetSinglePhoto()
        {
            Assert.IsNotNull(_photo?.id);

            var photo = await CompanyCam.Photo.Get(_photo.id);

            Assert.IsNotNull(photo?.id);
        }

        [TestMethod]
        public async Task UpdatePhoto()
        {
            
            Assert.IsNotNull(_photo?.id);

            _photo.@internal = true;

            var photo = await CompanyCam.Photo.Update(_photo.id, _photo);
            Assert.IsTrue(photo.@internal == true);
        }

        [TestMethod]
        public async Task DeletePhoto()
        {
            
            Assert.IsNotNull(_photo?.id);

            var responseCode = await CompanyCam.Photo.Delete(_photo.id);
            Assert.IsTrue(responseCode);
        }
    }
}
