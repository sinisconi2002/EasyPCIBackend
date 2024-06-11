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
            CreateMap<TestCase, TestCaseDto>();
            CreateMap<Card, CardDto>();
        }
    }
}
