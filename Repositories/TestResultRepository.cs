using EasyPCIBackend.Data;
using EasyPCIBackend.Interfaces.Repositories;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Repositories
{
    public class TestResultRepository : RepositoryBase<TestResult>, ITestResultRepository
    {
        public TestResultRepository(ApplicationDbContext ApplicationDbContext) : base(ApplicationDbContext) { }
        public void CreateTestResult(TestResult TestResult) => Create(TestResult);
        public TestResult GetTestResult(Guid TestResultId) =>FindByCondition(x => x.Id == TestResultId, false).First();

        public IEnumerable<TestResult> GetTestResults(bool trackChanges) => FindAll(trackChanges).ToList();

        public IEnumerable<TestResult> GetTestResultsByString(string search, bool trackChanges) => FindByCondition(x => x.Name.Contains(search), trackChanges).ToList();
    }
}
