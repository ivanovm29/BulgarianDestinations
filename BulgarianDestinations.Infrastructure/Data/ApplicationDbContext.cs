using BulgarianDestinations.Infrastructure.Data.Models;
using BulgarianDestinations.Infrastructure.Data.Models.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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


            builder.Entity<Comment>()
                .HasOne(c => c.Destination)
                .WithMany(d => d.Comments)
                .HasForeignKey(c => c.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DestinationPerson>()
                .HasKey(sp => new { sp.DestinationId, sp.PersonId });

            builder.Entity<DestinationPerson>()
                .HasOne(s => s.Destination)
                .WithMany(s => s.DestinationsPersons)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CommentPerson>()
                .HasKey(sp => new { sp.CommentId, sp.PersonId });

            builder.Entity<CommentPerson>()
                .HasOne(s => s.Comment)
                .WithMany(s => s.CommentsPersons)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArticulPerson>()
                .HasKey(ao => new { ao.ArticulId, ao.PersonId });

            builder.Entity<ArticulPerson>()
                .HasOne(s => s.Articul)
                .WithMany(s => s.ArticulsPersons)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArticulOrder>()
                .HasKey(bc => new { bc.ArticulId, bc.OrderId });

            builder.Entity<Articul>()
                .HasMany(s => s.Orders)
                .WithMany(a => a.Articuls)
                .UsingEntity<ArticulOrder>();

            //builder.Entity<ArticulOrder>()
            //    .HasKey(bc => new { bc.ArticulId, bc.OrderId });

            //builder.Entity<ArticulOrder>()
            //    .HasOne(ao => ao.Articul)
            //    .WithMany(b => b.ArticulOrder)
            //    .HasForeignKey(bc => bc.ArticulId);

            //builder.Entity<ArticulOrder>()
            //    .HasOne(bc => bc.Order)
            //    .WithMany(c => c.ArticulOrder)
            //    .HasForeignKey(bc => bc.OrderId);


            builder.ApplyConfiguration(new RegionConfiguration());
            builder.ApplyConfiguration(new DestinationConfiguration());
            builder.ApplyConfiguration(new ArticulConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Region> Regions { get; set; } = null!;
        public DbSet<Destination> Destination { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Articul> Articuls { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<ArticulOrder> ArticulOrder { get; set; } = null!;


    }
}
