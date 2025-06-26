
using HotelBookingApi.Models;

namespace HotelBookingApi.Services
{
    public interface IHotelService
    {
        Hotel? GetByName(string name);
        List<HotelRoom> FindAvailableRooms(int hotelId, DateTime start, DateTime end, int guestCount);
    }
}
