using Booking.Data;
using Booking.Models;
using Booking.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly BookingDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(BookingDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDTO dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email уже занят");

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Регистрация успешна" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user == null) return Unauthorized("Пользователь не найден");

            // Генерация токена
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SuperSecretKey12345678901234567890"); // Должен совпадать с Program.cs
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user = new { user.Id, user.FirstName, user.Email }
            });
        }
    }

    public class LoginRequest { public string Email { get; set; } = ""; public string Password { get; set; } = ""; }
}