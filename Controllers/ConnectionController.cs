using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyPCIBackend.Controllers
{
    [ApiController]
    [Route("connections")]
    public class ConnectionController : ControllerBase
    {
        private IConnectionService _service;
        public ConnectionController(IConnectionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetConnections()
        {
            var _connections = _service.GetConnections();
            return Ok(_connections);
        }

        [HttpGet("{connectionId}")]
        public IActionResult GetConnection(Guid connectionId)
        {
            var _connection = _service.GetConnection(connectionId);
            return Ok(_connection);
        }

        [HttpPost("add_connection")]
        public async Task<IActionResult> AddConnection(SSHConnection connection)
        {
            await _service.AddConnection(connection);
            return Ok();
        }

        [HttpGet("search_result")]
        public IActionResult GetResultsBySearch([FromQuery] string search)
        {
            var _connections = _service.GetConnectionsBySearch(search);
            return _connections.Count != 0 ? Ok(_connections) : Ok();
        }
    }
}
