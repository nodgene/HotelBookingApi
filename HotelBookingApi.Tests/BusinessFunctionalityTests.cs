
using Xunit;

namespace HotelBookingApi.Tests
{

    public class BusinessFunctionalityTests
    {
        [Fact]
        public void FindHotelByName_ShouldReturnHotel_WhenHotelExists()
        {
            // TODO: Arrange controller with in-memory context and seeded hotel
            // TODO: Act call controller.FindByName("TestHotel")
            // TODO: Assert result is OkObjectResult with matching Hotel
        }

        [Fact]
        public void FindHotelByName_ShouldReturnNotFound_WhenHotelDoesNotExist()
        {
            // TODO: Arrange no hotels in context
            // TODO: Act call controller.FindByName("UnknownHotel")
            // TODO: Assert result is NotFoundResult
        }

        [Fact]
        public void GetAvailableRooms_ShouldReturnRooms_WhenCriteriaMet()
        {
            // TODO: Arrange AvailabilityController with seeded data
            // TODO: Act call controller.GetAvailable(...)
            // TODO: Assert returned list matches expected rooms
        }

        [Fact]
        public void BookRoom_ShouldCreateBooking_WhenRoomIsAvailable()
        {
            // TODO: Arrange BookingController with available room
            // TODO: Act call controller.Book(...)
            // TODO: Assert created booking and Ok response
        }

        [Fact]
        public void GetBookingByReference_ShouldReturnBooking_WhenReferenceExists()
        {
            // TODO: Arrange BookingController with existing booking
            // TODO: Act call controller.Get("REF123")
            // TODO: Assert OkObjectResult with correct booking
        }

        [Fact]
        public void SeedAndReset_ShouldPopulateAndClearData()
        {
            // TODO: Arrange TestController
            // TODO: Act call seed then reset
            // TODO: Assert database has records after seed and none after reset
        }
    }

}
