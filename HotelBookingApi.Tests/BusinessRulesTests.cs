
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
            const string hotelName = "RoomTestHotel";

            // Arrange.
            HotelTestHelper helper = HotelTestHelper.Create("TestDb");
            helper.SeedHotel(hotelName);

            // Act.
            IActionResult result = helper.Controller.FindByName(hotelName);

            // Assert.
            OkObjectResult ok = Assert.IsType<OkObjectResult>(result);
            Hotel hotel = Assert.IsType<Hotel>(ok.Value);
            Assert.Equal(hotelName, hotel.Name);
            Assert.Equal(6, hotel.Rooms.Count);

            helper.Dispose();
        }

        [Fact]
        public void Hotel_HasThreeRoomTypes()
        {
            const string hotelName = "TypeTestHotel";

            // Arrange.
            HotelTestHelper helper = HotelTestHelper.Create("TestDb");
            helper.SeedHotel(hotelName);

            // Act.
            IActionResult result = helper.Controller.FindByName(hotelName);

            // Assert.
            OkObjectResult ok = Assert.IsType<OkObjectResult>(result);
            Hotel hotel = Assert.IsType<Hotel>(ok.Value);

            Assert.Equal(hotelName, hotel.Name);
            List<HotelRoomType> roomTypes = hotel.Rooms.Select(r => r.RoomType).Distinct().ToList();
            Assert.Contains(HotelRoomType.Single, roomTypes);
            Assert.Contains(HotelRoomType.Double, roomTypes);
            Assert.Contains(HotelRoomType.Deluxe, roomTypes);
            Assert.Equal(3, roomTypes.Count);

            helper.Dispose();
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
