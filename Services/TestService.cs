using AutoMapper;
using Azure;
using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using EasyPCIBackend.Models.Dtos;
using Newtonsoft.Json;
using RestSharp;

namespace EasyPCIBackend.Services
{
    public class TestService : ITestService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;
        private readonly ISSHConnector _connector;
        private readonly IConfiguration _configuration;
        public TestService(IMapper mapper, IRepositoryManager repository, ISSHConnector connector, IConfiguration configuration)
        {
            _mapper = mapper;
            _repository = repository;
            _connector = connector;
            _configuration = configuration;
        }

        public async Task AddTestResult(TestResult testResult)
        {
            _repository.TestResults.CreateTestResult(testResult);
            await _repository.Save();
        }

        public async Task<TestCreatorDto> GetTestCreator()
        {
            var _testCases = _repository.TestCases.GetTestCases(false);
            var _connections = _repository.SSHConnections.GetSSHConnections(false);
            TestCreatorDto testCreatorDto = new TestCreatorDto();
            testCreatorDto.Testcases = _mapper.Map<List<TestCaseDto>>(_testCases);
            testCreatorDto.Connections = _mapper.Map<List<SSHConnectionDto>>(_connections);
            return testCreatorDto;
        }

        public async Task<TestResultDto> GetTestResult(Guid testId)
        {
            TestResultDto result = new TestResultDto();
            var testResult = _repository.TestResults.GetTestResult(testId); 
            var connectionToMap = _repository.SSHConnections.GetSSHConnection(testResult.Remote);
            var testcaseToMap = _repository.TestCases.GetTestCase(testResult.TestCase);
            result.Id = testId;
            result.Name = testResult.Name;
            result.Result = testResult.Result;
            result.Tester = testResult.Tester;
            result.LinkToCore = testResult.LinkToCore;
            result.TestCase = _mapper.Map<TestCaseDto>(testcaseToMap);
            result.Remote = _mapper.Map<SSHConnectionDto>(connectionToMap);

            return result;
        }

        public async Task<List<TestResult>> GetTestResults()
        {
            return _repository.TestResults.GetTestResults(false).ToList();
        }

        public List<TestResult> GetTestsBySearch(string search)
        {
            return _repository.TestResults.GetTestResultsByString(search, false).ToList();
        }

        public async Task<TestResult> RunTest(Test test)
        {
            var remote = _repository.SSHConnections.GetSSHConnection(test.Remote);
            var testCase = _repository.TestCases.GetTestCase(test.TestCase);
            Card cardData = _repository.Cards.GetCard(testCase.Card);

            string processId = _connector.GetCore(remote, testCase.Process);
            string coreName = await _connector.UploadCore(remote, processId);


            TestResult result = _mapper.Map<TestResult>(test);
            result.LinkToCore = coreName;

            var client = new RestClient(_configuration.GetValue<string>("ConnectionStrings:Analyzer"));
            var request = new RestRequest("analyze", Method.Post)
                              .AddHeader("Content-Type", "application/json");

        
            var body = new
            {
                cardData,
                binary_file_name = coreName
            };

            request.AddJsonBody(JsonConvert.SerializeObject(body));

            var response = await client.ExecuteAsync(request);
            var html = "<ul>";
            foreach (var matches in JsonConvert.DeserializeObject<List<string>>(response.Content))
            {
                html += $"<li>{matches}</li>";
            }
            html += "</ul>";
            result.Result = html;
            result.Id = Guid.NewGuid();

            await AddTestResult(result);

            return result;
        }
    }
}
