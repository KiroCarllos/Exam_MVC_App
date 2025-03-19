using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.StudentCoursesServices
{
    public interface IStudentCoursesServices
    {
        public Task<int> DeleteStudentCoursesAsync(int Id);
        public List<Stundent_Course> GetAllStudentCourses();
        public List<Stundent_Course> GetStudentCoursesById(int Id);
        public Task<int> AddStudentCoursesAsync(Stundent_Course newStudentCourse);
    }
}
