using Exam_MVC_App.Dtos.BranchDtos;
using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.BranchServices
{
    public interface IBranchService
    {
        List<BranchDto> GetBranches();
        BranchDto? GetBranchById(byte Id);
        BranchEditDto? GetEditBranche(byte Id);
        Task<int> UpdateBranchAsync(byte Id, BranchEditDto branchRequest);  
        Task<int> createBranch(Branch branchRequest);
        Task<int> DeleteBranchAsync(byte Id);
    }
}
