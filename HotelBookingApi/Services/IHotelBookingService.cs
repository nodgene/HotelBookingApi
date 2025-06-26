
using HotelBookingApi.Models;

namespace HotelBookingApi.Services
{
    public interface IHotelBookingService
    {
        HotelBooking CreateBooking(int roomId, DateTime start, DateTime end, int guestCount);
        HotelBooking? GetByReference(string bookingReference);
    }
}
