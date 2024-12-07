using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Models.SeedDb
{
    internal class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            var data = new SeedData();

            builder.HasData(new Region[]
            {
                data.Blagoevgrad,
                data.Burgas,
                data.Varna,
                data.VelikoTurnovo,
                data.Vidin,
                data.Vraza,
                data.Gabrovo,
                data.Dobrich,
                data.Kardzhali,
                data.Kustendil,
                data.Lovech,
                data.Montana,
                data.Pazardzhik,
                data.Pernik,
                data.Pleven,
                data.Plovdiv,
                data.Razgrad,
                data.Ruse,
                data.Silistra,
                data.Sliven,
                data.Smolian,
                data.SofiaGrad,
                data.SofiaOblast,
                data.StaraZagora,
                data.Targovishte,
                data.Haskovo,
                data.Shumen,
                data.Iambol
            });
        }
    }
}
