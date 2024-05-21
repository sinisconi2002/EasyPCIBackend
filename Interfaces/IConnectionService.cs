using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces.Repositories
{
    public interface IConnectionService
    {
        Task<List<SSHConnection>> GetConnections();
        Task<SSHConnection> GetConnection(Guid connectionId);
        List<SSHConnection> GetConnectionsBySearch(string search);
        Task AddConnection(SSHConnection connection);
    }
}
