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
using BulgarianDestinations.Core.Models.Destination;

namespace BulgarianDestinations.Tests.DestinationTests
{
    [TestFixture]
    public class AddDestinationTest
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
            var region = new Region()
            {
                Id = 1,
                Name = "Благоевград",
                Destinations = new List<Destination>() { destination1 }
            };

            destinations = new List<Destination>()
            {
                destination1
            };
            regions = new List<Region>() { region };



            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "AddDestinationTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(destinations);
            dbContext.AddRange(regions);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new DestinationService(repository); // Pass it to Service as dependency
        }
        [Test]
        public void Test_AddDestinationTest()
        {
            string name = "Мелник";
            string description = "яж е уяжшеу жш Мелник аяио жго ";
            string imageUrl = "https://i.ibb.co/Q6wvBfd/rupite.jpg";
            int regionId = 1;
            var destinationFormViewModel = new DestinationFormViewModel()
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                RegionId = regionId
            };

            service.AddDestination(destinationFormViewModel);

            int actualCount = repository.AllReadOnly<Destination>().Where(d => d.RegionId == 1).Count();
            int expectedCount = 2;

            string actualName = repository.GetById<Destination>(2).Result.Name;
            string actualDescription = repository.GetById<Destination>(2).Result.Description;
            string actualImageUrl = repository.GetById<Destination>(2).Result.ImageUrl;
            int actualRegionId = repository.GetById<Destination>(2).Result.RegionId;

            Assert.That(actualCount, Is.EqualTo(expectedCount));

            Assert.That(actualName, Is.EqualTo(name));
            Assert.That(actualDescription, Is.EqualTo(description));
            Assert.That(actualImageUrl, Is.EqualTo(imageUrl));
            Assert.That(actualRegionId, Is.EqualTo(regionId));



        }
    }
}
