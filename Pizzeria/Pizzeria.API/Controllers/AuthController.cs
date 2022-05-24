using Microsoft.AspNetCore.Mvc;
using Pizzeria.API.Dto;
using Pizzeria.API.Services.AuthService;
using Pizzeria.API.Services.LoggerService;

namespace Pizzeria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILoggerService _logger;

        public AuthController(IAuthService authService, ILoggerService logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            var response = await _authService.Register(user);

            if (!response.Success)
            {
                response.Message = "User already exists.";
                _logger.LogError(response.Message);
                return BadRequest(response.Message);
            }

            response.Message = "User Successfuly Registered.";
            _logger.LogError(response.Message);
            return Ok(response.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            var response = await _authService.Login(user);
            if(!string.IsNullOrEmpty(response.Message))
            {
                _logger.LogError(response.Message);
                return BadRequest(response.Message);
            }
            response.Message = "Login Successful.";
            _logger.LogError(response.Message);
            return Ok(response.Data);
        }
    }
}
