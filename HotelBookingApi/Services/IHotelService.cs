
using HotelBookingApi.Models;

namespace HotelBookingApi.Services
{
    public interface IHotelService
    {
        Hotel? GetByName(string name);
    }
}
