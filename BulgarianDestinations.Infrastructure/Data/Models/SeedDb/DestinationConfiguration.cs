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
                data.Abritus,
                data.Aladzha,
                data.AsenovaKrepost,
                data.BabaVida,
                data.Balchik,
                data.Batak,
                data.Belintash,
                data.BelogradchikRocks,
                data.BojanaChurch,
                data.Bojurite,
                data.Carevec,
                data.CariMaliGrad,
                data.Cherven,
                data.Chiprovci,
                data.Chirakman,
                data.ChudniteMostove,
                data.Delphinarium,
                data.DevetashkaCave,
                data.DiavolskoGurlo,
                data.Dobursko,
                data.EmenskiKanion,
                data.Erma,
                data.Etura,
                data.GiantManastir,
                data.Irakli,
                data.Ivanovo,
                data.Kabile,
                data.Kailuka,
                data.Kaliakra,
                data.Karanovo,
                data.Koprivshtica,
                data.KrumovoKale,
                data.KrushenskiWaterfall,
                data.Largoto,
                data.Ledenika,
                data.LovechMost,
                data.MadarskiKonnik,
                data.Magura,
                data.ManastirSedemtePrestola,
                data.Melnik,
                data.Mezek,
                data.MogilaGoljamaKosmatka,
                data.MuseumMinnoDelo,
                data.MuseumMozaika,
                data.MuseumRibolov,
                data.Nesebar,
                data.Nikopolis,
                data.Oborishte,
                data.Okolchica,
                data.Pametnik1300Bulgaria,
                data.PanoramaPleven,
                data.Perperikon,
                data.Pliska,
                data.PlovdivStarGrad,
                data.Radecki,
                data.RilaManastir,
                data.Rupite,
                data.SevenRilaLakes,
                data.Shipka,
                data.Snrjanka,
                data.Sozopol,
                data.Sreburna,
                data.StatujaSvoboda,
                data.StobskiPiramids,
                data.SvAleksandarNevski,
                data.SvBogorodica,
                data.Tatul,
                data.VilaArmira,
                data.VruhSnejanka,
                data.Zimzelen
                
            });
        }
    }
}
