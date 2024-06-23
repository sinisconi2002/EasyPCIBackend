using AutoMapper;
using Azure.Storage.Blobs;
using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using EasyPCIBackend.Models.Dtos;
using EasyPCIBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyPCIBackend.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        private ITestService _service;
        private IRepositoryManager _repository;
        private SSHConnector _connector;
        private IMapper _mapper;
        private IConfiguration _configuration;
        public TestController(ITestService service, IRepositoryManager repository, IMapper mapper, IConfiguration configuration)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet("testCreator")]
        public IActionResult GetTestCreator() 
        {   
            var testCreator = _service.GetTestCreator();
            return Ok(testCreator);
        }

        [HttpGet]
        public IActionResult GetTestResults()
        {
            var testResults = _service.GetTestResults();
            return Ok(testResults);
        }

        [HttpGet("{testResultId}")]
        public IActionResult GetTestResult(Guid testResultId) {
            var testResult = _service.GetTestResult(testResultId);
            return Ok(testResult);
        }

        [HttpPost("tester")]
        public async Task<IActionResult> TestMechanismAsync([FromBody] Test test)
        {
            var result = await _service.RunTest(test);
            return Ok(result);
        }

        [HttpGet("search_result")]
        public IActionResult GetResultsBySearch([FromQuery] string search)
        {
            var _tests = _service.GetTestsBySearch(search);
            return _tests.Count != 0 ? Ok(_tests) : Ok();
        } 

        [HttpGet("download-core-dump")]
        public async Task<IActionResult> DownloadCoreDump([FromQuery] string blobName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_configuration.GetValue<string>("ConnectionStrings:AzureStorage"));
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("coredumps");
            BlobClient blobClient = containerClient.GetBlobClient(blobName);


            var blobDownloadInfo = await blobClient.DownloadAsync();

            MemoryStream memoryStream = new MemoryStream();
            await blobDownloadInfo.Value.Content.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            return File(memoryStream, "application/octet-stream", blobName);
            
        }
    }
}
