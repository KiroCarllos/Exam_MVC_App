using Exam_MVC_App.Models;

namespace Exam_MVC_App.Services.BranchServices
{
    public interface IBranchService
    {
        List<Branch> GetBranches();
        Branch? GetBranchById(byte Id);
        Task<int> UpdateBranchAsync(byte Id, Branch branchRequest);
        Task<int> DeleteBranchAsync(byte Id);
    }
}
