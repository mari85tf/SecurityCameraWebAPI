using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CameraClassLibrary
{
    public class Camera
    {
        public int Id { get; set; }

        public int PictureId { get; set; }

        public string? Name { get; set; }

        public DateTime Date { get; set; }

        public byte[]? Picture { get; set; }
        public Image? MyImage { get; set; }

        public string? FileType { get;set; }
    }
}
