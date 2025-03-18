using Microsoft.AspNetCore.Mvc;
using Exam_MVC_App.Services.InstructorDetailsServices;
using Exam_MVC_App.Models;
using System.Threading.Tasks;

namespace Exam_MVC_App.Controllers
{
    public class InstructorDetailsController : Controller
    {
        private readonly IInstructorDetailsService _instructorDetailsService;

        public InstructorDetailsController(IInstructorDetailsService instructorDetailsService)
        {
            _instructorDetailsService = instructorDetailsService;
        }

        // Display list of all instructor details
        public IActionResult Index()
        {
            var instructorDetails = _instructorDetailsService.GetAllInstructorDetails();
            return View(instructorDetails);
        }

        // Display details of a specific instructor
        public IActionResult Details(int id)
        {
            var instructorDetail = _instructorDetailsService.GetInstructorDetailsById(id);
            if (instructorDetail == null)
            {
                TempData["Message"] = "Instructor details not found!";
                return RedirectToAction("Index");
            }
            return View(instructorDetail);
        }

        // Delete instructor details
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _instructorDetailsService.DeleteInstructorDetailAsync(id);
                TempData["Message"] = result == 1 ? "Instructor Details Deleted Successfully" : "Instructor Details Not Deleted";
            }
            catch
            {
                TempData["Message"] = "Error deleting instructor details. Ensure related data is removed first.";
            }
            return RedirectToAction("Index");
        }

        // Show Add Instructor Details page
        public IActionResult Add()
        {
            ViewBag.Instructors = _instructorDetailsService.GetAllInstructorDetails(); // Ensure this returns a valid list
            return View();
        }

        // Insert new Instructor Details
        [HttpPost]
        public async Task<IActionResult> Insert(Instructor_Detials newInstructorDetail)
        {
            try
            {
                var result = await _instructorDetailsService.AddInstructorDetailAsync(newInstructorDetail);
                TempData["Message"] = result == 1 ? "Instructor Inserted Successfully" : "Instructor Not Inserted";
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}

