
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelContext _context;

        public HotelService(HotelContext context)
        {
            _context = context;
        }

        public Hotel? GetByName(string name)
        {
            return _context.Hotels
                .Include(h => h.Rooms)
                .ThenInclude(r => r.Bookings)
                .FirstOrDefault(h => h.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
