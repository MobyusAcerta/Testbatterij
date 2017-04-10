using AutoMapper;
using Testbatterij.Dtos;
using Testbatterij.Models;

namespace Testbatterij.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<TestScenario, TestScenarioDto>();
            Mapper.CreateMap<TestScenarioDto, TestScenario>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<TestSet, TestSetDto>();
            Mapper.CreateMap<TestSetDto, TestSet>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}