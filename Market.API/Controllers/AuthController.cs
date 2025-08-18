using Market.Application.DTOs;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var res = await _authService.LoginAsync(dto);
            return Ok(res);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var res = await _authService.RegisterAsync(dto);
            return Ok(res);
        }

        [HttpGet("refresh")]
        public async Task<IActionResult> Refresh([FromQuery] string refreshToken)
        {
            var res = await _authService.RefreshTokenAsync(refreshToken);
            return Ok(res);
        }
    }
}