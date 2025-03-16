using Exam_MVC_App.Data;
using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.InstructorServices
{
    public class InstructorServices(AppDBContext _db) : IInstructorServices
    {
        public List<User> getAllInstructors()   
        {
           return _db.Users.Where(u => u.Role == "Instructor").ToList();
        }
    }
}
