using BulgarianDestinations.Infrastructure.Data;
using BulgarianDestinations.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BulgarianDestinations.Core.Contracts;
using BulgarianDestinations.Core.Services;
using BulgarianDestinations.Infrastructure.Data.Common;


namespace BulgarianDestinations.Tests.ArticulTests
{
    [TestFixture]
    public class ReturnAllArticuls
    {
        private IEnumerable<Articul> articuls;
        private ApplicationDbContext dbContext;
        private IRepository repository;
        IArticulService service;

        [SetUp]
        public void SetUp()
        {
            articuls = new List<Articul>()
            {
                new Articul(){Id = 1, Name = "Motika", Description = "Some motika.", ImageUrl = "https://i.ibb.co/0Dmhdz1/grivna.jpg", Price = 10.25M},
                new Articul(){Id = 2, Name = "Binokal", Description = "Some binokal.", ImageUrl = "https://i.ibb.co/q5K7mh6/rakavici.jpg", Price = 9.30M},
                new Articul(){Id = 3, Name = "Kniga", Description = "Some kniga.", ImageUrl = "https://i.ibb.co/BqBxQxB/pompa.jpg", Price = 28.00M},

            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "AllArticulsInMemoryDb") // Give a Unique name to the DB
                    .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.AddRange(articuls);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);
            service = new ArticulService(repository); // Pass it to Service as dependency
        }

        [Test]
        public void Test_GetAllArticuls()
        {
           
            var articulsToTest = service.All();

            var count = articulsToTest.Result.Count();

            var firstArticulName = articulsToTest.Result.FirstOrDefault(a => a.Id == 1).Name;
            var seconfArticulName = articulsToTest.Result.FirstOrDefault(a => a.Id == 2).Name;
            var thirdArticulName = articulsToTest.Result.FirstOrDefault(a => a.Id == 3).Name;

            var firstArticulDescription = articulsToTest.Result.FirstOrDefault(a => a.Id == 1).Description;
            var seconfArticulDescription = articulsToTest.Result.FirstOrDefault(a => a.Id == 2).Description;
            var thirdArticulDescription = articulsToTest.Result.FirstOrDefault(a => a.Id == 3).Description;

            var firstArticulImageUrl = articulsToTest.Result.FirstOrDefault(a => a.Id == 1).ImageUrl;
            var seconfArticulImageUrl = articulsToTest.Result.FirstOrDefault(a => a.Id == 2).ImageUrl;
            var thirdArticulImageUrl = articulsToTest.Result.FirstOrDefault(a => a.Id == 3).ImageUrl;

            var firstArticulPrice = articulsToTest.Result.FirstOrDefault(a => a.Id == 1).Price;
            var seconfArticulPrice = articulsToTest.Result.FirstOrDefault(a => a.Id == 2).Price;
            var thirdArticulPrice = articulsToTest.Result.FirstOrDefault(a => a.Id == 3).Price;


            var firstArticulNameExpected = articuls.FirstOrDefault(a => a.Id == 1).Name;
            var seconfArticulNameExpected = articuls.FirstOrDefault(a => a.Id == 2).Name;
            var thirdArticulNameExpected = articuls.FirstOrDefault(a => a.Id == 3).Name;

            var firstArticulDescriptionExpected = articuls.FirstOrDefault(a => a.Id == 1).Description;
            var seconfArticulDescriptionExpected = articuls.FirstOrDefault(a => a.Id == 2).Description;
            var thirdArticulDescriptionExpected = articuls.FirstOrDefault(a => a.Id == 3).Description;

            var firstArticulImageUrlExpected = articuls.FirstOrDefault(a => a.Id == 1).ImageUrl;
            var seconfArticulImageUrlExpected = articuls.FirstOrDefault(a => a.Id == 2).ImageUrl;
            var thirdArticulImageUrlExpected = articuls.FirstOrDefault(a => a.Id == 3).ImageUrl;

            var firstArticulPriceExpected = articuls.FirstOrDefault(a => a.Id == 1).Price;
            var seconfArticulPriceExpected = articuls.FirstOrDefault(a => a.Id == 2).Price;
            var thirdArticulPriceExpected = articuls.FirstOrDefault(a => a.Id == 3).Price;

            Assert.That(count, Is.EqualTo(articuls.Count()));

            Assert.That(firstArticulName, Is.EqualTo(firstArticulNameExpected));
            Assert.That(firstArticulDescription, Is.EqualTo(firstArticulDescriptionExpected));
            Assert.That(firstArticulImageUrl, Is.EqualTo(firstArticulImageUrlExpected));
            Assert.That(firstArticulPrice, Is.EqualTo(firstArticulPriceExpected));

            Assert.That(seconfArticulName, Is.EqualTo(seconfArticulNameExpected));
            Assert.That(seconfArticulDescription, Is.EqualTo(seconfArticulDescriptionExpected));
            Assert.That(seconfArticulImageUrl, Is.EqualTo(seconfArticulImageUrlExpected));
            Assert.That(seconfArticulPrice, Is.EqualTo(seconfArticulPriceExpected));

            Assert.That(thirdArticulName, Is.EqualTo(thirdArticulNameExpected));
            Assert.That(thirdArticulDescription, Is.EqualTo(thirdArticulDescriptionExpected));
            Assert.That(thirdArticulImageUrl, Is.EqualTo(thirdArticulImageUrlExpected));
            Assert.That(thirdArticulPrice, Is.EqualTo(thirdArticulPriceExpected));

        }

        
    }
}
