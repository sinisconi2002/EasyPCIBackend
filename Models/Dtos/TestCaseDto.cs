namespace EasyPCIBackend.Models.Dtos
{
    public class TestCaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CardDto Card { get; set; }
        public string Process { get; set; }
    }
}
