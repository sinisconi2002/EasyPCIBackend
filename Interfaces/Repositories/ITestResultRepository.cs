using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces.Repositories
{
    public interface ITestResultRepository
    {
        TestResult GetTestResult(Guid TestResultId);
        IEnumerable<TestResult> GetTestResults(bool trackChanges);
        IEnumerable<TestResult> GetTestResultsByString(string search, bool trackChanges);
        void CreateTestResult(TestResult TestResult);
    }
}
