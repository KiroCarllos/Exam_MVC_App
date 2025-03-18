using Exam_MVC_App.Data;
using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.CourseServices
{
    public class CourseServices(AppDBContext _db, IAppDBContextProcedures _sp) : ICourseServices
    {
        public Task<int> createCourse(Course courceRequest)
        {
            return _sp.sp_createcourceAsync(courceRequest.Name, courceRequest.Hours);
        }
        public Task<int> DeleteCourseAsync(byte Id)
        {
            return _sp.sp_deletecourceAsync(Id);
        }
        public Course GetCourseById(byte Id)
        {
            return _db.Courses.FirstOrDefault(t => t.Id == Id);
        }
        public List<Course> GetCourse()
        {
            return _db.Courses.ToList();
        }
        public Task<int> UpdateCourcseAsync(byte Id, Course courceRequest)
        {
            return _sp.sp_updatecourseAsync(Id, courceRequest.Name, courceRequest.Hours);
        }
    }
}
