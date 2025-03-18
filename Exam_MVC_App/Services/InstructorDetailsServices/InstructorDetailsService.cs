using Exam_MVC_App.Data;
using Exam_MVC_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_MVC_App.Services.InstructorDetailsServices
{
    public class InstructorDetailsService : IInstructorDetailsService
    {
        private readonly AppDBContext _db;
        private readonly IAppDBContextProcedures _sp;

        public InstructorDetailsService(AppDBContext db, IAppDBContextProcedures sp)
        {
            _db = db;
            _sp = sp;
        }

        public async Task<int> DeleteInstructorDetailAsync(int Id)
        {
            return await _sp.sp_Delete_Instructor_DetailsAsync(Id);
        }

        public async Task<int> AddInstructorDetailAsync(Instructor_Detials newInstructorDetail)
        {
            return await _sp.sp_AddInstructor_DetailsAsync(
                newInstructorDetail.User_Id,
                newInstructorDetail.Track_Id,
                newInstructorDetail.Course_Id
            );
        }

        public List<Instructor_Detials> GetAllInstructorDetails()
        {
            return _db.Instructor_Detials
                .Include(i => i.Course)
                .Include(i => i.Track)
                .Include(i => i.User)
                .ToList();
        }

        public Instructor_Detials GetInstructorDetailsById(int Id)
        {
            return _db.Instructor_Detials
                .Include(i => i.User)
                .Include(i => i.Course)
                .Include(i => i.Track)
                .FirstOrDefault(i => i.Id == Id);
        }
    }
}

