using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CompanyCam.Models;
using CompanyCam.Objects;
using CompanyCam.Services;
using CompanyCamSdk.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCamSdk.Test
{
    [TestClass]
    public class Photo
    {
        public static CompanyCam.Models.Project _project;
        public static CompanyCam.Models.Photo _photo;
        public static CompanyCam.Models.User _user;

        [ClassInitialize()]
        public static async Task ClassInit(TestContext context)
        {
            _project = await Helpers.CreateProject();
            _photo = await Helpers.CreatePhoto(_project.Id);
            _user = await Helpers.CreateUser();
        }

        [TestMethod]
        public void CreatePhoto()
        {
            Assert.IsNotNull(_photo?.Id);
        }

        [TestMethod]
        public async Task GetAllPhotos()
        {
            var model = new PhotoFilter()
            {
                PerPage = 20,
                Page = 2,
                Status = Status.Active, 
            };

            var photos = await new PhotoService().List(model);
            Assert.IsTrue(photos.Count >= 1);
        }

        [TestMethod]
        public async Task GetAllProjectPhotos()
        {
            var model = new ProjectPhotoFilter()
            {
                ProjectId = _project.Id,
                Status = Status.Active,
            };

            var photos = await new ProjectPhotoService().List(model);
            Assert.IsTrue(photos.Count >= 1);
        }

        [TestMethod]
        public async Task GetSinglePhoto()
        {
            Assert.IsNotNull(_photo?.Id);

            var photo = await new PhotoService().Get(_photo.Id);

            Assert.IsNotNull(photo?.Id);
        }

        [TestMethod]
        public async Task UpdatePhoto()
        {
            
            Assert.IsNotNull(_photo?.Id);

            _photo.Internal = true;

            var photo = await new PhotoService().Update(_photo.Id, _photo);
            Assert.IsTrue(photo.Internal == true);
        }

        [TestMethod]
        public async Task DeletePhoto()
        {
            
            Assert.IsNotNull(_photo?.Id);

            var responseCode = await new PhotoService().Delete(_photo.Id);
            Assert.IsTrue(responseCode);
        }
    }
}
