using Exam_MVC_App.Models;
using Exam_MVC_App.Services.InstructorServices;
using Exam_MVC_App.Services.TrackServices;
using Microsoft.AspNetCore.Mvc;

namespace Exam_MVC_App.Controllers
{
    public class TrackController(ITrackServices _trackservices , IInstructorService _instructorService) : Controller
    {
        public IActionResult Index()
        {
            return View(_trackservices.GetTracks());
        }
        [HttpGet]
        public IActionResult Edit(byte Id)
        {
            ViewBag.Managers = _instructorService.getAllInstructors();
            return View(_trackservices.GetTrackById(Id));
        }
        [HttpPost]
        [Route("Track/Update/{Id}")]
        public async Task<IActionResult> Update(byte Id, Track trackRequest)
        {
            var result = await _trackservices.UpdateTrackAsync(Id, trackRequest);
            TempData["Message"] = result == 1 ? "Branch Updated Successfully" : "Branch Not Updated";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(byte Id)
        {
            var result = await _trackservices.DeleteTrackAsync(Id);
            if (result == 1)
            {
                TempData["Message"] = "Track Deleted Successfully";
            }
            else if (result == -1)
            {
                TempData["Message"] = "Track Not Deleted";
            }
            else
            {
                TempData["Message"] = "Track is connect with other fk";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Managers = _instructorService.getAllInstructors();
            return View();
        }
        [HttpPost]
        [Route("Track/CreateNewTrack")]
        public async Task<IActionResult> CreateNewTrack(Track trackRequest)
        {

            var result = await _trackservices.createTrack(trackRequest);
            TempData["Message"] = result == 1 ? "Track created Successfully" : "cant create";
            return RedirectToAction("Index");
        }
    }
}
