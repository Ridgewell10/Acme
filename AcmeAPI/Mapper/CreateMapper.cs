using AcmeEntities.ViewModels;
using AutoMapper;

namespace AcmeAPI.Mapper
{
    public class CreateMapper : Profile
    {
        public CreateMapper()
        {
            CreateMap<EmployeeCreate, Employee>()
                .ForPath(src => src.Person.FirstName, opt => opt.MapFrom(e => e.FirstName))
                .ForPath(src => src.Person.LastName, opt => opt.MapFrom(e => e.LastName))
                .ForPath(src => src.Person.BirthDate, opt => opt.MapFrom(e => e.BirthDate))
                .ForMember(src => src.EmployeeNum, opt => opt.MapFrom(e => e.EmployeeNum))
                .ForMember(src => src.EmployeedDate, opt => opt.MapFrom(e => e.EmployeedDate))
                .ForMember(src => src.Terminated, opt => opt.MapFrom(e => e.Terminated))
                .ReverseMap();
        }
    }
}
