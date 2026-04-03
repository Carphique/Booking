using Booking.DTO;
using Booking.Models;
using Booking.Sources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly HotelSource _source;
    public HotelsController(HotelSource source) => _source = source;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] HotelQueryDTO query) => Ok(await _source.GetAllAsync(query));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var h = await _source.GetByIdAsync(id);
        return h == null ? NotFound() : Ok(h);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] HotelCreateDTO dto)
    {
        var hotel = new Hotel
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            City = dto.City,
            PricePerNight = dto.PricePerNight,
            ImagePath = dto.Image?.FileName
        };
        await _source.CreateAsync(hotel);
        return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, hotel);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, HotelUpdateDTO dto) =>
        await _source.UpdateAsync(id, dto) ? Ok("Оновлено") : NotFound();

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) =>
        await _source.DeleteAsync(id) ? NoContent() : NotFound();
}