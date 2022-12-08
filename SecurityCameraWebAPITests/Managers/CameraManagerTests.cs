using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityCameraWebAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityCameraWebAPI.Managers.Tests
{
    [TestClass()]
    public class CameraManagerTests
    {
        private CameraManager _cameraManager = new CameraManager();
        [TestMethod()]
        public void GetAllTest()
        {
            var actual = _cameraManager.GetAll().Count;
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var actual = _cameraManager.GetById(4).Picture;

            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void AddTest()
        {
            var camera = _cameraManager.GetById(1);
            _cameraManager.Add(camera);

            var actual = _cameraManager.GetAll().Count;
            var expected = 3;

            Assert.AreEqual(expected, actual);
            _cameraManager.Delete(camera.Id);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            var camera = _cameraManager.GetById(1);
            _cameraManager.Delete(camera.Id);

            var actual = _cameraManager.GetAll().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
            _cameraManager.Add(camera);
        }
    }
}