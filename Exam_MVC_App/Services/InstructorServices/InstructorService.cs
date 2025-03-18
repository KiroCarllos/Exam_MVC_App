using Exam_MVC_App.Data;
using Exam_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Services.InstructorServices
{
    public class InstructorService(AppDBContext _db, IAppDBContextProcedures _sp) : IInstructorService
    {
        public Task<int> DeleteInstructorAsync(int Id)
        {
            return _sp.sp_DeleteUserAsync(Id);
        }

        public List<User> getAllInstructors()
        {
            return _db.Users.Where(u => u.Role == "Instructor").Include(u => u.Branch).ToList();
        }

        public User? GetInstructorById(int Id)
        {
            return _db.Users.Where(u => u.Id == Id).FirstOrDefault();
        }

        public Task<int> UpdateInstructorAsync(int Id, User UserRequest)
        {
            return _sp.sp_EditUserAsync(
                Id,
                UserRequest.Fname,
                UserRequest.Lname,
                UserRequest.Role,
                UserRequest.Phone,
                UserRequest.Email,
                UserRequest.Password,
                UserRequest.Gender,
                UserRequest.DateOfBirth,
                UserRequest.Status,
                UserRequest.Salary,
                UserRequest.Branch_Id
            );
        }
        public Task<int> AddInstructorAsync(User newInstructor)
        {
            return _sp.sp_AddUserRowAsync(
               newInstructor.Fname,
               newInstructor.Lname,
               newInstructor.Role,
               newInstructor.Phone,
               newInstructor.Email,
               newInstructor.Password,
               newInstructor.Gender,
               newInstructor.DateOfBirth,
               newInstructor.Status,
               newInstructor.Salary,
               newInstructor.Branch_Id
            );
        }
    }
}
