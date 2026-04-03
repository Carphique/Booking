using Booking.DTO;
using Booking.Sources;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthSource _authSource;
        public AuthController(AuthSource authSource) => _authSource = authSource;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _authSource.LoginAsync(dto.Email, dto.Password);
            return token == null ? Unauthorized("Невірний логін або пароль") : Ok(new { Token = token });
        }
    }
}
