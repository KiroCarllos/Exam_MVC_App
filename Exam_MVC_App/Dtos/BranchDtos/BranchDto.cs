using Exam_MVC_App.Models;

namespace Exam_MVC_App.Dtos.BranchDtos
{
    public class BranchDto
    {
        public byte BranchId{ get; set; }
        public string BranchName{ get; set; }
        public string BranchManager{ get; set; }
        public virtual User  Manager { get; set; }  
    }
}
