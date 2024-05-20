using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces.Repositories
{
    public interface ITestRepository
    {
        Test GetTest(Guid TestId);
        IEnumerable<Test> GetTests(bool trackChanges);
        IEnumerable<Test> GetTestsByString(string search, bool trackChanges);
        void CreateTest(Test Test);
    }
}
