using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.CourseServices
{
    public interface ICourseServices
    {
        Task<int> createCourse(Course courceRequest);
        List<Course> GetCourse();
        Course? GetCourseById(byte Id);
        Task<int> UpdateCourcseAsync(byte Id, Course courceRequest);
        Task<int> DeleteCourseAsync(byte Id);
    }
}
