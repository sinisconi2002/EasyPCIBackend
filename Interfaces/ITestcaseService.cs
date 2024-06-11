using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces
{
    public interface ITestcaseService
    {
        Task<List<TestCase>> GetTestcases();
        Task<TestCase> GetTestcase(Guid testcaseId);
        List<TestCase> GetTestcasesBySearch(string search);
        Task AddTestcase(TestCase testcase);
    }
}
