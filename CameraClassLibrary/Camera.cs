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

        public string? FileType { get;set; }

        public void ValidateName()
        {
            if(Name == null) throw new ArgumentNullException(nameof(Name));
            if (Name.Length < 2) throw new ArgumentException(nameof(Name));
        }

        public void ValidatePicture()
        {
            if (Picture == null) throw new ArgumentNullException(nameof(Name));
        }

        public void ValidateFileType()
        {
            if (FileType == null) throw new ArgumentNullException(nameof(Name));
        }
        public override string ToString()
        {
            return "Id: " + Id + " - PictureId: " + PictureId + " - Name: " + Name + " - Date: " + Date + " - Picture: " +
                Picture +  " - FileType: " + FileType;
        }
    }
}
