using Booking.DTO;
using Booking.Sources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly BookingSource _source;
    public BookingsController(BookingSource source) => _source = source;

    [HttpPost]
    public async Task<IActionResult> Create(BookingCreateDTO dto)
    {
        var booking = new Booking.Models.Booking
        {
            Id = Guid.NewGuid(),
            HotelId = dto.HotelId,
            RoomId = dto.RoomId,
            UserId = dto.UserId,
            DateFrom = dto.DateFrom,
            DateTo = dto.DateTo
        };
        var result = await _source.CreateAsync(booking);
        return result == null ? BadRequest("Кімната зайнята") : Ok(result);
    }

    [HttpPut("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid id) =>
        await _source.CancelAsync(id) ? Ok("Скасовано") : NotFound();

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetUserBookings(Guid userId) => Ok(await _source.GetByUserIdAsync(userId));
}