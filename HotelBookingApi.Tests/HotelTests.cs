
using HotelBookingApi.Controllers;
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HotelBookingApi.Tests
{

    public class HotelTests
    {

        [Fact]
        public void Hotel_HasSixRooms()
        {
            const string hotelName = "RoomTestHotel";

            // Arrange.
            HotelTestHelper helper = HotelTestHelper.Create("Hotel_HasSixRooms");
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
            HotelTestHelper helper = HotelTestHelper.Create("Hotel_HasThreeRoomTypes");
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
        public void Hotel_FindHotelByName()
        {
            const string hotelName = "TestHotel";

            // Arrange.
            HotelTestHelper helper = HotelTestHelper.Create("Hotel_FindHotelByName");
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
        public void Hotel_CannotFindHotelByName()
        {
            // Arrange.
            HotelTestHelper helper = HotelTestHelper.Create("Hotel_CannotFindHotelByName");

            // Act.
            IActionResult result = helper.Controller.FindByName("MissingHotel");

            // Assert.
            Assert.IsType<NotFoundResult>(result);
            helper.Dispose();
        }

        [Fact]
        public void Booking_CreateBookingWhenRoomAvailable()
        {
            const string hotelName = "BookableHotel";

            // Arrange.
            HotelTestHelper helper = HotelTestHelper.Create("CreateBooking_WhenRoomAvailable");
            helper.SeedHotel(hotelName);
            HotelRoom room = helper.Context.Rooms.First();
            DateTime start = DateTime.Today.AddDays(1);
            DateTime end = start.AddDays(2);

            // Act.
            HotelBooking booking = helper.BookingService.CreateBooking(
                room.Id, start, end, room.Capacity
            );

            // Assert.
            Assert.NotNull(booking);
            Assert.Equal(room.Id, booking.RoomId);
            Assert.Equal(start, booking.StartDate);
            Assert.Equal(end, booking.EndDate);
            Assert.Equal(booking.GuestCount, room.Capacity);
            Assert.False(string.IsNullOrWhiteSpace(booking.BookingReference));
            helper.Dispose();
        }

        [Fact]
        public void Booking_ErrorWhenRoomAlreadyBooked()
        {
            const string hotelName = "DoubleBookHotel";

            // Arrange.
            HotelTestHelper helper = HotelTestHelper.Create("TestDb");
            helper.SeedHotel(hotelName);
            HotelRoom room = helper.Context.Rooms.First();
            DateTime start = DateTime.Today.AddDays(1);
            DateTime end = start.AddDays(2);

            helper.Context.Bookings.Add(new HotelBooking
            {
                RoomId = room.Id,
                StartDate = start,
                EndDate = end,
                GuestCount = 1,
                BookingReference = Guid.NewGuid().ToString()
            });
            helper.Context.SaveChanges();

            // Act.
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                helper.BookingService.CreateBooking(room.Id, start, end, 1)
            );

            // Assert.
            Assert.Contains("already booked", ex.Message, StringComparison.OrdinalIgnoreCase);
            helper.Dispose();
        }

    }

}
