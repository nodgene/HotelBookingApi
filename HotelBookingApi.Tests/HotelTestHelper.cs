
using Microsoft.EntityFrameworkCore;
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using HotelBookingApi.Services;
using HotelBookingApi.Controllers;

namespace HotelBookingApi.Tests
{

    public class HotelTestHelper : IDisposable
    {
        public HotelContext Context { get; private set; }
        public HotelService Service { get; private set; }
        public HotelController Controller { get; private set; }
        public HotelBookingService BookingService { get; private set; }
        public HotelBookingController BookingController { get; private set; }

        private HotelTestHelper() { }

        public static HotelTestHelper Create(string dbName)
        {
            HotelTestHelper helper = new HotelTestHelper();

            var options = new DbContextOptionsBuilder<HotelContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            helper.Context = new HotelContext(options);
            helper.Service = new HotelService(helper.Context);
            helper.Controller = new HotelController(helper.Service);
            helper.BookingService = new HotelBookingService(helper.Context);
            helper.BookingController = new HotelBookingController(helper.BookingService);

            return helper;
        }

        public void SeedHotel(string hotelName)
        {
            Hotel hotel = new Hotel
            {
                Name = hotelName,
                Rooms = Enum.GetValues<HotelRoomType>()
                    .Cast<HotelRoomType>()
                    .SelectMany(roomType =>
                    {
                        int roomCapacity = roomType switch
                        {
                            HotelRoomType.Single => 1,
                            HotelRoomType.Double => 2,
                            HotelRoomType.Deluxe => 4,
                            _ => throw new ArgumentOutOfRangeException()
                        };

                        // Two rooms of each type.
                        return Enumerable.Range(0, 2)
                                         .Select(_ => new HotelRoom
                                         {
                                             RoomType = roomType,
                                             Capacity = roomCapacity
                                         });
                    })
                    .ToList()
            };

            Context.Hotels.Add(hotel);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }

    }

}
