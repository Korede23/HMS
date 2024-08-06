using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJWTService _JWTService;
        private readonly IUserServices _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IJWTService JWTService, IUserServices userService, IConfiguration configuration)
        {
            _JWTService = JWTService;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.GetUserByUserNAmeAsync(request.Username, request.PassWord);
            if (user == null)
            {
                return Unauthorized();
            }

            string tokenResponse = _JWTService.JwtWebToken(user);
            return Ok(new { tokenResponse });
        }
    }
}

