using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Services
{
    public class SSHConnector : ISSHConnector
    {
        public string GetCore(SSHConnection connection)
        {
            throw new NotImplementedException();
        }

        public string UploadCore(SSHConnection connectiion, string coreName)
        {
            throw new NotImplementedException();
        }
    }
}
