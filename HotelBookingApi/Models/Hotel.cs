
namespace HotelBookingApi.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private readonly List<HotelRoom> _rooms = new();
        public IReadOnlyCollection<HotelRoom> Rooms => _rooms;

        // Enforce factory.
        private Hotel() { }

        // Factory function ensures exactly six rooms.
        public static Hotel Create(string name)
        {
            Hotel hotel = new Hotel { Name = name };

            foreach (HotelRoomType type in Enum.GetValues(typeof(HotelRoomType)))
            {
                // two rooms of each type
                hotel._rooms.Add(new HotelRoom(type));
                hotel._rooms.Add(new HotelRoom(type));
            }

            return hotel;
        }
    }
}
