using Exam_MVC_App.Data;
using Exam_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Services.BranchServices
{
    public class BranchService(AppDBContext _db, IAppDBContextProcedures _sp) : IBranchService
    {
        public Task<int> DeleteBranchAsync(byte Id)
        {
            return _sp.sp_deletebranchAsync(Id);
        }

        public Branch? GetBranchById(byte Id)
        {
            return _db.Branches.Where(b => b.Id == Id).FirstOrDefault();
        }

        public List<Branch> GetBranches()
        {
            return _db.Branches.Include(b=> b.Manager).ToList();
        }

        public async Task<int> UpdateBranchAsync(byte Id, Branch branchRequest)
        {
            return await _sp.sp_updatebranchAsync(Id, branchRequest.Name, branchRequest.Mng_Id);
        }
    }
}
