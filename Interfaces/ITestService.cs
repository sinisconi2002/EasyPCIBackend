using EasyPCIBackend.Models;
using EasyPCIBackend.Models.Dtos;

namespace EasyPCIBackend.Interfaces
{
    public interface ITestService
    {
        Task<TestCreatorDto> GetTestCreator();
        Task<List<TestResult>> GetTestResults();
        Task<TestResultDto> GetTestResult(Guid testId);
        List<TestResult> GetTestsBySearch(string search);
        Task AddTestResult(TestResult testResult);
        Task<TestResult> RunTest(Test test);
    }
}
