namespace EasyPCIBackend.Models
{
    public class TestResult
    {   
        public Guid Id { get; set; }
        public Guid TestCase {  get; set; }
        public Guid Remote {  get; set; }
        public string Result { get; set; }
        public string LinkToCore { get; set; }
    }
}
