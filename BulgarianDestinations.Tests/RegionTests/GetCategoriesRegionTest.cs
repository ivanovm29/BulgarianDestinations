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
    public class GetCategoriesRegionTest
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
                    .UseInMemoryDatabase(databaseName: "GetCategoriesRegionTestInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(regions);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new RegionService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_GetCategoriesRegionTest()
        {
            var allCategories = service.GetCategories().Result;

            var actualCount = allCategories.Count();
            var actualName1 = allCategories.ToList()[0].Name;
            var actualName2 = allCategories.ToList()[1].Name;
            var actualId1 = allCategories.ToList()[0].Id;
            var actualId2 = allCategories.ToList()[1].Id;

            var expectedCount = 2;
            var expectedName1 = "Благоевград";
            var expectedName2 = "Бургас";
            var expectedId1 = 1;
            var expectedId2 = 2;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(actualId1, Is.EqualTo(expectedId1));
            Assert.That(actualId2, Is.EqualTo(expectedId2));
            Assert.That(actualName1, Is.EqualTo(expectedName1));
            Assert.That(actualName2, Is.EqualTo(expectedName2));

        }
    }
}
