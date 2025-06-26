
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using HotelBookingApi.Controllers;
using Xunit;

namespace HotelBookingApi.Tests
{

    public class BusinessFunctionalityTests
    {
        [Fact]
        public void FindHotelByName_HotelExists()
        {
            // Arrange (in-memory context)
            var options = new DbContextOptionsBuilder<HotelContext>()
                .UseInMemoryDatabase("TestDb1")
                .Options;
            using var ctx = new HotelContext(options);
            ctx.Hotels.Add(new Hotel { Id = 1, Name = "TestHotel" });
            ctx.SaveChanges();

            HotelService service = new HotelService(ctx);
            HotelController controller = new HotelController(service);

            // Act
            IActionResult result = controller.FindByName("TestHotel");

            // Assert
            OkObjectResult ok = Assert.IsType<OkObjectResult>(result);
            Hotel hotel = Assert.IsType<Hotel>(ok.Value);
            Assert.Equal("TestHotel", hotel.Name);
        }

        [Fact]
        public void FindHotelByName_HotelDoesNotExist()
        {
            // Arrange (an empty in-memory database)
            var options = new DbContextOptionsBuilder<HotelContext>()
                .UseInMemoryDatabase("TestDb2")
                .Options;
            using var ctx = new HotelContext(options);
            // No hotels added

            HotelService service = new HotelService(ctx);
            HotelController controller = new HotelController(service);

            // Act
            IActionResult result = controller.FindByName("MissingHotel");

            // Assert
            Assert.IsType<NotFoundResult>(result);
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
