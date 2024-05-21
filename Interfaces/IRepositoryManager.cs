using EasyPCIBackend.Interfaces.Repositories;
using EasyPCIBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyPCIBackend.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        ICardRepository Cards { get; }

        ISSHConnectionRepository SSHConnections { get; }
        ITestCaseRepository TestCases { get; }
        ITestRepository Tests { get; }
        ITestResultRepository TestResults { get; }
 
        Task Save();
    }
}
