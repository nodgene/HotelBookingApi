
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HotelRoom> Rooms { get; set; } = new();

        public Hotel() { }

    }
}
