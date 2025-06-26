
namespace HotelBookingApi.Models
{
    public enum HotelRoomType
    {
        Single = 1,
        Double = 2,
        Deluxe = 4
    }

    public class HotelRoom
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public HotelRoomType RoomType { get; set; }
        public Hotel Hotel { get; set; }
        public List<HotelBooking> Bookings { get; set; } = new();
    }
}
