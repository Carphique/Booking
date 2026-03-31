using Booking.Data;
using Booking.DTO;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public UsersController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserReadDTO>>> GetAll()
        {
            return await _context.Users
                .Select(u => new UserReadDTO
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                }).ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserReadDTO>> GetById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return new UserReadDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
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
                DateOfBirth = dto.DateOfBirth
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UserCreateDTO dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.DateOfBirth = dto.DateOfBirth;

            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
