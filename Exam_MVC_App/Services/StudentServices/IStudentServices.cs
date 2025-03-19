using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.InstructorServices
{
    public interface IStudentServices
    {
        List<User> GetAllStudents();
        User? GetStudentById(int Id);
        public Task<User?> GetUserByEmail(string email);
        Task<User?> GetStudentDetailsAsync(int? id);
        Task<int> UpdateStudentAsync(int Id, User UserRequest);
        Task<int> DeleteStudentAsync(int Id);
        Task<int> AddStudentAsync(User newInstructor);
        public Task<int> InsertStudentDetailsAsync(Student_Detial student_Detial);
    }
}
