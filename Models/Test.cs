namespace EasyPCIBackend.Models
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TestCase {  get; set; }
        public Guid Remote {  get; set; }
        public Guid Tester { get; set; }
    }
}
