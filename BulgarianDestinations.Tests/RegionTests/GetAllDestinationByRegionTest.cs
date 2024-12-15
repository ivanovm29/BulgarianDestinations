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

namespace BulgarianDestinations.Tests.RegionTests
{
    [TestFixture]
    public class GetAllDestinationByRegionTest
    {
        private IEnumerable<Region> regions;
        private IEnumerable<Destination> destinations;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IRegionService service;

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
            var destination3 = new Destination()
            {
                Id = 3,
                Name = "Добърско - вкопаната църква",
                Description = "Късносредновековната църква „Св. св. Теодор Тирон и Теодор Стратилат“",
                ImageUrl = "https://i.ibb.co/LkYVK96/Dobursko.jpg",
                RegionId = 1,
            };
            var destination4 = new Destination()
            {
                Id = 4,
                Name = "Плажът на Иракли",
                Description = "Плажната ивица на Иракли е дълга и широка. От към входа, пясъкът е ситен и жълт.",
                ImageUrl = "https://i.ibb.co/rMX0M7n/Irakli.jpg",
                RegionId = 2
            };
            var destination5 = new Destination()
            {
                Id = 5,
                Name = "Несебър - стар град",
                Description = "Едва ли са много хората, които са посетили Стария град на Несебър и той не е станал любимо място за разходка и отдих.",
                ImageUrl = "https://i.ibb.co/BLfw4dh/Nesebar.jpg",
                RegionId = 2
            };

            var region1 = new Region()
            {
                Id = 1,
                Name = "Благоевград",
                Destinations = new List<Destination>() { destination1, destination2, destination3 }
            };
            var region2 = new Region()
            {
                Id = 2,
                Name = "Бургас",
                Destinations = new List<Destination>() { destination4, destination5 }
            };

            destinations = new List<Destination>()
            {
                destination1, destination2, destination3, destination4, destination5
            };
            regions = new List<Region>() { region1, region2 };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "GetAllDestinationByRegionTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(destinations);
            dbContext.AddRange(regions);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new RegionService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_GetAllDestinationByRegionTest()
        {
            var allDestination = service.GetAll(2).Result;

            int actualCount = allDestination.Count();

            int actualId1 = allDestination.ToList()[1].Id;
            string actualName1 = allDestination.ToList()[1].Name;
            string actualDescription1 = allDestination.ToList()[1].Description;
            string actualImageUrl1 = allDestination.ToList()[1].ImageUrl;

            int actualId2 = allDestination.ToList()[0].Id;
            string actualName2 = allDestination.ToList()[0].Name;
            string actualDescription2 = allDestination.ToList()[0].Description;
            string actualImageUrl2 = allDestination.ToList()[0].ImageUrl;


            int expectedCount = 2;

            int expectedId1 = 4;
            string expectedName1 = "Плажът на Иракли";
            string expectedDescription1 = "Плажната ивица на Иракли е дълга и широка. От към входа, пясъкът е ситен и жълт.";
            string expectedImageUrl1 = "https://i.ibb.co/rMX0M7n/Irakli.jpg";

            int expectedId2 = 5;
            string expectedName2 = "Несебър - стар град";
            string expectedDescription2 = "Едва ли са много хората, които са посетили Стария град на Несебър и той не е станал любимо място за разходка и отдих.";
            string expectedImageUrl2 = "https://i.ibb.co/BLfw4dh/Nesebar.jpg";

            Assert.That(actualCount, Is.EqualTo(expectedCount));

            Assert.That(actualId1, Is.EqualTo(expectedId1));
            Assert.That(actualName1, Is.EqualTo(expectedName1));
            Assert.That(actualDescription1, Is.EqualTo(expectedDescription1));
            Assert.That(actualImageUrl1, Is.EqualTo(expectedImageUrl1));


            Assert.That(actualId2, Is.EqualTo(expectedId2));
            Assert.That(actualName2, Is.EqualTo(expectedName2));
            Assert.That(actualDescription2, Is.EqualTo(expectedDescription2));
            Assert.That(actualImageUrl2, Is.EqualTo(expectedImageUrl2));


        }
    }
}
