using Microsoft.EntityFrameworkCore;
using ServiceBookingAPI.Models;
using ServiceBookingAPI.Data;


namespace ServiceBookingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Categories> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> Bookings
            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Service -> Bookings
            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Service)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);
        }


    }
}
