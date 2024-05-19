using EasyPCIBackend.Data;
using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Interfaces.Repositories;

namespace EasyPCIBackend.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationDbContext _applicationContext;
        private IUserRepository _userRepository;

        public RepositoryManager(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_applicationContext);
                return _userRepository;
            }
        }

        public Task Save() => _applicationContext.SaveChangesAsync();
    }
}
