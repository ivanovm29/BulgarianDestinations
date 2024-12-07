using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulgarianDestinations.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Destination>()
                .HasOne(d => d.Region)
                .WithMany(c => c.Destinations)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c => c.Destination)
                .WithMany(d => d.Comments)
                .HasForeignKey(c => c.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Region> Regions { get; set; } = null!;
        public DbSet<Destination> Destination { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Articul> Articuls { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
    }
}
