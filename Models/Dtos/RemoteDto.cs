namespace EasyPCIBackend.Models.Dtos
{
    public class RemoteDto
    {
        public Guid Id { get; set; }
        public required string ServerAddress { get; set; }
    }
}
