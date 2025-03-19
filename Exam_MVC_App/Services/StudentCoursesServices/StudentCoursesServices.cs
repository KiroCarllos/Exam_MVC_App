using Exam_MVC_App.Data;
using Exam_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Services.StudentCoursesServices
{
    public class StudentCoursesServices(AppDBContext _db, IAppDBContextProcedures _sp) : IStudentCoursesServices
    {
        public Task<int> DeleteStudentCoursesAsync(int Id)
        {
            return _sp.sp_deletestudent_coursesAsync(Id);
        }

        public List<Stundent_Course> GetAllStudentCourses()
        {
            return _db.Stundent_Courses.ToList();
        }

        public List<Stundent_Course> GetStudentCoursesById(int Id)
        {
            return _db.Stundent_Courses
                .Include(s => s.Course)
                .Where(s => s.User_Id == Id)
                .ToList();
        }

        public Task<int> AddStudentCoursesAsync(Stundent_Course newStudentCourse)
        {
            return _sp.sp_createstudent_coursesAsync(newStudentCourse.Course_Id, newStudentCourse.User_Id);
        }
    }
}
