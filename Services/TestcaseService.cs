using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Services
{
    public class TestcaseService : ITestcaseService
    {
        private readonly IRepositoryManager _repository;
        public TestcaseService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task AddTestcase(TestCase testcase)
        {
            testcase.Id = Guid.NewGuid();
            _repository.TestCases.CreateTestCase(testcase);
            await _repository.Save();
        }

        public async Task<TestCase> GetTestcase(Guid testcaseId)
        {
            return _repository.TestCases.GetTestCase(testcaseId);
        }

        public async Task<List<TestCase>> GetTestcases()
        {
            return _repository.TestCases.GetTestCases(false).ToList();
        }

        public List<TestCase> GetTestcasesBySearch(string search)
        {
            return _repository.TestCases.GetTestCasesByString(search, false).ToList();
        }
    }
}
