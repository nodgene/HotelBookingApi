
using Microsoft.AspNetCore.Mvc;
using HotelBookingApi.Models;
using Xunit;

namespace HotelBookingApi.Tests
{

    public class BusinessFunctionalityTests
    {
        [Fact]
        public void FindHotelByName_HotelExists()
        {
            const string hotelName = "TestHotel";

            // Arrange.
            HotelTestHelper helper = HotelTestHelper.Create("TestDb");
            helper.SeedHotel(hotelName);

            // Act.
            IActionResult result = helper.Controller.FindByName(hotelName);

            // Assert.
            OkObjectResult ok = Assert.IsType<OkObjectResult>(result);
            Hotel hotel = Assert.IsType<Hotel>(ok.Value);
            Assert.Equal(hotelName, hotel.Name);

            helper.Dispose();
        }

        [Fact]
        public void FindHotelByName_HotelDoesNotExist()
        {
            // Arrange.
            HotelTestHelper helper = HotelTestHelper.Create("TestDb");

            // Act.
            IActionResult result = helper.Controller.FindByName("MissingHotel");

            // Assert.
            Assert.IsType<NotFoundResult>(result);

            helper.Dispose();
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
