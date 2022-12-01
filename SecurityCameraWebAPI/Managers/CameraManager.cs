using CameraClassLibrary;
using SecurityCameraWebAPI.Interfaces;
using System.Drawing;


namespace SecurityCameraWebAPI.Managers
{
    public class CameraManager : ICameraManager
    {
        private static int _nextId = 1;
        private static readonly List<Camera> Data = new List<Camera>
        {
            new Camera {Id = 1, PictureId= _nextId++, Date=DateTime.Now, Picture= File.ReadAllBytes("C:\\Users\\Acer\\Desktop\\SecurityCameraWebAPI-master\\SecurityCameraWebAPI\\Managers\\ParkerMo.jpeg"), FileType = "jpeg", MyImage = null},
            new Camera {Id = 1, PictureId= _nextId++, Date=DateTime.Today, Picture= null, FileType=null},
        };

        public Image GetFingerPrint()
        {
            //try
            //{
                using (var ms = new MemoryStream(Data[0].Picture))
                {
                    return Image.FromStream(ms);
                }
            //}
            //catch (Exception) { return null; }
            //return null;
        }
        public List<Camera> GetAll()
        {
            Data[0].MyImage = GetFingerPrint();
               return new List<Camera>(Data);

            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        public Camera GetById(int id)
        {
            return Data.Find(Camera => Camera.Id == id);
        }

        public Camera Add(Camera newCamera)
        {
            newCamera.Id = _nextId++;
            Data.Add(newCamera);
            return newCamera;
        }

        public Camera Delete(int id)
        {
            Camera Camera = Data.Find(Camera1 => Camera1.Id == id);
            if (Camera == null) return null;
            Data.Remove(Camera);
            return Camera;
        }

        //public Camera Update(int id, Camera updates)
        //{
        //    //Camera Camera = Data.Find(Camera1 => Camera1.Id == id);
        //    //if (Camera == null) return null;
        //    //Camera.Height = updates.Height;
        //    //Camera.Species = updates.Species;
        //    //Camera.Color = updates.Color;
        //    //return Camera;
        //}
    }
}
