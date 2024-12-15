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
    public class ExistsRegionTest
    {
        private IEnumerable<Region> regions;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IRegionService service;

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
                    .UseInMemoryDatabase(databaseName: "ExistsRegionTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(regions);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new RegionService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_ExistsRegionTest()
        {
            bool actualTrue = service.Exists(2).Result;
            bool actualFalse = service.Exists(3).Result;

            Assert.That(actualTrue, Is.EqualTo(true));
            Assert.That(actualFalse, Is.EqualTo(false));

        }
    }
}
