namespace EasyPCIBackend.Models.Dtos
{
    public class Test
    {
        public string Name { get; set; }
        public Guid TestCase { get; set; }
        public Guid Remote { get; set; }
        public string Tester { get; set; }
    }
}
