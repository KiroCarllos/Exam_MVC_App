using Exam_MVC_App.Models;
using Exam_MVC_App.Services.BranchServices;
using Exam_MVC_App.Services.CourseServices;
using Exam_MVC_App.Services.InstructorServices;
using Exam_MVC_App.Services.StudentCoursesServices;
using Microsoft.AspNetCore.Mvc;

namespace Exam_MVC_App.Controllers
{
    public class StudentCoursesController(IStudentCoursesServices _studentCoursesServices, ICourseServices _courseServices) : Controller
    {
        public IActionResult Index(int id)
        {
            var studentCourses = _studentCoursesServices.GetStudentCoursesById(id);
            ViewBag.Courses = _courseServices.GetCourse();
            ViewBag.StudentId = id;
            return View(studentCourses);
        }
        public async Task<IActionResult> Create(Stundent_Course newCourse)
        {
            try
            {
                var result = await _studentCoursesServices.AddStudentCoursesAsync(newCourse);
                TempData["Message"] = result == 1 ? "Student Added Successfully" : "Student Not Added";
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }

            return RedirectToAction("Index", new { id = newCourse.User_Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, int studentId)
        {
            try
            {
                var result = await _studentCoursesServices.DeleteStudentCoursesAsync(id);
                TempData["Message"] = result == 1 ? "Student Deleted Successfully" : "Student Not Deleted";
            }
            catch
            {
                TempData["Message"] = "Delete All Related Tables First";
            }

            return RedirectToAction("Index", new { id = studentId });
        }
    }
}
