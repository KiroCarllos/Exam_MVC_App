using Exam_MVC_App.Models;
using Exam_MVC_App.Services.BranchServices;
using Exam_MVC_App.Services.CourseServices;
using Exam_MVC_App.Services.InstructorServices;
using Exam_MVC_App.Services.StudentCoursesServices;
using Exam_MVC_App.Services.TrackServices;
using Microsoft.AspNetCore.Mvc;

namespace Exam_MVC_App.Controllers
{
    public class StudentController(IStudentServices _studentServices,IStudentCoursesServices _studentCoursesServices , IBranchService _branchServices , ITrackServices _trackServices , ICourseServices _courseServices) : Controller
    {
        public IActionResult Index()
        {
            return View(_studentServices.GetAllStudents());
        }

        [HttpGet]
        public IActionResult Edit(byte Id)
        {
            var student = _studentServices.GetStudentById(Id);
            ViewBag.Branches = _branchServices.GetBranches();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Update(byte Id, User userRequest)
        {
            try
            {
                var result = await _studentServices.UpdateStudentAsync(Id, userRequest);
                TempData["Message"] = result == 1 ? "Student Updated Successfully" : "Student Not Updated";
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
                var result = await _studentServices.DeleteStudentAsync(Id);
                TempData["Message"] = result == 1 ? "Student Deleted Successfully" : "Student Not Deleted";
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
            ViewBag.Tracks = _trackServices.GetTracks();
            ViewBag.Courses = _courseServices.GetCourse();
            return View();
        }
        public async Task<IActionResult> Insert(User newUser, Student_Detial student_Detial, List<Stundent_Course> Courses)
        {
            try
            {
                var result = await _studentServices.AddStudentAsync(newUser);
                if (result != 1)
                {
                    TempData["Message"] = "Failed to insert student into User table.";
                    return RedirectToAction("Index");
                }

                var insertedUser = await _studentServices.GetUserByEmail(newUser.Email);
                if (insertedUser == null)
                {
                    TempData["Message"] = "Error retrieving new student ID.";
                    return RedirectToAction("Index");
                }

                student_Detial.User_Id = insertedUser.Id;
                await _studentServices.InsertStudentDetailsAsync(student_Detial);

                if (Courses != null && Courses.Any())
                {
                    foreach (var course in Courses)
                    {
                        course.User_Id = insertedUser.Id;
                        await _studentCoursesServices.AddStudentCoursesAsync(course);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var student = await _studentServices.GetStudentDetailsAsync(id);
                return View(student);
            }
            catch(Exception ex) 
            {
                TempData["Message"] = ex.Message;
                return NotFound();
            }
            
        }
    }
}
