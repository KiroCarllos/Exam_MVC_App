using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.InstructorServices
{
    public interface IInstructorService
    {
        List<User> getAllInstructors();
        User? GetInstructorById(int Id);
        Task<int> UpdateInstructorAsync(int Id, User UserRequest);
        Task<int> DeleteInstructorAsync(int Id);
        Task<int> AddInstructorAsync(User newInstructor);
    }
}
