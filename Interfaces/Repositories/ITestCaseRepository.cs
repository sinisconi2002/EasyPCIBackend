using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces.Repositories
{
    public interface ITestCaseRepository
    {
        TestCase GetTestCase(Guid TestCaseId);
        IEnumerable<TestCase> GetTestCases(bool trackChanges);
        IEnumerable<TestCase> GetTestCasesByString(string search, bool trackChanges);
        void CreateTestCase(TestCase TestCase);
    }
}
