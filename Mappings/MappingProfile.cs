using AutoMapper;
using EasyPCIBackend.Models;
using EasyPCIBackend.Models.Dtos;

namespace EasyPCIBackend.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<SSHConnection, SSHConnectionDto>();
            CreateMap<TestCase, TestCaseDto>().ForMember(dest => dest.Card, opt => opt.Ignore());
            CreateMap<Card, CardDto>();
            CreateMap<Test, TestResult>();
        }
    }
}
