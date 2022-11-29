using CameraClassLibrary;

namespace SecurityCameraWebAPI.Managers
{
    public class CameraManager
    {
        private static int _nextId = 1;
        private static readonly List<Camera> Data = new List<Camera>
        {
            new Camera {Id = _nextId++, Date=01001, Picture=},
            new Camera {Id=_nextId++,PictureId= 2}

        };

        public List<Camera> GetAll()
        {
            return new List<Camera>(Data);

            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        public Camera GetById(int id)
        {
            return Data.Find(flower => flower.Id == id);
        }

        public Flower Add(Flower newFlower)
        {
            newFlower.Id = _nextId++;
            Data.Add(newFlower);
            return newFlower;
        }

        public Flower Delete(int id)
        {
            Flower flower = Data.Find(flower1 => flower1.Id == id);
            if (flower == null) return null;
            Data.Remove(flower);
            return flower;
        }

        public Flower Update(int id, Flower updates)
        {
            Flower flower = Data.Find(flower1 => flower1.Id == id);
            if (flower == null) return null;
            flower.Height = updates.Height;
            flower.Species = updates.Species;
            flower.Color = updates.Color;
            return flower;
        }
    }
}
