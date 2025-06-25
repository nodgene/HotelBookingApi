
public class HotelBooking
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GuestCount { get; set; }
    public string BookingReference { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public HotelRoom Room { get; set; }
}
