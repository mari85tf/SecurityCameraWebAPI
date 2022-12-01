using CameraClassLibrary;

namespace SecurityCameraWebAPI.Interfaces
{
    public interface ICameraManager
    {
        public List<Camera> GetAll();
    }
}
