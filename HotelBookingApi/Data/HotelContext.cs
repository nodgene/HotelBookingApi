
using Microsoft.EntityFrameworkCore;
using HotelBookingApi.Models;

namespace HotelBookingApi.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> Rooms { get; set; }
        public DbSet<HotelBooking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Unique booking reference.  
            builder.Entity<HotelBooking>()
                   .HasIndex(b => b.BookingReference)
                   .IsUnique();
        }
    }
}
