using AutoMapper;
using Exam_MVC_App.Data;
using Exam_MVC_App.Dtos.BranchDtos;
using Exam_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Services.BranchServices
{
    public class BranchService(AppDBContext _db, IAppDBContextProcedures _sp,IMapper _mapper) : IBranchService
    {
        public Task<int> DeleteBranchAsync(byte Id)
        {
            return _sp.sp_deletebranchAsync(Id);
        }

        public BranchDto? GetBranchById(byte Id)
        {
            return _mapper.Map<BranchDto>(_db.Branches.Where(b => b.Id == Id).Include(b => b.Manager).FirstOrDefault());
        }

        public List<BranchDto> GetBranches()
        {
            return _mapper.Map<List<BranchDto>>(_db.Branches.Include(b => b.Manager).ToList());
        }
        public BranchEditDto GetEditBranche(byte Id)
        {
            return _mapper.Map<BranchEditDto>(_db.Branches.Where(b => b.Id == Id).FirstOrDefault());
        }

        public async Task<int> UpdateBranchAsync(byte Id, BranchEditDto branchRequest)
        {
            return await _sp.sp_updatebranchAsync(Id, branchRequest.BranchName, branchRequest.ManagetId);
        }
    }
}
