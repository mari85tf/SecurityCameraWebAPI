using CameraClassLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityCameraWebAPI.Managers;
using System.Drawing;

namespace SecurityCameraWebAPI.Controllers
{
    [Route("Camera")]
    //[EnableCors("AllowAll")]
    [ApiController] 
    public class CameraController : Controller
    {
        private readonly CameraManager _manager = new CameraManager();

        

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult GetImage()
        {
            List<Camera> cameraList = _manager.GetAll();

            return File(cameraList[0].Picture, "image/jpeg");
        }


        [HttpGet]
        public IEnumerable<Camera> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<CameraController>/5
        [HttpGet("{id}")]
        public Camera Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<CameraController>
        [HttpPost]
        public Camera Post([FromBody] Camera value)
        {
            return _manager.Add(value);
        }

      

        // DELETE api/<CameraController>/5
        [HttpDelete("{id}")]
        public Camera Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
