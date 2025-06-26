
using HotelBookingApi.Controllers;
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HotelBookingApi.Tests
{

    public class BusinessRulesTests
    {
        [Fact]
        public void FindHotelByName_HasSixRooms()
        {
            string hotelName = "TestHotel";
            // Arrange (in-memory context)
            var options = new DbContextOptionsBuilder<HotelContext>()
                .UseInMemoryDatabase("TestDb1")
                .Options;
            using var ctx = new HotelContext(options);
            ctx.Hotels.Add(Hotel.Create(hotelName));
            ctx.SaveChanges();

            HotelService service = new HotelService(ctx);
            HotelController controller = new HotelController(service);

            // Act
            IActionResult result = controller.FindByName(hotelName);

            // Assert
            OkObjectResult ok = Assert.IsType<OkObjectResult>(result);
            Hotel hotel = Assert.IsType<Hotel>(ok.Value);
            Assert.Equal(6, hotel.Rooms.Count);
        }

        [Fact]
        public void FindAvailableRooms_ShouldExcludeBookedRooms()
        {
            // TODO: Arrange AvailabilityService with context including booking overlap
            // TODO: Act service.FindAvailableRooms
            // TODO: Assert booked room is excluded
        }

        [Fact]
        public void CreateBooking_ShouldThrow_WhenRoomDoubleBooked()
        {
            // TODO: Arrange BookingService with existing booking
            // TODO: Act & Assert exception thrown on double booking
        }

        [Fact]
        public void CreateBooking_ShouldThrow_WhenGuestCountExceedsCapacity()
        {
            // TODO: Arrange BookingService and room with limited capacity
            // TODO: Act & Assert exception thrown when guest count too high
        }

        [Fact]
        public void BusinessRules_ShouldEnforceRoomTypesAndCapacities()
        {
            // TODO: Arrange model or service checks
            // TODO: Act and assert RoomType enum has Single, Double, Deluxe and capacities
        }

        [Fact]
        public void BookingReference_ShouldBeUnique()
        {
            // TODO: Arrange service with duplicate reference scenario
            // TODO: Act & Assert exception or error on duplicate reference
        }
    }

}
