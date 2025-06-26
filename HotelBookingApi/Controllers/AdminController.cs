
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {

        private readonly HotelContext _context;

        public AdminController(HotelContext context)
        {
            _context = context;
        }

        [HttpPost("reset")]
        public IActionResult Reset()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            return Ok("Database reset.");
        }

        [HttpPost("seed")]
        public IActionResult Seed()
        {
            if (_context.Hotels.Any())
            {
                return BadRequest("Already seeded.");
            }

            Hotel hotel = new Hotel
            {
                Name = "SeededHotel",
                Rooms = Enum.GetValues<HotelRoomType>()
                    .SelectMany(type =>
                    {
                        int capacity = type switch
                        {
                            HotelRoomType.Single => 1,
                            HotelRoomType.Double => 2,
                            HotelRoomType.Deluxe => 4,
                            _ => throw new ArgumentOutOfRangeException()
                        };

                        return Enumerable.Range(0, 2).Select(_ => new HotelRoom
                        {
                            RoomType = type,
                            Capacity = capacity
                        });
                    }).ToList()
            };

            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return Ok("Hotel seeded.");
        }

    }

}
