using AutoMapper;
using Day02.DTOs;
using Day02.Models;

namespace Day02.Mapping
{
    public class AutoMappingStdDept:Profile
    {
        public AutoMappingStdDept()
        {
            CreateMap<Student ,StudentDTO>()
                .ForMember(dest => dest.DepartmentName , opt=>opt.MapFrom(src=>src.Dept.Dept_Name))
                .ForMember(dest => dest.SupervisorName, opt => opt.MapFrom(src => src.St_superNavigation.St_Fname + " " + src.St_superNavigation.St_Lname));
            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Dept_Name))
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.Students.Count));
        }
    }
}
