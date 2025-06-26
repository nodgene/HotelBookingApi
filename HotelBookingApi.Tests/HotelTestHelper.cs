
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

            return helper;
        }

        public void SeedHotel(string name)
        {
            // Use the factory method to ensure exactly six rooms.
            Context.Hotels.Add(Hotel.Create(name));
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }

}
