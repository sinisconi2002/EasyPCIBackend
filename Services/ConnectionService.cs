using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Interfaces.Repositories;
using EasyPCIBackend.Models;
using System.Reflection.Metadata.Ecma335;

namespace EasyPCIBackend.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly IRepositoryManager _repository;
        public ConnectionService(IRepositoryManager repository) {
            _repository = repository;
        }
        public async Task AddConnection(SSHConnection connection)
        {
            connection.Id = Guid.NewGuid();
            _repository.SSHConnections.CreateSSHConnection(connection);
            await _repository.Save();
        }

        public async Task<SSHConnection> GetConnection(Guid connectionId)
        {
            return _repository.SSHConnections.GetSSHConnection(connectionId);
        }

        public async Task<List<SSHConnection>> GetConnections()
        {
            return _repository.SSHConnections.GetSSHConnections(false).ToList();
        }

        List<SSHConnection> IConnectionService.GetConnectionsBySearch(string search)
        {
            return _repository.SSHConnections.GetSSHConnectionsByString(search, false).ToList();
        }
    }
}
