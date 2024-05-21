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
        private ISSHConnectionRepository _sshConnectionRepository;
        private ITestCaseRepository _testCaseRepository;
        private ITestRepository _testRepository;
        private ITestResultRepository _testResultRepository;

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

        public ISSHConnectionRepository SSHConnections
        {
            get
            {
                if ( _sshConnectionRepository == null)
                    _sshConnectionRepository = new SSHConnnectionRepository(_applicationContext);
                return _sshConnectionRepository;
            }
        }

        public ITestCaseRepository TestCases
        {
            get
            {
                if (_testCaseRepository == null)
                    _testCaseRepository = new TestCaseRepository(_applicationContext);
                return _testCaseRepository;
            }
        }

        public ITestRepository Tests
        {
            get
            {
                if (_testRepository == null)
                    _testRepository = new TestRepository(_applicationContext);
                return _testRepository;
            }
        }

        public ITestResultRepository TestResults
        {
            get
            {
                if (_testResultRepository == null)
                    _testResultRepository = new TestResultRepository(_applicationContext);
                return _testResultRepository;
            }
        }
        public Task Save() => _applicationContext.SaveChangesAsync();
    }
}
