
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public enum HotelRoomType
    {
        Single,
        Double,
        Deluxe
    }

    public class HotelRoom
    {
        [Key]
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int Capacity { get; set; }
        public HotelRoomType RoomType { get; set; }
        public Hotel Hotel { get; set; }
        public List<HotelBooking> Bookings { get; set; } = new();

        public HotelRoom() { }

    }
}
