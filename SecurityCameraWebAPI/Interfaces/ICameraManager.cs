using CameraClassLibrary;

namespace SecurityCameraWebAPI.Interfaces
{
    public interface ICameraManager
    {
        public List<Camera> GetAll();
        public Camera GetById(int id);
        public Camera Add(Camera newCamera);
        public Camera Delete(int id);
    }
}
