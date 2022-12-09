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

        

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[HttpGet]
        //public ActionResult GetImage()
        //{
        //    List<Camera> cameraList = _manager.GetAll();

        //    return File(cameraList[0].Picture, "image/jpeg");
        //}


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Camera>> Get()
        {
            IEnumerable<Camera> cameras = _manager.GetAll();
            if (cameras == null || cameras.Count() == 0) return NoContent();
            return Ok(cameras);
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
