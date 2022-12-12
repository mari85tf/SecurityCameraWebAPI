using CameraClassLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityCameraWebAPI.Managers;
using SecurityCameraWebAPI.Interfaces;
using SecurityCameraWebAPI.DBContext;
using System.Drawing;

namespace SecurityCameraWebAPI.Controllers
{
    [Route("CameraAPI")]
    [EnableCors("AllowAll")]
    [ApiController] 
    public class CameraController : Controller
    {
        private readonly ICameraManager _manager;

        public CameraController(CameraContext context)
        {
            _manager = new CameraManagerDB(context);
            //_manager = new CameraManager();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Camera>> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<CameraController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Camera> Get(int id)
        {
            Camera camera = _manager.GetById(id);
            if (camera == null) return NotFound("No such id, " + id);
            return Ok(camera);
        }

        [HttpGet("Images/{id}")]
        public ActionResult GetImage(int id)
        {
            Camera camera = _manager.GetById(id);
            byte[] image = camera.Picture;
            return File(image, "image/jpg");
        }

        // POST api/<CameraController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Camera> Post([FromBody] Camera value)
        {
            //Camera camera = _manager.Add(value);
            //if (camera == null) return BadRequest();
            //return Ok(camera);
            try
            {
                Camera newCamera = _manager.Add(value);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + newCamera.Id;
                return Created(uri, newCamera);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

      

        // DELETE api/<CameraController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Camera> Delete(int id)
        {
            Camera camera = _manager.Delete(id);
            if (camera == null) return NotFound("No such id, " + id);
            return Ok(camera);
        }
    }
}
