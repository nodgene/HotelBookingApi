
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Services
{

    public class HotelBookingService : IHotelBookingService
    {
        private readonly HotelContext _context;

        public HotelBookingService(HotelContext context)
        {
            _context = context;
        }

        public HotelBooking CreateBooking(int roomId, DateTime start, DateTime end, int guestCount)
        {
            // 1. Load room with bookings.
            HotelRoom room = _context.Rooms
                        .Include(r => r.Bookings)
                        .FirstOrDefault(r => r.Id == roomId)
                    ?? throw new InvalidOperationException("Room not found");

            // 2. Capacity check.
            if (guestCount > room.Capacity)
            {
                throw new InvalidOperationException("Guest count exceeds room capacity");
            }

            // 3. Overlap check.
            bool overlap = room.Bookings.Any(b =>
                b.StartDate < end && b.EndDate > start);

            if (overlap)
            {
                throw new InvalidOperationException("Room is already booked for those dates");
            }

            // 4. Create booking.
            HotelBooking booking = new HotelBooking
            {
                RoomId = roomId,
                StartDate = start,
                EndDate = end,
                GuestCount = guestCount,
                BookingReference = Guid.NewGuid().ToString()
            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return booking;
        }

        public HotelBooking? GetByReference(string bookingReference)
        {
            return _context.Bookings
                    .Include(b => b.Room)
                    .ThenInclude(r => r.Hotel)
                    .FirstOrDefault(b => b.BookingReference == bookingReference);
        }
    }

}
