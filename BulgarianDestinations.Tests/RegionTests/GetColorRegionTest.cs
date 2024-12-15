using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data;
using BulgarianDestinations.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Tests.RegionTests
{
    [TestFixture]
    public class GetColorRegionTest
    {
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IRegionService service;
        [Test]
        public void Test_GetColorRegionTest()
        {
            repository = new Repository(dbContext);
            service = new RegionService(repository);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetColorRegionTestInMemoryDb") // Give a Unique name to the DB
                .Options;
            dbContext = new ApplicationDbContext(options);

            string colorFromZeroToHundred = "#f7f305";
            string colorForHundred = "#0bc208";
            string colorForZero = "#88a4bc";

            string actualZeroColor = service.GetColor(0).Result;
            string actualZeroToHundredColor = service.GetColor(55).Result;
            string actualHundredColor = service.GetColor(100).Result;

            Assert.That(actualZeroColor, Is.EqualTo(colorForZero));
            Assert.That(actualZeroToHundredColor, Is.EqualTo(colorFromZeroToHundred));
            Assert.That(actualHundredColor, Is.EqualTo(colorForHundred));

        }
    }
}
