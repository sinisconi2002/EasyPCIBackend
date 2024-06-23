namespace EasyPCIBackend.Models
{
    public class TestCase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }
        public Guid Card { get; set; }
        public string Process {  get; set; }
    }
}
