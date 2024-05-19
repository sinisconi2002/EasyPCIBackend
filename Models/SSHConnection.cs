namespace EasyPCIBackend.Models
{
    public class SSHConnection
    {
        public Guid Id { get; set; }
        public required string serverAddress { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }
    }
}
