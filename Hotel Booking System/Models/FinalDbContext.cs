using Microsoft.EntityFrameworkCore;
using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Models
{
    public class FinalDbContext : DbContext
    {
        public FinalDbContext(DbContextOptions<FinalDbContext> options) : base(options)
        {

        }
        public DbSet<Hotels> Hotels { get; set; }

        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<HotelBooking> hotelBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
