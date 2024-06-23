using AutoMapper;
using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using EasyPCIBackend.Models.Dtos;

namespace EasyPCIBackend.Services
{
    public class TestcaseService : ITestcaseService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public TestcaseService(IMapper mapper, IRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task AddTestcase(TestCase testcase)
        {
            testcase.Id = Guid.NewGuid();
            _repository.TestCases.CreateTestCase(testcase);
            await _repository.Save();
        }

        public TestCaseDto GetTestcase(Guid testcaseId)
        {
            var initialTestcase = _repository.TestCases.GetTestCase(testcaseId);
            var card = _repository.Cards.GetCard(initialTestcase.Card);
            var result = _mapper.Map<TestCaseDto>(initialTestcase);
            result.Card = _mapper.Map<CardDto>(card);

            return result;
        }

        public TestCaseCreatorDto GetTestcaseCreator()
        {
            var _cards = _repository.Cards.GetCards(false);
            TestCaseCreatorDto testCaseCreatorDto = new TestCaseCreatorDto();
            testCaseCreatorDto.cards = _mapper.Map<List<CardDto>>(_cards);

            return testCaseCreatorDto;
        }

        public async Task<List<TestCase>> GetTestcases()
        {
            return _repository.TestCases.GetTestCases(false).ToList();
        }

        public List<TestCase> GetTestcasesBySearch(string search)
        {
            return _repository.TestCases.GetTestCasesByString(search.ToLower(), false).ToList();
        }
    }
}
