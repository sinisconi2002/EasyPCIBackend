using EasyPCIBackend.Data;
using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Interfaces.Repositories;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Repositories
{
    public class TestCaseRepository : RepositoryBase<TestCase>, ITestCaseRepository
    {
        public TestCaseRepository(ApplicationDbContext ApplicationDbContext) : base(ApplicationDbContext) {}

        public void CreateTestCase(TestCase TestCase) => Create(TestCase);

        public TestCase GetTestCase(Guid TestCaseId) => FindByCondition(x => x.Id == TestCaseId, false).First();

        public IEnumerable<TestCase> GetTestCases(bool trackChanges) => FindAll(trackChanges).ToList();

        public IEnumerable<TestCase> GetTestCasesByString(string search, bool trackChanges) => FindByCondition(x => x.Name == search, trackChanges).ToList();
    }
}
