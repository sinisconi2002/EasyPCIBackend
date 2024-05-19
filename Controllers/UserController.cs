using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using EasyPCIBackend.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyPCIBackend.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _service;
        private readonly ISigningService _signing;
        private readonly IConfiguration _configuration;
        private readonly SecurityKey key;

        public UserController(IUserService service, ISigningService signing, IConfiguration configuration)
        {
            _service = service;
            _signing = signing;
            _configuration = configuration;

            //key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var _users = _service.GetUsers();
            return Ok(_users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(Guid userId)
        {
            var _user = _service.GetUser(userId);
            return Ok(_user);
        }

        [HttpPost("add_user")]
        public async Task<IActionResult> AddUser(User user)
        {
            await _signing.RegisterUser(user);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }
            if (_signing.ValidateUser(user))
            {
                var _secret = _service.GetUserByString(user.Username);
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, _secret.Username),
                    new Claim(JwtRegisteredClaimNames.NameId , _secret.Id.ToString()),
                };

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(_configuration["JWT:Issuer"],
                    _configuration["JWT:Audience"],
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok();
                //return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
