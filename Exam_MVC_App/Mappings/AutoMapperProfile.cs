using AutoMapper;
using Exam_MVC_App.Dtos.BranchDtos;
using Exam_MVC_App.Models;

namespace Exam_MVC_App.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Map<BranchDto>(src => Branch)
            CreateMap<Branch, BranchEditDto>()
                .ForMember(m=>m.BranchId , mf=> mf.MapFrom(src => src.Id))
                .ForMember(m=>m.BranchName , mf=> mf.MapFrom(src => src.Name))
                .ForMember(m=>m.ManagetId , mf=> mf.MapFrom(src => src.Mng_Id))
                .ReverseMap();
            CreateMap<Branch, BranchDto>()
                 .ForMember(m => m.BranchId, mf => mf.MapFrom(src => src.Id))
                .ForMember(m => m.BranchName, mf => mf.MapFrom(src => src.Name))
                .ForMember(m => m.Manager, mf => mf.MapFrom(src => src.Manager))
                .ForMember(m => m.BranchManager, mf => mf.MapFrom(src => src.Manager.Fname+" "+ src.Manager.Lname))
                .ReverseMap();    

        }
    }
}
