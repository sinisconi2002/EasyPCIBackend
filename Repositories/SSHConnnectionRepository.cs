using EasyPCIBackend.Data;
using EasyPCIBackend.Interfaces.Repositories;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Repositories
{
    public class SSHConnnectionRepository : RepositoryBase<SSHConnection>, ISSHConnectionRepository
    {
        public SSHConnnectionRepository(ApplicationDbContext ApplicationDbContext) : base(ApplicationDbContext) {}
        public SSHConnection GetSSHConnection(Guid connectionId) => FindByCondition(x => x.Id == connectionId, false).First();

        public IEnumerable<SSHConnection> GetSSHConnections(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SSHConnection> GetSSHConnectionsByString(string search, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void CreateSSHConnection(SSHConnection SSHConnection)
        {
            throw new NotImplementedException();
        }
    }
}
