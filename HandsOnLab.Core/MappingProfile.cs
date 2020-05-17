using AutoMapper;


namespace HandsOnLab.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dto.HourlyPayedEmployee, Domain.Employee>().ReverseMap();
            CreateMap<Dto.MonthlyPayedEmployee, Domain.Employee>().ReverseMap();

        }
    }
}
