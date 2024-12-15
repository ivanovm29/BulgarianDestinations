using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CreditsAppWithDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Articul> Articuls { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ArticulPerson> ArticulsPersons { get;set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ArticulOrder> ArticulOrders { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
