
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

        public List<HotelRoom> FindAvailableRooms(int hotelId, DateTime start, DateTime end, int guestCount)
        {
            return _context.Rooms
                .Include(r => r.Bookings)
                .Where(r =>
                    r.HotelId == hotelId &&
                    r.Capacity >= guestCount &&
                    !r.Bookings.Any(b => b.StartDate < end && b.EndDate > start)
                )
                .ToList();
        }

    }
}
