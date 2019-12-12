using AutoMapper;

namespace AcmeAPI.Mapper 
{ 
    public class ListMapper: Profile
    {
        public ListMapper()
        {
            CreateMap<Employee, AcmeEntities.ViewModels.EmployeeList>()
                .ForMember(e => e.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(e => e.EmployeeNum, opt => opt.MapFrom(src => src.EmployeeNum))
                .ForMember(e => e.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(e => e.LastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ReverseMap();
        }
    }
}
