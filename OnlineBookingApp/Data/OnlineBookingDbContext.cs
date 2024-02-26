using Microsoft.EntityFrameworkCore;
using OnlineBookingApp.Models.Booking;


namespace OnlineBookingApp.Data
{
    public class OnlineBookingDbContext :DbContext
    {
        public OnlineBookingDbContext(DbContextOptions options) : base(options)
        {
        
        
        }


        public DbSet<Hotel> hotels { get; set; }

        public DbSet<CarRental> cars { get; set; }

        public DbSet<Flight> flights { get; set; }

        public DbSet<Guest> guest { get; set; }


        public DbSet<GuestBooking> guestBooking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingGuest>().HasNoKey();
        }
    }
}
