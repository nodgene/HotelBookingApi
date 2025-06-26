
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public class HotelBooking
    {
        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int GuestCount { get; set; }
        public string BookingReference { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public HotelRoom Room { get; set; }

        public HotelBooking() { }

    }
}
