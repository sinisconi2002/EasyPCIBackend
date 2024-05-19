using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces.Repositories
{
    public interface ISSHConnectionRepository
    {
        SSHConnection GetSSHConnection(Guid SSHConnectionId);
        IEnumerable<SSHConnection> GetSSHConnections(bool trackChanges);
        IEnumerable<SSHConnection> GetSSHConnectionsByString(string search, bool trackChanges);
        void CreateSSHConnection(SSHConnection SSHConnection);
    }
}
