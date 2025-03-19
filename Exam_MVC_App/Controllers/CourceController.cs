using Exam_MVC_App.Models;
using Exam_MVC_App.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;

namespace Exam_MVC_App.Controllers
{
    public class CourceController(ICourseServices _courceServices) : Controller
    {
        public IActionResult Index()
        {
            return View(_courceServices.GetCourse());
        }
        [HttpGet]
        public IActionResult Edit(byte Id)
        {
            return View(_courceServices.GetCourseById(Id));
        }
        [HttpPost]
        [Route("Cource/Update/{Id}")]
        public async Task<IActionResult> Update(byte Id, Course courceRequest)
        {
            var result = await _courceServices.UpdateCourcseAsync(Id, courceRequest);
            TempData["Message"] = result == 1 ? "cource Updated Successfully" : "cource Not Updated";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(byte Id)
        {
            var result = await _courceServices.DeleteCourseAsync(Id);
            if (result == 1)
            {
                TempData["Message"] = "cource Deleted Successfully";
            }
            else if (result == -1)
            {
                TempData["Message"] = "cource Not Deleted";
            }
            else
            {
                TempData["Message"] = "cource is connect with other fk";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Managers = _courceServices.GetCourse();
            return View();
        }
        [HttpPost]
        [Route("cource/CreateNewCource")]
        public async Task<IActionResult> CreateNewCource(Course courceRequest)
        {

            var result = await _courceServices.createCourse(courceRequest);
            TempData["Message"] = result == 1 ? "cource created Successfully" : "cant create";
            return RedirectToAction("Index");
        }
    }
}
