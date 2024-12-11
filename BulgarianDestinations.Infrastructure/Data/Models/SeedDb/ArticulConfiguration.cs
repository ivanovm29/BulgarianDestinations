using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Models.SeedDb
{
    internal class ArticulConfiguration : IEntityTypeConfiguration<Articul>
    {
        public void Configure(EntityTypeBuilder<Articul> builder)
        {
            var data = new SeedData();

            builder.HasData(new Articul[]
            {
                data.Grivna,
                data.Rakavici,
                data.Pompa
            });
        }
    }
}
