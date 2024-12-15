using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Models.Destination;
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

namespace BulgarianDestinations.Tests.DestinationTests
{
    [TestFixture]
    public class DeleteDestinationTest
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
                Destinations = new List<Destination>() { destination1, destination2 }
            };

            destinations = new List<Destination>()
            {
                destination1
            };
            regions = new List<Region>() { region };



            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "DeleteDestinationTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(destinations);
            dbContext.AddRange(regions);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new DestinationService(repository); // Pass it to Service as dependency
        }
        [Test]
        public void Test_DeleteDestinationTest()
        {
            service.DeleteDestination(2);

            int actualCount = repository.AllReadOnly<Destination>().Count();
            int expectedCount = 1;

            Assert.That(actualCount, Is.EqualTo(expectedCount));

        }
    }
}
