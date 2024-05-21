using EasyPCIBackend.Data;
using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Interfaces.Repositories;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Repositories
{
    public class TestRepository : RepositoryBase<Test>, ITestRepository
    {
        public TestRepository(ApplicationDbContext ApplicationDbContext): base(ApplicationDbContext) { }

        public void CreateTest(Test Test) => Create(Test);

        public Test GetTest(Guid TestId) => FindByCondition(x => x.Id == TestId, false).First();

        public IEnumerable<Test> GetTests(bool trackChanges) => FindAll(trackChanges).ToList();

        public IEnumerable<Test> GetTestsByString(string search, bool trackChanges) => FindByCondition(x => x.Name == search, trackChanges).ToList();
    }
}
