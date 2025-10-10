using AutoMapper;
using BusinessLogicLayer.DTO.EmployeeDtos;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.employeeType));
            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.employeeType))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.Image, options => options.MapFrom(src => src.ImageName));
            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            //CreateMap<EmployeeDetailsDto, Employee>();
            //CreateMap<Employee, EmployeeDetailsDto>().ReverseMap();//for two sides

        }
    }
}
