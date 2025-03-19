using Exam_MVC_App.Models;
using Exam_MVC_App.Services.BranchServices;
using Exam_MVC_App.Services.InstructorServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam_MVC_App.Controllers
{
    public class InstructorController(IInstructorServices _instructorServices, IBranchService _branchServices) : Controller
    {
        public IActionResult Index()
        {
            return View(_instructorServices.getAllInstructors());
        }

        [HttpGet]
        public IActionResult Edit(byte Id)
        {
            var instructor = _instructorServices.GetInstructorById(Id);
            ViewBag.Branches = _branchServices.GetBranches();
            return View(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Update(byte Id,User userRequest)
        {
            try
            {
                var result = await _instructorServices.UpdateInstructorAsync(Id, userRequest);
                TempData["Message"] = result == 1 ? "Instructor Updated Successfully" : "Instructor Not Updated";
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
          
          return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(byte Id)
        {
            try
            {
                var result = await _instructorServices.DeleteInstructorAsync(Id);
                TempData["Message"] = result == 1 ? "Instructor Deleted Successfully" : "Instructor Not Deleted";
            }
            catch
            {
                TempData["Message"] = "Delete All Realted Tables First";
            }

            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            ViewBag.Branches = _branchServices.GetBranches();
            return View();
        }
        public async Task<IActionResult> Insert(User newUser)
        {
            try
            {
                var result = await _instructorServices.AddInstructorAsync(newUser);
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
