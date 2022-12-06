using CameraClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace SecurityCameraWebAPI.Managers
{
    public class CameraContext : DbContext
    {
        public CameraContext(DbContextOptions<CameraContext> options): base(options) { 

        }

        public DbSet<Camera> Cameras { get; set; }
    }
}
