using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Services
{
    public class TestcaseService : ITestcaseService
    {
        public Task AddTestcase(TestCase testcase)
        {
            throw new NotImplementedException();
        }

        public Task<TestCase> GetTestcase(Guid testcaseId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TestCase>> GetTestcases()
        {
            throw new NotImplementedException();
        }

        public List<TestCase> GetTestcasesBySearch(string search)
        {
            throw new NotImplementedException();
        }
    }
}
