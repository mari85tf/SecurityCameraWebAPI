using Microsoft.VisualStudio.TestTools.UnitTesting;
using CameraClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraClassLibrary.Tests
{
    [TestClass()]
    public class CameraTests
    {
        private Camera camera = new Camera() { Id = 1, PictureId = 1,Name="Test.jpeg", Date = DateTime.Now, Picture = File.ReadAllBytes("C:\\Users\\Maria\\Documents\\DENEMARKEN\\Project\\WebAPI\\SecurityCameraWebAPI\\Managers\\ParkerMo.jpeg"), FileType = "jpeg" };
        private Camera nullName = new Camera() { Id = 1, PictureId = 2, Name = null, Date = DateTime.Now, Picture = File.ReadAllBytes("C:\\Users\\Maria\\Documents\\DENEMARKEN\\Project\\WebAPI\\SecurityCameraWebAPI\\Managers\\ParkerMo.jpeg"), FileType = "jpeg" };
        private Camera onecharName = new Camera() { Id = 1, PictureId = 1, Name = "T", Date = DateTime.Now, Picture = File.ReadAllBytes("C:\\Users\\Maria\\Documents\\DENEMARKEN\\Project\\WebAPI\\SecurityCameraWebAPI\\Managers\\ParkerMo.jpeg"), FileType = "jpeg" };
        private Camera nullPicture = new Camera() { Id = 1, PictureId = 1, Name = "Test.jpeg", Date = DateTime.Now, Picture = null, FileType = "jpeg", MyImage = null };
        private Camera nullFileType = new Camera() { Id = 1, PictureId = 1, Name = "Test.jpeg", Date = DateTime.Now, Picture = File.ReadAllBytes("C:\\Users\\Maria\\Documents\\DENEMARKEN\\Project\\WebAPI\\SecurityCameraWebAPI\\Managers\\ParkerMo.jpeg"), FileType = null };

        [TestMethod()]
        public void ValidateNameTest()
        {
            camera.ValidateName();

            Assert.ThrowsException<ArgumentNullException>(() => nullName.ValidateName());
            Assert.ThrowsException<ArgumentException>(() => onecharName.ValidateName());
        }
        [TestMethod()]
        public void ValidatePictureTest()
        {
            camera.ValidatePicture();

            Assert.ThrowsException<ArgumentNullException>(() => nullPicture.ValidatePicture());
        }
        [TestMethod()]
        public void ValidateMyFileTypeTest()
        {
            camera.ValidateFileType();

            Assert.ThrowsException<ArgumentNullException>(() => nullFileType.ValidateFileType());
        }
        [TestMethod()]
        public void ToStringTest()
        {
            string actual = camera.ToString();
            string expected = "Id: 1 - PictureId: 1 - Name: Test.jpeg - Date: "+ DateTime.Now + " - Picture: System.Byte[] - MyImage:  - FileType: jpeg";

            Assert.AreEqual(expected, actual);
        }
    }
}