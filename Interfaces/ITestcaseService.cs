using EasyPCIBackend.Models;
using EasyPCIBackend.Models.Dtos;

namespace EasyPCIBackend.Interfaces
{
    public interface ITestcaseService
    {
        Task<List<TestCase>> GetTestcases();
        TestCaseDto GetTestcase(Guid testcaseId);
        List<TestCase> GetTestcasesBySearch(string search);
        TestCaseCreatorDto GetTestcaseCreator();
        Task AddTestcase(TestCase testcase);
    }
}
