using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Common;
using BulgarianDestinations.Infrastructure.Data.Models;
using BulgarianDestinations.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulgarianDestinations.Core.Models.Comment;

namespace BulgarianDestinations.Tests.DestinationTests
{
    [TestFixture]
    public class DestinationInformationTest
    {
        private IEnumerable<Destination> destinations;
        private IEnumerable<Region> regions;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IDestinationService service;

        [SetUp]
        public void TestInitialize()
        {


            var destination1 = new Destination()
            {
                Id = 1,
                Name = "Рупите - Къщата на Ванга",
                Description = "Къщата на Баба Ванга в местността Рупите е била мястото, където известната българска пророчица е приемала нуждаещите се.",
                ImageUrl = "https://i.ibb.co/Q6wvBfd/rupite.jpg",
                RegionId = 1,
            };
            var destination2 = new Destination()
            {
                Id = 2,
                Name = "Мелник",
                Description = "яж е уяжшеу жш Мелник аяио жго ",
                ImageUrl = "https://i.ibb.co/Q6wvBfd/rupite.jpg",
                RegionId = 1,
            };
            var region = new Region()
            {
                Id = 1,
                Name = "Благоевград",
                Destinations = new List<Destination>() { destination1}
            };

            destinations = new List<Destination>()
            {
                destination1
            };
            regions = new List<Region>() { region };



            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "DestinationInformationTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(destinations);
            dbContext.AddRange(regions);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new DestinationService(repository); // Pass it to Service as dependency
        }
        [Test]
        public void Test_DestinationInformationTest()
        {
            var destination = service.DestinationInformation(1).Result;

            string actualName = destination.Name;
            string actualDescription = destination.Description;
            string actualImageUrl = destination.ImageUrl;
            int actualRegionId = destination.RegionId;

            string expectedName = "Рупите - Къщата на Ванга";
            string expectedDescription = "Къщата на Баба Ванга в местността Рупите е била мястото, където известната българска пророчица е приемала нуждаещите се.";
            string expectedImageUrl = "https://i.ibb.co/Q6wvBfd/rupite.jpg";
            int expectedRegionId = 1;

            Assert.That(actualName, Is.EqualTo(expectedName));
            Assert.That(actualDescription, Is.EqualTo(expectedDescription));
            Assert.That(actualImageUrl, Is.EqualTo(expectedImageUrl));
            Assert.That(actualRegionId, Is.EqualTo(expectedRegionId));

        }
    }
}
