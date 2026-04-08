using Booking.DTO;
using Booking.Models;
using Booking.Sources;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserSource _source;

        public UsersController(UserSource source)
        {
            _source = source;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserReadDTO>>> GetAll()
        {
            var users = await _source.GetAllAsync();
            var result = users.Select(u => new UserReadDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserReadDTO>> GetById(Guid id)
        {
            var user = await _source.GetByIdAsync(id);
            if (user == null) return NotFound("Користувача не знайдено.");

            return Ok(new UserReadDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = dto.Password, 
                DateOfBirth = dto.DateOfBirth
            };

            await _source.CreateAsync(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UserUpdateDTO dto)
        {
            var success = await _source.UpdateAsync(id, dto);

            if (!success)
                return NotFound("Користувача не знайдено.");

            return Ok("Профіль користувача успішно оновлено.");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _source.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}