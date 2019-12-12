using AcmeEntities.ViewModels;
using AutoMapper;

namespace AcmeAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Employee, EmployeeDetails>()
                .ForMember(e => e.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(e => e.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(e => e.LastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ForMember(e => e.BirthDate, opt => opt.MapFrom(src => src.Person.BirthDate))
                .ForMember(e => e.EmployeeNum, opt => opt.MapFrom(src => src.EmployeeNum))
                .ForMember(e => e.EmployeedDate, opt => opt.MapFrom(src => src.EmployeedDate))
                //.ForMember(e => e.Terminated, opt => opt.MapFrom(src => src.Terminated))
                .ReverseMap();
        }
    }
}
