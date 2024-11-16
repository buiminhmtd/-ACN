using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MovieBooking.Models
{
    public partial class BookingModel : DbContext
    {
        public BookingModel()
            : base("name=BookingModel")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Booking_Details> Booking_Details { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Featured_Showings> Featured_Showings { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Showtime> Showtimes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking_Details>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Booking>()
                .Property(e => e.total_amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Seat>()
                .Property(e => e.seat_row)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
