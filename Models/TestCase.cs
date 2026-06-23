namespace EasyPCIBackend.Models
{
    public class TestCase
    {
        public enum DetectionEngine
        {
            Classic = 0,
            Modern = 1
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }
        public Guid Card { get; set; }
        public string Process {  get; set; }
        public DetectionEngine Engine { get; set; } = DetectionEngine.Classic;
    }
}
