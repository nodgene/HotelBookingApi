
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
    }
}
