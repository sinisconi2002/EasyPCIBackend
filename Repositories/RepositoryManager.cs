using EasyPCIBackend.Data;
using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Interfaces.Repositories;

namespace EasyPCIBackend.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationDbContext _applicationContext;
        private IUserRepository _userRepository;
        private ICardRepository _cardRepository;

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

        public ICardRepository Cards
        {
            get
            {
                if ( _cardRepository == null)
                    _cardRepository = new CardRepository(_applicationContext);
                return _cardRepository;
            }
        }

        public Task Save() => _applicationContext.SaveChangesAsync();
    }
}
