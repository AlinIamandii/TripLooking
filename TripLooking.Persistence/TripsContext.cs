using Microsoft.EntityFrameworkCore;
using TripLooking.Entities.Trips;

namespace TripLooking.Persistence
{
    public sealed class TripsContext : DbContext
    {
        public TripsContext(DbContextOptions<TripsContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
                .HasMany<Comment>(trip => trip.Comments)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Trip>()
                .HasMany<Photo>(trip => trip.Photos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<Photo>()
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}