namespace EasyPCIBackend.Models.Dtos
{
    public class TestResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TestCaseDto TestCase { get; set; }
        public RemoteDto Remote { get; set; }
        public string Result { get; set; }
        public string LinkToCore { get; set; }
    }
}
