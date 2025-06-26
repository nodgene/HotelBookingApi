
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public IActionResult FindByName([FromQuery] string name)
        {
            var hotel = _hotelService.GetByName(name);

            if (hotel is null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        [HttpGet("{hotelId}/available")]
        public IActionResult GetAvailableRooms(int hotelId, [FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] int guests)
        {
            if (start >= end)
            {
                return BadRequest("Invalid date range.");
            }

            if (guests <= 0)
            {
                return BadRequest("Invalid guest count.");
            }

            List<HotelRoom> rooms = _hotelService.FindAvailableRooms(hotelId, start, end, guests);
            return Ok(rooms);
        }

    }

}
