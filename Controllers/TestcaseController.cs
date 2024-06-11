using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyPCIBackend.Controllers
{
    [ApiController]
    [Route("testcases")]
    public class TestcaseController : ControllerBase
    {
        private ITestcaseService _service;
        public TestcaseController(ITestcaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTestcases()
        {
            var _testcases = _service.GetTestcases();
            return Ok(_testcases);
        }

        [HttpGet("{connectionId}")]
        public IActionResult GetTestcase(Guid testcaseId)
        {
            var _testcase = _service.GetTestcase(testcaseId);
            return Ok(_testcase);
        }

        [HttpPost("add_testcase")]
        public async Task<IActionResult> AddTestcase(TestCase connection)
        {
            await _service.AddTestcase(connection);
            return Ok();
        }

        [HttpGet("search_result")]
        public IActionResult GetResultsBySearch([FromQuery] string search)
        {
            var _testcases = _service.GetTestcasesBySearch(search);
            return _testcases.Count != 0 ? Ok(_testcases) : Ok();
        }
    }
}
