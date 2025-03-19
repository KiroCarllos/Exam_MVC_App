using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.InstructorDetailsServices
{
    public interface IInstructorDetailsService
    {
        Task<int> DeleteInstructorDetailAsync(int Id);
        List<Instructor_Detials> GetAllInstructorDetails();
        Task<int> AddInstructorDetailAsync(Instructor_Detials newInstructorDetail);
        Instructor_Detials GetInstructorDetailsById(int Id);
        //Task<int> AddInstructorDetailAsync(User newUser);
    }
}
