using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Models.SeedDb
{
    internal class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder
                .HasOne(d => d.Region)
                .WithMany(c => c.Destinations)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Destination[]
            {
                data.Rupite
            });
        }
    }
}
