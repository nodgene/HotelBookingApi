
using HotelBookingApi.Services;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBookingService _bookingService;

        public HotelBookingController(IHotelBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] DtoBookingRequest request)
        {
            try
            {
                HotelBooking booking = _bookingService.CreateBooking(
                    request.RoomId,
                    request.StartDate,
                    request.EndDate,
                    request.GuestCount
                );

                return CreatedAtAction(nameof(GetByReference), new { reference = booking.BookingReference }, booking);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{reference}")]
        public IActionResult GetByReference(string reference)
        {
            HotelBooking booking = _bookingService.GetByReference(reference);

            if (booking is null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
    }

    /// <summary>
    /// DTO for creating bookings.
    /// </summary>
    public class DtoBookingRequest
    {
        public int RoomId { get; set; }
        public int GuestCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
