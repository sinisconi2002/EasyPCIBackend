namespace EasyPCIBackend.Models.Dtos
{
    public class TestCreatorDto
    {   
        public List<TestCaseDto> Testcases { get; set; }
        public List<SSHConnectionDto> Connections { get; set; }
    }
}
