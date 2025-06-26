
namespace HotelBookingApi.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HotelRoom> Rooms { get; set; } = new();
    }
}
