using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces
{
    public interface ISSHConnector
    {
        public String GetCore(SSHConnection connection);
        public String UploadCore(SSHConnection connectiion, string coreName);
    }
}
