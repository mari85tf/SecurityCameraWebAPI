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
        private readonly CameraManager _manager;

        public CameraController(/*CameraManager context*/)
        {
            _manager = new CameraManager();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult GetImage()
        {
            List<Camera> cameraList = _manager.GetAll();

            return File(cameraList[0].Picture, "image/jpeg");
        }


        // GET: CameraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CameraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CameraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CameraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CameraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CameraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CameraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
