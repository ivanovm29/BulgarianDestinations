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

namespace BulgarianDestinations.Tests.DestinationTests
{
    [TestFixture]
    public class AllRegionsNameTest
    {
        private IEnumerable<Region> regions;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IDestinationService service;

        [SetUp]
        public void TestInitialize()
        {

            var region1 = new Region()
            {
                Id = 1,
                Name = "Благоевград",
                Destinations = new List<Destination>()
            };
            var region2 = new Region()
            {
                Id = 2,
                Name = "Бургас",
                Destinations = new List<Destination>()
            };

            regions = new List<Region>() { region1, region2 };


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "AllRegionsNameTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(regions);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new DestinationService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_AllRegionsNameTest()
        {
            var allRegions = service.AllRegionsNameAsync().Result;

            int actualCount = allRegions.Count();
            string actualFirstName = allRegions.ToList()[0];
            string actualSecondName = allRegions.ToList()[1];

            int expectedCount = 2;
            string expectedFirstName = "Благоевград";
            string expectedSecondName = "Бургас";

            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(actualFirstName, Is.EqualTo(expectedFirstName));
            Assert.That(actualSecondName, Is.EqualTo(expectedSecondName));

        }
    }
}
