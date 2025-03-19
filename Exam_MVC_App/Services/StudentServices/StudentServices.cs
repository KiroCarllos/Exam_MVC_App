using Exam_MVC_App.Data;
using Exam_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Services.InstructorServices
{
    public class StudentServices(AppDBContext _db , IAppDBContextProcedures _sp) : IStudentServices
    {
        public Task<int> DeleteStudentAsync(int Id)
        {
            return _sp.sp_DeleteUserAsync(Id);
        }

        public List<User> GetAllStudents()   
        {
           return _db.Users.Where(u => u.Role == "Student").Include(u => u.Branch).ToList();
        }

        public User? GetStudentById(int Id)
        {
            return _db.Users.Where(u => u.Id == Id).FirstOrDefault();
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User?> GetStudentDetailsAsync(int? id)
        {
            return await _db.Users
                .Include(u => u.Student_Detials)
                .ThenInclude(ut => ut.Track)
                .Include(u => u.Stundent_Courses)  
                .ThenInclude(uc => uc.Course)  
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public Task<int> UpdateStudentAsync(int Id, User UserRequest)
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
        public Task<int> AddStudentAsync(User newInstructor)
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
        public Task<int> InsertStudentDetailsAsync(Student_Detial student_Detial)
        {

            return _sp.sp_AddStudent_DetailsAsync(
                student_Detial.User_Id,
                student_Detial.Track_Id
                );
        }
    }
}
