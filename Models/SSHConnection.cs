namespace EasyPCIBackend.Models
{
    public class SSHConnection
    {
        public Guid Id { get; set; }
        public required string ServerAddress { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
