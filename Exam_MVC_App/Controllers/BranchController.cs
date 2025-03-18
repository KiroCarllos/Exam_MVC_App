using Exam_MVC_App.Data;
using Exam_MVC_App.Models;
using Exam_MVC_App.Services.BranchServices;
using Exam_MVC_App.Services.InstructorServices;
using Microsoft.AspNetCore.Mvc;

namespace Exam_MVC_App.Controllers
{
    public class BranchController(IBranchService _branchServices,IInstructorService _instructorService) : Controller
    {
        public IActionResult Index()
        {
            return View(_branchServices.GetBranches());
        }
        [HttpGet]
        public IActionResult Edit(byte Id)
        {
            ViewBag.Managers = _instructorService.getAllInstructors();
            return View(_branchServices.GetBranchById(Id));
        }
        [HttpPost]
        [Route("Branch/Update/{Id}")]
        public async Task<IActionResult> Update(byte Id,Branch branchRequest)
        {
            var result = await _branchServices.UpdateBranchAsync(Id, branchRequest);
            TempData["Message"] = result == 1 ? "Branch Updated Successfully" : "Branch Not Updated";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(byte Id)
        {
            var result =await _branchServices.DeleteBranchAsync(Id);
            TempData["Message"] = result == 1 ? "Branch Deleted Successfully" : "Branch Not Deleted";
            return RedirectToAction("Index");
        }
    }
}
