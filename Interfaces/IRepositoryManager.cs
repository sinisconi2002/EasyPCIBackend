using EasyPCIBackend.Interfaces.Repositories;

namespace EasyPCIBackend.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        Task Save();
    }
}
