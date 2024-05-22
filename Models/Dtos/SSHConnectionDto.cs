namespace EasyPCIBackend.Models.Dtos
{
    public class SSHConnectionDto
    {
        public Guid Id { get; set; }
        public required string ServerAddress { get; set; }
    }
}
